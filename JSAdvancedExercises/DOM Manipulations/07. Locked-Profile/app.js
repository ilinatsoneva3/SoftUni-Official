function lockedProfile() {
    Array.from(document.getElementsByTagName('button')).forEach(btn => {
        btn.addEventListener('click', showInfo);
    });

    function showInfo(e) {
        let element = e.target.parentNode;
        let isUnlocked = element.getElementsByTagName('input')[1];
        let moreInfo = element.getElementsByTagName('div')[0];

        if (isUnlocked.checked === true && e.target.textContent === 'Show more') {
            e.target.textContent = 'Hide it';
            moreInfo.style.display = 'block';
            console.log(e.target.textContent, isUnlocked.checked);
        } else if(isUnlocked.checked === true && e.target.textContent === 'Hide it') {
            e.target.textContent = 'Show more';
            moreInfo.style.display = 'none';
        }

    }
}