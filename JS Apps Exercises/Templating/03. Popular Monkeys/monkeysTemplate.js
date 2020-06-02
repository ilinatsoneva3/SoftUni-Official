(async () => {
  let singleMonkey = await fetch("./single-monkey.hbs").then(res => res.text());
  Handlebars.registerPartial("monkey", singleMonkey);

  let monkeysTemplate = await fetch("./monkeys.hbs").then(res => res.text());
  let template = Handlebars.compile(monkeysTemplate);

  let monkeyAll = template({ monkeys });
  document.getElementsByTagName("section")[0].innerHTML += monkeyAll;

  Array.from(document.getElementsByTagName("button")).forEach(b => {
    b.addEventListener("click", displayInfo);
  });

  function displayInfo(e) {
    let el = e.target.parentNode;
    let paragraphInfo = el.querySelector("p");
    if (paragraphInfo.style.display === "none") {
      paragraphInfo.style.display = "block";
    } else {
      paragraphInfo.style.display = "none";
    }
  }
})();
