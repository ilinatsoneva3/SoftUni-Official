function notify(message) {
    let button = document.getElementsByTagName('button')[0];
    let notification = document.getElementById('notification');
    notification.textContent = message;
    notification.style.display = 'block';

    setTimeout(() => {
        notification.style.display = 'none';
    }, 2000);
}