function solve(arr=[]){
    let catalogue = {};
    arr = arr.sort((a,b)=>a.localeCompare(b));

    arr.forEach((element) => {
        let [product, price] = element.split(" : ");
        price=Number(price);
        let firstLetter = product[0];
        
        if(!catalogue.hasOwnProperty(firstLetter)){
            catalogue[firstLetter] = {};
        }

        let products = catalogue[firstLetter];
              
            products[product] = price;
    });

   let initials = Object.keys(catalogue);

   for(let item of initials){
       console.log(item);
       let products = catalogue[item];
       for (let product in products){
           console.log(` ${product}: ${products[product]}`);
       }
   }
   console.log(initials);
};

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);

