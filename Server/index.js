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
var clientMc = null;
var questions = [];
var currentIdex = -1;
var countDown = 10;
var clients = {};


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

  // add mc
  socket.on('add mc', (user) => {
    var message = "success";
    if (clientMc == null) {
      var userTemp = JSON.parse(user)
      console.log("add mc:" + userTemp.Name);
      clientMc = socket;
    } else {
      message = "MC is exists";
    }
    socket.emit('login', {
      user: user,
      message: message,
      numUsers: numUsers
    });
  });


  // when the client emits 'add user', this listens and executes
  socket.on('add user', (user) => {
    if (addedUser) return;
    var userTemp = JSON.parse(user)
    // we store the user in the socket session for this client
    socket.user = userTemp;
    var message = "success";
    var checked = true;
    console.log(userTemp.Type);
    console.log(userTemp);

    if (clients[userTemp.Name] != undefined) {
      console.log("is exists");
      message = `${userTemp.Name} is exists`;
      checked = false;
    } else {
      ++numUsers;
      clients[userTemp.Name] = socket;
      console.log(`add user: ${userTemp.Name}`);
      console.log(numUsers + " connections");
    }

    addedUser = true;
    // Notify for client
    socket.emit('login', {
      user: user,
      message: message,
      numUsers: numUsers
    });

    if (checked) {
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
    }
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
      if (countDown <= 0) {
        clearInterval(myVar);
        if (clientMc != null) {
          socket.broadcast.emit("correct answer", {
            answer: questions[currentIdex].CorrectAnswerId
          });


          //var listTops = [];
          var tops = [];
          if (clients != null) {
            for (var key in clients) {
              tops.push(clients[key].user)
            }

            tops.sort(function (x, y) {
              return y.NumberCorrect - x.NumberCorrect;
            });
          }
          console.log(tops);
          socket.emit("tops", {
            question: questions[currentIdex],
            tops: tops
          });

          socket.broadcast.emit("tops", {
            question: questions[currentIdex],
            tops: tops
          });
        }
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
    // console.log(answer);

    if (answer.Id === questions[currentIdex].CorrectAnswerId) {
      socket.user.NumberCorrect++;
      clients[socket.user.Name] = socket;
      // console.log(clients[socket.user.Name].user);
    }

    clientMc.emit('user answer', {
      user: socket.user,
      answer: answer
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
        // Remove client
        delete clients[socket.user.Name]
      } else {
        currentIdex = -1;
        questions = [];
        clientMc = null;
      }
      // echo globally that this client has left
      socket.broadcast.emit('user left', {
        user: socket.user,
        numUsers: numUsers
      });
    }
  });
});
