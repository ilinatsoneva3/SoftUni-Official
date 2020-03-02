function solve() {
  Array.from(
    document.querySelector(".minimalistBlack > tbody:nth-child(2)").childNodes
  ).forEach(el => el.addEventListener("click", executeActions));

  function executeActions(e) {
    let target = e.target.parentNode;

    if (target.hasAttribute("style")) {
      target.removeAttribute("style");
    } else {
      Array.from(this.parentElement.children).forEach(el => {
        el.removeAttribute("style");
      });

      target.style.background = "#413f5e";
    }

    //target.hasAttribute("style")
    //  ? target.removeAttribute("style")
    //  : (target.style.background = "#413f5e");
    //
    //Array.from(
    //  document.querySelector(".minimalistBlack > tbody:nth-child(2)").childNodes
    //).forEach(el => {
    //  el.parentNode !== target && el.parentNode.hasAttribute("style")
    //    ? el.removeAttribute("style")
    //    : (el.style.background = "#413f5e");
    //});
  }
}
