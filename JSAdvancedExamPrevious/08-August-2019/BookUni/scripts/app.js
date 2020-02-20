function solve() {
    let addNewButton = document.querySelector("form button");
    let newBooks = document.querySelector("#outputs > section:nth-child(2) > div:nth-child(2)");
    let oldBooks = document.querySelector("#outputs > section:nth-child(1) > div:nth-child(2)");
    let storeProfit = document.querySelector("body > h1:nth-child(3)");
    addNewButton.addEventListener("click", addNewBookEvent);

    function addNewBookEvent(e) {
        e.preventDefault();
        let book = document.querySelectorAll("form input")[0].value;
        let year = +document.querySelectorAll("form input")[1].value;
        let price = +document.querySelectorAll("form input")[2].value;

        if (book && price > 0 && year > 0) {
            if (year > 2000) {
                let div = createNewBook(book, price, year, true);
                newBooks.appendChild(div);
            } else {
                let div = createNewBook(book, price, year, false);
                oldBooks.appendChild(div);
            }
        }
    }

    function createNewBook(book, price, year, isNew) {
        let div = document.createElement("div");
        let p = document.createElement("p");
        let buyBtn = document.createElement("button");
        price = isNew ? price : price * 0.85;


        div.classList.add("book");
        p.innerHTML = `${book} [${year}]`;
        buyBtn.innerHTML = `Buy it only for ${price.toFixed(2)} BGN`;
        buyBtn.addEventListener("click", buyBook);

        div.appendChild(p);
        div.appendChild(buyBtn);       

        if(isNew){
            let moveToOldButton = document.createElement("button");
            moveToOldButton.innerHTML = `Move to old section`;
            moveToOldButton.addEventListener("click", moveToOld);
            div.appendChild(moveToOldButton);
        }

        function moveToOld(){
            oldBooks.appendChild(createNewBook(book, price, year, false));
            newBooks.removeChild(div);
        }
             
        function buyBook() {
            let currentProfit = +storeProfit.innerHTML.split(" ")[3];
            storeProfit.innerHTML=`Total Store Profit: ${(currentProfit+price).toFixed(2)} BGN`;
            isNew ? newBooks.removeChild(div) : oldBooks.removeChild(div);
        }

        return div;
    }
}
