function solution() {
    let giftList = document.getElementsByTagName("ul")[0];
    let addGiftBtn = document.getElementsByTagName("button")[0];

    addGiftBtn.addEventListener("click", getGift);

    function getGift() {
        let item = document.querySelector("section.card:nth-child(1)").lastElementChild.children[0].value;

        if (item) {
            let newGift = document.createElement("li");
            newGift.classList.add('gift');
            newGift.textContent = item;

            newGift = createButton("Send", newGift);
            newGift = createButton("Discard", newGift);
            newGift.children[0].addEventListener("click", sendGift);
            newGift.children[1].addEventListener("click", discardGift);

            let listOfGifts = document.querySelector("section.card:nth-child(2) > ul:nth-child(2)");
            listOfGifts.appendChild(newGift);

            sortGifts(giftList);
            document.querySelector("section.card:nth-child(1)").lastElementChild.children[0].value = "";

        }
    }

    function sortGifts(giftList) {
        let newArr = [];
        let arrGifts = Array.from(giftList.getElementsByTagName("li"))
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(li => giftList.appendChild(li));
    }

    function createButton(type, listItem) {
        let newButton = document.createElement("button");
        newButton.textContent = `${type}`;
        newButton.setAttribute("id", `${type.toLowerCase()}Button`);
        listItem.appendChild(newButton);
        return listItem;
    };

    function sendGift(e) {
        let li = e.target.parentNode;
        let listItem = li.firstChild.textContent;
        let sentGifts = document.querySelector("section.card:nth-child(3) > ul:nth-child(2)");
        let newLi = document.createElement("li");
        newLi.textContent = listItem;
        newLi.classList.add("gift");
        sentGifts.appendChild(newLi);
        li.parentNode.removeChild(li);
    }

    function discardGift(e) {
        let li = e.target.parentNode;
        let listItem = li.firstChild.textContent;
        let sentGifts = document.querySelector("section.card:nth-child(4) > ul:nth-child(2)");
        let newLi = document.createElement("li");
        newLi.textContent = listItem;
        newLi.classList.add("gift");
        sentGifts.appendChild(newLi);
        li.parentNode.removeChild(li);
    }
}