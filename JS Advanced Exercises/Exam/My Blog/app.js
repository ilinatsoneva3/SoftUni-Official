function solve() {
  let createBtn = document.getElementsByTagName("button")[0];
  createBtn.addEventListener("click", addArticle);
  let articles = document.querySelector(
    ".site-content > main:nth-child(1) > section:nth-child(1)"
  );

  function addArticle(e) {
    e.preventDefault();
    let name = document.querySelector("#creator").value;
    let title = document.querySelector("#title").value;
    let category = document.querySelector("#category").value;
    let content = document.querySelector("#content").value;
    if (name && title && category && content) {
      let article = document.createElement("article");
      let h1 = createHTMLElement("h1", title);
      let pCategory = createHTMLElement("p", category, "Category: ", "strong");
      let pCreator = createHTMLElement("p", name, "Creator: ", "strong");
      let pContent = createHTMLElement("p", content);
      let div = document.createElement("div");
      div.setAttribute("class", "buttons");
      let deleteBtn = createHTMLElement("button", "Delete");
      deleteBtn.setAttribute("class", "btn delete");
      deleteBtn.addEventListener("click", deleteArticle);
      let archiveBtn = createHTMLElement("button", "Archive");
      archiveBtn.setAttribute("class", "btn archive");
      archiveBtn.addEventListener("click", archiveArticle);

      div = appendChildren([deleteBtn, archiveBtn], div);
      article = appendChildren(
        [h1, pCategory, pCreator, pContent, div],
        article
      );

      articles.appendChild(article);
    }
  }

  function createHTMLElement(type, content, otherText, style) {
    let el = document.createElement(type);

    if (otherText) {
      el.textContent += otherText;
    }

    if (style) {
      // el.innerHTML += `<${style}>${content}</${style}>`;
      let strong = document.createElement("STRONG");
      strong.textContent = content;
      el.appendChild(strong);
    } else {
      el.textContent += content;
    }
    return el;
  }

  function appendChildren(children, parent) {
    for (const child of children) {
      parent.appendChild(child);
    }
    return parent;
  }

  function deleteArticle(e) {
    let parent = e.target;
    parent = parent.parentNode.parentNode;
    articles.removeChild(parent);
  }

  function archiveArticle(e) {
    let parent = e.target;
    parent = parent.parentNode.parentNode;
    let archive = document.querySelector(".archive-section > ul:nth-child(2)");
    articles.removeChild(parent);
    let title = parent.children[0].textContent;
    let li = document.createElement("li");
    li.textContent = title;
    archive.appendChild(li);
    let sorted = Array.from(archive.getElementsByTagName("li")).sort((a, b) =>
      a.textContent.toLowerCase().localeCompare(b.textContent.toLowerCase())
    );

    for (const item of sorted) {
      archive.appendChild(item);
    }
  }
}
