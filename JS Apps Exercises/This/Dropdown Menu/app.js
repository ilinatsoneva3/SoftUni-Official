function solve() {
  let styleBtn = document.getElementById("dropdown");
  styleBtn.addEventListener("click", revealStyles);
  let boxInitialState = document.getElementById("box");

  function revealStyles(e) {
    let listOfStyles = document.getElementById("dropdown-ul");

    listOfStyles.style.display === "block"
      ? hideElements(listOfStyles)
      : showElements(listOfStyles);

    function hideElements(el) {
      el.style.display = "none";
      let oldChild = document.getElementById("box");
      document
        .getElementsByTagName("body")[0]
        .replaceChild(boxInitialState, oldChild);
    }

    function showElements(el) {
      Array.from(listOfStyles.children).forEach(btn => {
        btn.addEventListener("click", changeButtonStyle);
      });
      el.style.display = "block";
    }
  }

  function changeButtonStyle(e) {
    let newStyle = e.target.textContent;
    let boxBtn = document.getElementById("box");
    boxBtn.style.background = newStyle;
    boxBtn.style.color = "black";
  }
}
