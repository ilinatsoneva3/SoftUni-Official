function solve() {
   let shoppingList = {};

   let buttons = document.getElementsByTagName("button");
   let text = document.getElementsByTagName("textarea")[0];

   Array.from(buttons).forEach(b => b.addEventListener('click', addToCard));

   function addToCard(e) {
      if (e.target.className === "add-product") {
         let product = e.target.parentElement;
         let price = Number(product.nextElementSibling.textContent);
         let productName = product.previousElementSibling.children[0].textContent;

         if (!shoppingList.hasOwnProperty(productName)) {
            shoppingList[productName] = 0;
         }

         shoppingList[productName] += price;

         text.textContent += `Added ${productName} for ${price.toFixed(2)} to the cart.\n`;
      }else{
         Array.from(buttons).forEach(b=>b.disabled=true);
         let totalPrice = Number(Object.values(shoppingList).reduce((a,b)=>a+b,0));
         let products = Object.keys(shoppingList).join(', ');
         text.textContent += `You bought ${products} for ${totalPrice.toFixed(2)}.`;
      }      
   }
}