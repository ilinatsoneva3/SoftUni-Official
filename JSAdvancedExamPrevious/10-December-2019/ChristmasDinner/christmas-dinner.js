class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    };

    get budget() {
        return this._budget;
    }
    set budget(value){
        if(value<0){
            throw new Error("The budget cannot be a negative number");
        }
        this._budget = value;
    };

    shopping(arr=[]){
        let product = arr[0];
        let price = +arr[1];
        if(this._budget-price<0){
            throw new Error("Not enough money to buy this product");
        }
        this._budget-=price;
        this.products.push(product);
        return `You have successfully bought ${product}!`;
    };

    recipes(obj={}){
        let name = obj.recipeName;
        let productsList = obj.productsList;
        for (const product of productsList) {
            if(!this.products.includes(product)){
               throw new Error("We do not have this product");
            }
        };
        this.dishes.push({
            "recipeName": name,
            "productList": productsList
        });
        return `${name} has been successfully cooked!`;
    };

    inviteGuests(name, dish){
        let currentDish = this.dishes.filter(d=>d.recipeName === dish);
        if(currentDish===undefined){
            throw new Error("We do not have this dish");
        };
        let currentGuest = Object.keys(this.guests).includes(name);
        if(currentGuest){
            throw new Error("This guest has already been invited");
        }        
        this.guests[name] = dish;
        return `You have successfully invited ${name}!`;
    };

    showAttendance(){
        let sb = ''
        for (const guest of Object.keys(this.guests)) {
            let products = this.dishes.filter(x=>x.recipeName==[this.guests[guest]]);            
            products = products[0]["productList"].join(", ");
            sb += `${guest} will eat ${this.guests[guest]}, which consists of ${products}` +`\n`;
        }
        return sb.trim();
    }
}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());


