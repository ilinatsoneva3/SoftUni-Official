export default function (context) {
  firebase.auth().onAuthStateChanged(function (user) {
    if (user) {
      // User is signed in.
      context.isLoggedIn = true;
      context.username = user.email;
      context.userId = user.uid;

      localStorage.setItem("userId", user.uid);
      localStorage.setItem("userEmail", user.email);
      // ...
    } else {
      context.isLoggedIn = false;
      context.username = null;
      context.userId = null;
      localStorage.removeItem("userId");
      localStorage.removeItem("userEmail");
    }
  });

  return context.loadPartials({
    header: "../view/common/header.hbs",
    footer: "../view/common/footer.hbs",
  });
}
