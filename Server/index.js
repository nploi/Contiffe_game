// Setup basic express server
var express = require('express');
var app = express();
var path = require('path');
var server = require('http').createServer(app);
var io = require('socket.io')(server);
var port = process.env.PORT || 3000;

server.listen(port, () => {
  console.log('Server listening at port %d', port);
});

// Routing
app.use(express.static(path.join(__dirname, 'public')));

// Chatroom

var numUsers = 0;
var clients = [];
var clientMc = null;
var questions = [];
var currentIdex = -1;
var countDown = 10;


io.on('connection', (socket) => {
  var addedUser = false;

  console.log("Some one connected");

  // when the client emits 'new message', this listens and executes
  socket.on('new message', (data) => {
    // we tell the client to execute 'new message'
    socket.broadcast.emit('new message', {
      user: socket.user,
      message: data
    });
  });

  // when the client emits 'add user', this listens and executes
  socket.on('add user', (user) => {
    if (addedUser) return;
    user = JSON.parse(user)
    console.log(user)
    // we store the user in the socket session for this client
    socket.user = user;
    var message = "success";
    if (user.Type != "mc") {
      var checked = true;
      if (clients > 0) {
        for (var i = 0; i < clients.length; i++) {
          var item = JSON.parse(clients[i].socket.user)
          console.log(item);
          if (item.UserName === clients[i].user.UserName) {
            console.log("is exists");
            checked = false;
            break;
          }
        }
      }
      if (!checked) {
        message = `${user.UserName} is exists`;
        console.log(`Error: ${message}`);

      } else {
        console.log(`add user: ${user.UserName}`);
        ++numUsers;
        clients.push({
          socket: socket
        });
        console.log(clients[numUsers -1].socket);

      }

    } else {
      console.log("add mc:" + user);
      clientMc = socket;
    }

    addedUser = true;
    socket.emit('login', {
      user: user,
      message: message,
      numUsers: numUsers
    });

    if (currentIdex >= 0) {
      socket.emit('next question', {
        question: questions[currentIdex],
        index: currentIdex,
        countDown: countDown
      });
    }
    // echo globally (all clients) that a person has connected
    socket.broadcast.emit('user joined', {
      user: socket.user,
      numUsers: numUsers
    });
  });

  // when the client emits 'new question', we broadcast it to others
  socket.on('new question', (question) => {
    // Add question
    currentIdex++;
    countDown = 10;
    question = JSON.parse(question)
    console.log(question)
    questions.push(question);

    // Timer
    var myVar = setInterval(() => {
      countDown--;
      if (countDown <= 0 && clientMc != null) {
        clearInterval(myVar);
        socket.broadcast.emit("correct answer", {
          answer: questions[currentIdex].CorrectAnswerId
        })
      }
      console.log("timer: " + countDown);
    }, 1000);

    socket.emit('added question', {
      question: question,
      index: currentIdex,
    });

    // when the client mc send 'question' to all clients
    socket.broadcast.emit('next question', {
      question: question,
      index: currentIdex,
      countDown: countDown
    });

  });

  // when the client emits 'answer', we emit it to mc
  socket.on('answer', (answer) => {
    answer = JSON.parse(answer)
    console.log(answer);
    clientMc.emit('user answer', {
      UserName: socket.user.UserName
    });
  });

  // when the client emits 'typing', we broadcast it to others
  socket.on('typing', () => {
    socket.broadcast.emit('typing', {
      username: socket.username
    });
  });

  // when the client emits 'typing', we broadcast it to others
  socket.on('live video', (image) => {
    socket.broadcast.emit('live video', {
      image: image
    });
  });

  // when the client emits 'typing', we broadcast it to others
  socket.on('live audio', (audio) => {
    console.log(audio);
    socket.broadcast.emit('live audio', {
      audio: audio
    });
  });

  // when the client emits 'stop typing', we broadcast it to others
  socket.on('stop typing', () => {
    socket.broadcast.emit('stop typing', {
      username: socket.username
    });
  });

  // when the user disconnects.. perform this
  socket.on('disconnect', () => {
    console.log("Some one disconnected");
    if (addedUser) {
      if (socket.user.Type != "mc") {
        --numUsers;
      } else {
        currentIdex = -1;
        questions = [];
        clientMc = null;
      }
      // echo globally that this client has left
      socket.broadcast.emit('user left', {
        username: socket.user,
        numUsers: numUsers
      });
    }
  });
});
