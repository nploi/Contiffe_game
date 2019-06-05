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
  var amount = -1;
  // when the client emits 'new message', this listens and executes
  socket.on('new message', (message) => {
    // we tell the client to execute 'new message'
    socket.broadcast.emit('new message', {
      message: message
    });
  });

  // add mc
  socket.on('add mc', (game) => {
    var message = "success";
    console.log("Some one connected");

    if (addedUser) return;

    if (clientMc == null) {
      addedUser = true;
      var gameTemp = JSON.parse(game)
      socket.user = gameTemp.User;
      socket.award = gameTemp.Award;
      socket.require = gameTemp.Require;
      socket.numberQuestion = gameTemp.NumberQuestion;
      // console.log(socket.award);
      console.log("add mc: " + gameTemp.User.Name);
      clientMc = socket;
    } else {
      message = "MC is exists";
    }
    socket.emit('login', {
      game: gameTemp,
      message: message,
      numUsers: numUsers
    });
    if (addedUser) {
      socket.broadcast.emit("mc connected", {
        game: gameTemp
      });
    }
  });


  // when the client emits 'add user', this listens and executes
  socket.on('add user', (user) => {
    console.log("Some one connected");
    if (addedUser) return;
    var userTemp = JSON.parse(user)
    // we store the user in the socket session for this client
    socket.user = userTemp;
    var message = "success";
    var checked = true;
    // console.log(userTemp.Type);
    // console.log(userTemp);

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

    // Notify for client
    socket.emit('login', {
      user: user,
      message: message,
      numUsers: numUsers
    });

    if (checked) {
      addedUser = true;
      if (currentIdex >= 0) {
        socket.emit('next question', {
          question: questions[currentIdex],
          index: currentIdex,
          countDown: countDown
        });
      }

      if (clientMc != undefined) {
        // console.log({
        //   User: clientMc.user,
        //   Award: clientMc.award
        // });
        clientMc.broadcast.emit("mc connected", {
          game: {
            User: clientMc.user,
            Award: clientMc.award
          }
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
    // console.log(question)
    questions.push(question);

    // Timer
    var myVar = setInterval(() => {
      countDown--;
      if (countDown <= 0) {
        clearInterval(myVar);
        if (clientMc !== null) {
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
          // console.log(tops);
          socket.emit("tops", {
            question: questions[currentIdex],
            tops: tops
          });

          socket.broadcast.emit("tops", {
            question: questions[currentIdex],
            tops: tops
          });
          console.log(currentIdex)
          console.log(clientMc.numberQuestion)

          if (currentIdex == clientMc.numberQuestion - 1) {
            console.log(currentIdex)
            var awardRecipients = []

            for (var key in clients) {
              if (clients[key].user.NumberCorrect >= clientMc.require) {
                awardRecipients.push(clients[key].user);
                console.log(clients[key].user)
              }
            }

            var bonus = null;

            if (awardRecipients.length > 0) {
              bonus = clientMc.award / awardRecipients.length;
            }
  
            console.log(bonus)
            console.log(awardRecipients)

            clientMc.emit('congratulations', {
              bonus: bonus,
              awardRecipients: awardRecipients
            });
  
            for (var i = 0; i< awardRecipients.length; i++) {
              clients[awardRecipients[i].Name].emit('congratulations', {
                bonus: bonus
              });
            }
          }
        }
      }
      // console.log("timer: " + countDown);
    }, 1000);

    socket.emit('added question', {
      question: question,
      index: currentIdex,
      countDown: countDown
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
    // console.log(audio);
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
    if (socket.user == undefined) {
      return;
    }

    if (addedUser && socket.user.Type != "mc") {
      console.log("user " + socket.user.Name + ": disconnected");
      if (socket.user.Type != "mc") {
        --numUsers;
        // Remove client
        delete clients[socket.user.Name]
      }

      // echo globally that this client has left
      socket.broadcast.emit('user left', {
        user: socket.user,
        numUsers: numUsers
      });
    } else {
      console.log("mc " + socket.user.Name + ": disconnected");
      currentIdex = -1;
      questions = [];
      clientMc = null;

      socket.broadcast.emit('mc disconnected', {
        user: socket.user,
        numUsers: numUsers
      });
    }

  });
});
