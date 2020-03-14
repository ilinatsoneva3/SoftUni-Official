function attachEvents() {
  const sendBtn = document.getElementById("submit");
  const refreshBtn = document.getElementById("refresh");
  const messagesArea = document.getElementById("messages");
  const nameField = document.getElementById("author");
  let messageField = document.getElementById("content");

  sendBtn.addEventListener("click", sendMessage);
  refreshBtn.addEventListener("click", showAllMessages);

  function sendMessage(e) {
    const author = nameField.value;
    const content = messageField.value;

    const headers = {
      method: "POST",
      headers: { "Content-type": "application/json" },
      body: JSON.stringify({ author, content })
    };

    fetch(`https://rest-messanger.firebaseio.com/messanger.json`, headers)
      .then(() => {
        nameField.value = "";
        messageField.value = "";
      })
      .catch(error);
  }

  function showAllMessages(e) {
    fetch(`https://rest-messanger.firebaseio.com/messanger.json`)
      .then(res => res.json())
      .then(displayMessages)
      .catch(error);
  }

  function displayMessages(data) {
    Object.entries(data).forEach(([messageId, message]) => {
      let { author, content } = message;
      messagesArea.textContent += `${author}: ${content}\n`;
    });
  }

  function error() {
    messagesArea.textContent = "ERROR";
  }
}

attachEvents();
