(() => {
  renderCatTemplate();

  async function renderCatTemplate() {
    let catTemplate = await fetch("./single-cat-template.hbs").then(res =>
      res.text()
    );
    Handlebars.registerPartial("cat", catTemplate);

    let catsTemplate = await fetch("./cats-template.hbs").then(res =>
      res.text()
    );
    let template = Handlebars.compile(catsTemplate);

    let listOfCats = template({ cats });

    document.getElementById("allCats").innerHTML = listOfCats;

    Array.from(document.getElementsByClassName("showBtn")).forEach(b => {
      b.addEventListener("click", showInfo);
    });

    function showInfo(e) {
      let currentCat = e.target.parentNode.querySelector("div.status");
      let btn = e.target.parentNode.querySelector("button.showBtn");

      if (currentCat.style.display === "none") {
        btn.textContent = "Hide status code";
        currentCat.style.display = "block";
      } else {
        btn.textContent = "Show status code";
        currentCat.style.display = "none";
      }
    }
  }
})();
