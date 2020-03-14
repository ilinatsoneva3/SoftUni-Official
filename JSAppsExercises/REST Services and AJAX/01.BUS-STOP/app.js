function getInfo() {
  const stopID = document.getElementById("stopId");
  const stopName = document.getElementById("stopName");
  let busesList = document.getElementById("buses");

  let url = `https://judgetests.firebaseio.com/businfo/${stopID.value}.json`;
  busesList.textContent = "";
  stopName.textContent = "";

  fetch(url)
    .then(response => response.json())
    .then(data => {
      const { name, buses } = data;
      stopName.textContent = name;
      Object.entries(buses).forEach(([bus, busTime]) => {
        let li = document.createElement("li");
        li.textContent = `Bus ${bus} arrives in ${busTime} minutes`;
        busesList.appendChild(li);
      });
    })
    .catch(err => {
      stopName.textContent = "ERROR";
    });
}
