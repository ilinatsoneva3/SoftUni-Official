function solve() {
   //Add the new products as list items

   const addProductBtn = document.querySelector("#add-new button");
   const filterBtn = document.querySelector(".filter > button");
   const products = document.querySelector("#products ul");
   const myProducts = document.querySelector("#myProducts ul");
   const buyBtn = document.querySelector("#myProducts button");
   addProductBtn.addEventListener("click", addProductToAvailableProducts);
   filterBtn.addEventListener("click", filterProducts);
   buyBtn.addEventListener("click", buyProducts);

   function buyProducts(){
      myProducts.textContent = "";
      document.querySelector("body > h1:nth-child(4)").textContent = `Total Price: 0.00`;
   }


   function addProductToAvailableProducts(e) {
      e.preventDefault();

      let name = document.querySelectorAll("#add-new input")[0].value;
      let quantity = +document.querySelectorAll("#add-new input")[1].value;
      let price = +document.querySelectorAll("#add-new input")[2].value;

      let element = createElementForAvailableProducts(name, quantity, price);
      products.appendChild(element);
      document.querySelectorAll("#add-new input")[0].value = '';
      document.querySelectorAll("#add-new input")[1].value = '';
      document.querySelectorAll("#add-new input")[2].value = '';
   }

   function filterProducts() {
      let filterCriteria = document.getElementById("filter").value.toLowerCase();
      let products = Array.from(document.querySelectorAll("#products ul li span"));
      for (const item of products) {
         if (!item.textContent.toLowerCase().includes(filterCriteria)) {
            item.parentNode.style.display = "none";
         } else {
            item.parentNode.style.display = "block";
         }
      }
      document.getElementById("filter").value = "";
   }

   function createElementForAvailableProducts(name, quantity, price) {
      let li = document.createElement("li");
      let span = document.createElement("span");
      let strong = document.createElement("strong");
      let div = document.createElement("div");
      let divStrong = document.createElement("strong");
      let button = document.createElement("button");
      button.addEventListener("click", addToMyProducts);

      divStrong.textContent = price.toFixed(2);
      button.textContent = "Add to Client's List";
      div.appendChild(divStrong);
      div.appendChild(button);
      strong.textContent = `Available: ${quantity}`;
      span.textContent = name;
      li.appendChild(span);
      li.appendChild(strong);
      li.appendChild(div);
      return li;
   }

   function addToMyProducts(e) {
      e.preventDefault();
      let li = e.target.parentNode.parentNode;
      let name = li.children[0].textContent;
      let price = +(li.children[2].children[0].textContent);
      let quantity = li.children[1].textContent.split(': ');
      quantity = +quantity[1];
      let element = createElementForMyProducts(name, price);
      myProducts.appendChild(element);
      --quantity;
      li.children[1].textContent = `Available: ${quantity}`;
      if (quantity === 0) {
         products.removeChild(li);
      }
      let totalPrice = document.querySelector("body > h1:nth-child(4)").textContent;
      changeTotalPrice(price, totalPrice);
   }

   function createElementForMyProducts(name, price) {
      let li = document.createElement("li");
      let strong = document.createElement("strong");
      li.textContent = name;
      strong.textContent = price.toFixed(2);
      li.appendChild(strong);
      return li;
   }

   function changeTotalPrice(price, totalPrice) {
      totalPrice = +totalPrice.split(": ")[1];
      totalPrice += price;
      document.querySelector("body > h1:nth-child(4)").textContent = `Total Price: ${totalPrice.toFixed(2)}`;
   }
}