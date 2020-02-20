function mySolution() {
    let pendingQuestions = document.getElementById("pendingQuestions");
    let openQuenstions = document.getElementById("openQuestions");
    let sendBtn = document.querySelector("div button");

    sendBtn.addEventListener("click", sendQuestion);

    function sendQuestion() {
        let inputField = document.querySelector("#inputSection > textarea").value;
        let username = document.querySelector("div input").value;

        let div = createElement("div", "", "pendingQuestion");
        let img = createElement("img", "", null, [{ k: "src", v: "./images/user.png" }, { k: "width", v: "32" }, { k: "height", v: "32" }]);
        let span = createElement("span", username);
        let p = createElement("p", inputField);
        let divActions = createElement("div", "", "actions");
        let archiveBtn = createElement("button", "Archive", "archive", null, { k: "click", v: archiveQuestion });
        let openBtn = createElement("button", "Open", "open", null, { k: "click", v: openQuestion });

        divActions = appendElements([archiveBtn, openBtn], divActions);

        div = appendElements([img, span, p, divActions], div);
        pendingQuestions.appendChild(div);
    }

    function createElement(type, text, classText, attributes, event) {
        let el = document.createElement(type);
        el.textContent = text;

        if (classText) {
            el.classList.add(classText);
        }

        if (type === "span") {
            text === "" ? el.textContent = "Anonymous" : el.textContent = text;
        }

        if (attributes) {
            attributes.forEach(a=>el.setAttribute(a.k,a.v));
        }

        if (event) {
            el.addEventListener(event.k, event.v)
        }
        return el;
    }

    function archiveQuestion(e) {
        let parent = e.target;
        parent = parent.parentNode.parentNode;
        pendingQuestions.removeChild(parent);
    }

    function openQuestion(e) {
        let parent = e.target;
        parent = parent.parentNode.parentNode;
        pendingQuestions.removeChild(parent);

        parent.classList.remove("pendingQuestion");
        parent.classList.add("openQuestion");

        let div = parent.querySelector("div");
        let buttons = parent.querySelectorAll("button");

        Array.from(buttons).forEach(b => div.removeChild(b));

        let replyBtn = createElement("button", "Reply", "reply", null, { k: "click", v: replyToQuestion });
        let divReplySection = createElement("div", "", "replySection", [{ k: "style", v: "display: none" }]);
        let input = createElement("input", "", "replyInput", [{ k: "type", v: "text" }, { k: "placeholder", v: "Reply to this question here..." }]);
        let replyButton = createElement("button", "Send", "replyButton", null,{k:"click", v:postReply});
        let ol = createElement("ol", "", "reply",[{k:"type", v:"1"}]);
        div.appendChild(replyBtn);
        divReplySection = appendElements([input, replyButton, ol], divReplySection);
        parent.appendChild(divReplySection);
        openQuenstions.appendChild(parent);
    }

    function postReply(e) {
        let parent = e.target;
        parent = parent.parentNode;
        let answer = parent.getElementsByTagName("input")[0].value;
        if (answer) {
            let listItem = parent.getElementsByTagName("ol")[0];
            let li = createElement("li", answer);
            listItem.appendChild(li);
        }
        answer = parent.getElementsByTagName("input")[0].value = "";
    }

    function replyToQuestion(e) {
        let parent = e.target;
        parent = parent.parentNode.parentNode;
        let divs = parent.querySelectorAll("div");
        let button = divs[0].querySelector("button");

        if (button.textContent === "Reply") {
            button.textContent = "Back";
            divs[1].style.display = "block";
        } else {
            button.textContent = "Reply";
            divs[1].style.display = "none";
        }
    }

    function appendElements(children, parent) {
        for (const child of children) {
            parent.appendChild(child);
        }
        return parent;
    }
}