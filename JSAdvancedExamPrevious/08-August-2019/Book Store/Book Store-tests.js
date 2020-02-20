const BookStore = require('./02. Book Store_Ресурси');

const assert = require('chai').assert;

describe("Test", function () {
    it("constructor", function () {
        let store = new BookStore("test");
        assert.equal(store.name, "test");
        assert.deepEqual(store.books, []);
        assert.deepEqual(store._workers, []);
    });

    it("stockBooks", function () {
        let store = new BookStore("Store");

        let actual = store.stockBooks(['Inferno-Dan Braun', 'Harry Potter-J.Rowling']);
        assert.deepEqual(JSON.stringify(actual), '[{"title":"Inferno","author":"Dan Braun"},{"title":"Harry Potter","author":"J.Rowling"}]');
    });

    it("hire without error", function () {
        let store = new BookStore("Store");
        let result = store.hire("Harry", "CEO");
        assert.equal(result, "Harry started work at Store as CEO");
        let obj = {
            name: "Harry",
            position: "CEO",
            booksSold: 0
        }
        assert.deepEqual(store._workers[0], obj);
    });

    it("hire throws error", function () {
        let store = new BookStore("Store");
        store.hire("Harry", "CEO");
        let error = () => {
            store.hire("Harry");
        }
        assert.throw(error, "This person is our employee");
    });

    it("fire without errors", function () {
        let store = new BookStore("Store");
        store.hire("Harry", "CEO");
        let result = store.fire("Harry");
        assert.equal(result, "Harry is fired");
        assert.deepEqual(store._workers, []);
    });

    it("fire throws error", function () {
        let store = new BookStore("Store");
        let error = () => {
            store.fire("Harry");
        }
        assert.throw(error, "Harry doesn't work here");
    });

    it("sell book without errors", function () {
        let store = new BookStore("Store");

        store.stockBooks(['Inferno-Dan Braun', 'Harry Potter-J.Rowling']);
        store.hire("Harry", "CEO");
        store.sellBook("Harry Potter", "Harry");
        assert.equal(store.books.length, 1);
        assert.equal(store.workers[0].booksSold, 1);
    });

    it("sell book throw error", function () {
        let store = new BookStore("Store");
        let error = () => {
            store.sellBook("Harry Potter", "Harry");
        }

        assert.throw(error, "This book is out of stock");
        store.stockBooks(["Harry Potter-J.Rowling"]);
        error = () => {
            store.sellBook("Harry Potter", "Harry");
        }

        assert.throw(error, "Harry is not working here");
    });

    it("print workers with no errors", function () {
        let store = new BookStore("Store");
        store.stockBooks(['Inferno-Dan Braun', 'Harry Potter-J.Rowling']);
        store.hire("Harry", "CEO");
        let actual = store.printWorkers();
        assert.deepEqual(actual, "Name:Harry Position:CEO BooksSold:0");
        store.sellBook("Inferno", "Harry");
        actual = store.printWorkers();
        assert.deepEqual(actual, "Name:Harry Position:CEO BooksSold:1");
    });
})