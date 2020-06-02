function attachEvents() {
  const url = "https://judgetests.firebaseio.com/locations.json";

  const elements = {
    locationInput: document.getElementById("location"),
    button: document.getElementById("submit"),
    currentCondition: document.getElementById("current"),
    forecast: document.getElementById("forecast"),
    upcomingCondition: document.getElementById("upcoming")
  };

  function switchSymbols(condition) {
    switch (condition) {
      case "Sunny":
        return "☀";
      case "Partly sunny":
        return "⛅";
      case "Overcast":
        return "☁";
      case "Rain":
        return "☂";
    }
  }

  elements.button.addEventListener("click", loadForecast);

  function loadForecast(e) {
    clearPreviousForecast();

    fetch(url)
      .then(response => response.json())
      .then(getLocationForecast)
      .catch(err => console.log(err));
  }

  function getLocationForecast(data) {
    let location = data.find(l => l.name === elements.locationInput.value).code;

    fetch(`https://judgetests.firebaseio.com/forecast/today/${location}.json`)
      .then(response => response.json())
      .then(handleCurrentWeatherForecast)
      .catch(err => console.log(err));
  }

  function handleCurrentWeatherForecast(data) {
    elements.forecast.style = "display:block";
    createHtml(data);
  }

  function getUpcomingForecast(data) {}

  function createHtml(data) {
    let classForecasts = createHtmlElement("div", "forecasts");
    document.querySelector("#current").style.display = "block";
    let symbolSpan = createHtmlElement("span", "condition symbol");
    symbolSpan.textContent = switchSymbols(data.forecast.condition);
    classForecasts.appendChild(symbolSpan);
    elements.currentCondition.appendChild(classForecasts);

    let condtionSpan = createHtmlElement("span", "condition");

    condtionSpan.innerHTML =
      `<span class=forecast-data>${data.name}</span>` +
      `<span class=forecast-data>${data.forecast.low}°/${data.forecast.high}°</span>` +
      `<span class=forecast-data>${data.forecast.condition}</span>`;

    classForecasts.appendChild(condtionSpan);
  }

  function createHtmlElement(type, nameClass, text) {
    let el = document.createElement(type);
    el.className = nameClass;
    return el;
  }

  function clearPreviousForecast() {
    if (elements.currentCondition.children.length > 1) {
      elements.currentCondition.children[1].remove();
      //elements.upcomingCondition.children[1].remove();
    }
  }
}

attachEvents();
