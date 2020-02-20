function mySolution() {
    let pendingQuestions = document.getElementById("pendingQuestions");
    let openQuenstions = document.getElementById("openQuestions");
    let sendBtn = document.querySelector("div button");

    sendBtn.addEventListener("click", sendQuestion);

    function sendQuestion() {
        let inputField = document.querySelector("#inputSection > textarea").value;
        let username = document.querySelector("div input").value;

        let div = createElement("div", "", "pendingQuestion");
        let img = createElement("img");
        let span = createElement("span", username);
        let p = createElement("p", inputField);
        let divActions = createElement("div", "", "actions");
        let archiveBtn = createElement("button", "Archive", "archive");

        archiveBtn.addEventListener("click", archiveQuestion);

        let openBtn = createElement("button", "Open", "open");

        openBtn.addEventListener("click", openQuestion);

        divActions.appendChild(archiveBtn);
        divActions.appendChild(openBtn);
        div.appendChild(img);
        div.appendChild(span);
        div.appendChild(p);
        div.appendChild(divActions)
        pendingQuestions.appendChild(div);
    }

    function createElement(type, text, classText) {
        let el = document.createElement(type);
        el.textContent = text;

        if (classText !== undefined) {
            el.classList.add(classText);
        }

        if (type === "img") {
            el.src = "./images/user.png";
            el.width = 32;
            el.height = 32;
        } else if (type === "span") {
            text === "" ? el.textContent = "Anonymous" : el.textContent = text;
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
        
        let replyBtn = createElement("button", "Reply", "reply");
        replyBtn.addEventListener("click", replyToQuestion);
        div.appendChild(replyBtn);
        let divReplySection = createElement("div", "", "replySection");
        divReplySection.style.display = "none";
        let input = createElement("input", "", "replyInput");
        input.type = "text";
        input.placeholder = "Reply to this question here...";
        divReplySection.appendChild(input);
        let replyButton = createElement("button", "Send", "replyButton");
        replyButton.addEventListener("click", postReply)  
        divReplySection.appendChild(replyButton);
        let ol = createElement("ol", "", "reply");
        ol.type = 1;
        divReplySection.appendChild(ol);
        parent.appendChild(divReplySection);
        openQuenstions.appendChild(parent);
    }

    function postReply(e){
        let parent = e.target;
        parent = parent.parentNode;
        let answer = parent.getElementsByTagName("input")[0].value;
        if(answer){
            let listItem = parent.getElementsByTagName("ol")[0];
            let li = createElement("li", answer);
            listItem.appendChild(li);
        }
        answer = parent.getElementsByTagName("input")[0].value="";
    }

    function replyToQuestion(e){
        let parent = e.target;
        parent = parent.parentNode.parentNode;
        let divs = parent.querySelectorAll("div");
        let button = divs[0].querySelector("button");

        if(button.textContent==="Reply"){
            button.textContent="Back";
            divs[1].style.display = "block";
        }else{
            button.textContent="Reply";
            divs[1].style.display = "none";
        }
    }
}