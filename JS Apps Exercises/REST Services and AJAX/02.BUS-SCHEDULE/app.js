function solve() {
  const busStop = document.getElementsByClassName("info")[0];
  const arriveBtn = document.getElementById("arrive");
  const departBtn = document.getElementById("depart");

  let currentID = "depot";
  let nextStop;

  function depart() {
    fetch(`https://judgetests.firebaseio.com/schedule/${currentID}.json`)
      .then(res => res.json())
      .then(departBus)
      .catch(err => {
        busStop.textContent = "Error";
        arriveBtn.disabled = true;
        departBtn.disabled = true;
      });
  }

  function arrive() {
    arriveBtn.disabled = true;
    departBtn.disabled = false;
    busStop.textContent = `Arriving at ${nextStop}`;
  }

  function departBus(data) {
    let { name, next } = data;
    currentID = next;
    nextStop = name;

    arriveBtn.disabled = false;
    departBtn.disabled = true;
    busStop.textContent = `Next stop ${nextStop}`;
  }

  return {
    depart,
    arrive
  };
}

let result = solve();
