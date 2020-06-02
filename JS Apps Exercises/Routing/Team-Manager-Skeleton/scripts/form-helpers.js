function extractFormData(form) {
  return Array.from(form.children).reduce((acc, currElement) => {
    if (currElement.tagName === "DIV") {
      let currInput = currElement.children[1];
      acc[currInput.getAttribute("id")] = currInput.value;
    }
    return acc;
  }, {});
}

async function registerUser(username, password) {
  let newUser = await firebase
    .auth()
    .createUserWithEmailAndPassword(username, password)
    .catch(err => console.log(err));

  setSessionDetails(newUser);
}

function logOutUser() {
  sessionStorage.clear();
  firebase.auth().signOut();
}

async function loginUser(username, password) {
  let currentUser = await firebase
    .auth()
    .signInWithEmailAndPassword(username, password)
    .catch(err => console.log(err));

  setSessionDetails(currentUser);
}

async function setSessionDetails(user) {
  let token = await firebase.auth().currentUser.getIdToken();
  sessionStorage.setItem("token", token);
  sessionStorage.setItem("username", user.user.email);
  sessionStorage.setItem("userId", firebase.auth().currentUser.uid);
}

export const helpFunctions = {
  extractFormData,
  registerUser,
  logOutUser,
  loginUser
};
