function encodeAndDecodeMessages() {
    let encodeBtn = document.getElementsByTagName('button')[0];
    let decodeBtn = document.getElementsByTagName('button')[1];
    let messageArea = document.getElementsByTagName('textarea')[0];
    let decodedMessageArea = document.getElementsByTagName('textarea')[1];

    encodeBtn.addEventListener('click', encodeMessage);
    decodeBtn.addEventListener('click', decodeMessage);


    function encodeMessage() {
        let message = messageArea.value;
        let decodedMessage = '';
        Array.from(message).forEach(l => {
            let newCharCode = l.charCodeAt(0) + 1;
            decodedMessage += String.fromCharCode(newCharCode);
        });
        decodedMessageArea.value = decodedMessage;
        messageArea.value = '';
    }

    function decodeMessage() {
        let encryptedMessage = decodedMessageArea.value;
        let originalMessage = '';
        Array.from(encryptedMessage).forEach(l => {
            let newCharCode = l.charCodeAt(0) - 1;
            originalMessage += String.fromCharCode(newCharCode);
        })
        decodedMessageArea.value = originalMessage;
    }
}