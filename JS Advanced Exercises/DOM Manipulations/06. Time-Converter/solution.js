function attachEventsListeners() {
    document.getElementById('daysBtn').addEventListener('click', convertFromDays);
    document.getElementById('hoursBtn').addEventListener('click', convertFromHours);
    document.getElementById('minutesBtn').addEventListener('click', convertFromMinutes);
    document.getElementById('secondsBtn').addEventListener('click', convertFromSeconds);

    let inputFieldDays = document.getElementById('days');
    let inputFieldHours = document.getElementById('hours');
    let inputFieldMinutes = document.getElementById('minutes');
    let inputFieldSeconds = document.getElementById('seconds');

    function convertFromDays() {
        inputFieldHours.value = Number(inputFieldDays.value) * 24;
        inputFieldMinutes.value = Number(inputFieldHours.value) * 60;
        inputFieldSeconds.value = Number(inputFieldMinutes.value) * 60;
    }

    function convertFromHours() {
        inputFieldDays.value = Number(inputFieldHours.value) / 24;
        inputFieldMinutes.value = Number(inputFieldHours.value) * 60;
        inputFieldSeconds.value = Number(inputFieldMinutes.value) * 60;
    }

    function convertFromMinutes() {
        inputFieldHours.value = Number(inputFieldMinutes.value) / 60;
        inputFieldDays.value = Number(inputFieldHours.value) / 24;
        inputFieldSeconds.value = Number(inputFieldMinutes.value) * 60;
    }

    function convertFromSeconds() {
        inputFieldMinutes.value = Number(inputFieldSeconds.value) / 60;
        inputFieldHours.value = Number(inputFieldMinutes.value) / 60;
        inputFieldDays.value = Number(inputFieldHours.value) / 24;
    }
}