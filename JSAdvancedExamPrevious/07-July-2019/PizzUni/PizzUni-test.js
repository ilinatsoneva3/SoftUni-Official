const PizzUni = require('./02. PizzUni_Ресурси');

const assert = require('chai').assert;

describe("tests", function () {
    it("constructor", function () {
        let pizzUni = new PizzUni();
        assert.deepEqual(pizzUni.registeredUsers, []);
        assert.deepEqual(pizzUni.orders, []);
        assert.deepEqual(JSON.stringify(pizzUni.availableProducts.pizzas), '["Italian Style","Barbeque Classic","Classic Margherita"]');
        assert.deepEqual(JSON.stringify(pizzUni.availableProducts.drinks), '["Coca-Cola","Fanta","Water"]');
    });
    it("registerUser no errors", function () {
        let pizzUni = new PizzUni();
        let result = pizzUni.registerUser("ilina@abv.bg");
        let expected = {
            email: "ilina@abv.bg",
            orderHistory: []
        }
        assert.deepEqual(result, expected);
    });
    it("registerUser throws error", function () {
        let pizzUni = new PizzUni();
        pizzUni.registerUser("ilina@abv.bg");
        let error = () => {
            pizzUni.registerUser("ilina@abv.bg");
        }
        assert.throw(error, "This email address (ilina@abv.bg) is already being used!");
    });
    it("makeAnOrder no errors", function () {
        let pizzUni = new PizzUni();
        pizzUni.registerUser("ilina@abv.bg");
        let result = pizzUni.makeAnOrder("ilina@abv.bg", "Barbeque Classic", "Fanta");
        let user = pizzUni.registeredUsers[0];
        assert.deepEqual(user.orderHistory.length, 1);
        let order = pizzUni.orders[0];
        let expectedOrder = {
            orderedPizza: "Barbeque Classic",
            orderedDrink: "Fanta",
            email: "ilina@abv.bg",
            status: "pending"
        }
        pizzUni.makeAnOrder("ilina@abv.bg", "Barbeque Classic", "Beer");
        let newOrder = pizzUni.orders[1];
        let expectedNewOrder = {
            orderedPizza: "Barbeque Classic",
            email: "ilina@abv.bg",
            status: "pending"
        }
        assert.deepEqual(order, expectedOrder);
        assert.equal(result, 0);
        assert.deepEqual(newOrder,expectedNewOrder);
        assert.deepEqual(pizzUni.orders[1].orderedDrink,undefined);
        user = pizzUni.registeredUsers[0];
        assert.deepEqual(user.orderHistory.length,2);
    });
    it("makeAnOrder throws errors", function(){
        let pizzUni = new PizzUni();
        let error = () =>{
            pizzUni.makeAnOrder("ilina@abv.bg", "Barbeque Classic", "Fanta");
        }
        assert.throw(error,"You must be registered to make orders!");
        pizzUni.registerUser("ilina@abv.bg");
        error = () => {
            pizzUni.makeAnOrder("ilina@abv.bg", "something", "Fanta");
        }
        assert.throw(error,"You must order at least 1 Pizza to finish the order.");
    });
    it("detailsAboutMyOrder", function(){
        let pizzUni = new PizzUni();
        pizzUni.registerUser("ilina@abv.bg");
        pizzUni.makeAnOrder("ilina@abv.bg", "Barbeque Classic", "Fanta");
        let result = pizzUni.detailsAboutMyOrder(0);
        assert.equal(result,"Status of your order: pending");
       pizzUni.completeOrder();
       result=pizzUni.detailsAboutMyOrder(0);
       assert.equal(result,"Status of your order: completed");
    });
    it("detailsAboutMyOrder", function(){
        let pizzUni = new PizzUni();
        let result = pizzUni.detailsAboutMyOrder(5);
        assert.equal(result, undefined);
    })
    it("completeOrder", function(){
        let pizzUni = new PizzUni();
        pizzUni.registerUser("ilina@abv.bg");
        pizzUni.makeAnOrder("ilina@abv.bg", "Barbeque Classic", "Fanta");
        let result = pizzUni.completeOrder();
        let expected = {
            email:"ilina@abv.bg",
            orderedPizza: "Barbeque Classic",
            orderedDrink: "Fanta",
            status: "completed"
        }
        assert.deepEqual(result, expected);
    })
});