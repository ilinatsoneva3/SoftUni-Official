(() => {
  let townsInfo = document.getElementById("towns");
  let btn = document.getElementById("btnLoadTowns");

  btn.addEventListener("click", listTowns);

  async function listTowns() {
    let towns = townsInfo.value.split(", ");

    let townsTemplate = await fetch("./towns-template.hbs").then(res =>
      res.text()
    );
    let template = Handlebars.compile(townsTemplate);
    let list = template({ towns });
    document.getElementById("root").innerHTML = list;
    document.getElementById("towns").value = "";
  }
})();
