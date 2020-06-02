function solve() {
   let message = document.getElementById('chat_input');
   let send = document.getElementById('send');

   send.addEventListener('click', sendMessage);

   function sendMessage() {
      let messageContent = message.value;
      let newMessage = document.createElement('div');
      newMessage.classList.add('message', 'my-message');
      newMessage.textContent = messageContent;

      document.getElementById('chat_messages').appendChild(newMessage);
      message.value='';
   }
}

