const functions = require("firebase-functions");
const admin = require("firebase-admin");
const FieldValue = admin.firestore.FieldValue;

const authStartsWith = "Bearer ";

admin.initializeApp(functions.config().firebase);

// Create and Deploy Your First Cloud Functions
// https://firebase.google.com/docs/functions/write-firebase-functions

exports.addFriend = functions.https.onRequest((req, res) => {
  if (!req.headers.authorization) {
    res.status(401).send("Unauthorized");
    return;
  }
  if (!req.headers.authorization.startsWith(authStartsWith)) {
    res.status(400).send(
        "Authorization header wrong format. Should be \"Bearer *token*\"");
    return;
  }
  admin.auth().getUser(req.body).then((newFriend) => {
    const decodedTokenPromise = admin.auth()
        .verifyIdToken(req.headers.authorization.split(authStartsWith)[1]);
    decodedTokenPromise.then((decodedToken) => {
      admin.database().ref().child("users").child(decodedToken.uid).update({
        friends: FieldValue.arrayUnion(newFriend.uid),
      }).then((_) => {
        res.status(200).send("Friend added successfully");
      }).catch((err) => {
        res.status(500).send(err);
      });
    }).catch((err) => {
      res.status(400).send(err);
    });
  }).catch((err) => {
    res.status(400).send(err);
  });
});
