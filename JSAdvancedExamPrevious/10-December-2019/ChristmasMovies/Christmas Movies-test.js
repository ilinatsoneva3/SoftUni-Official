const ChristmasMovies = require("./02. Christmas Movies_Resources");

let assert = require("chai").assert;

describe("Christmas movies tests", function () {
    describe("Constructor tests", function () {
        it("Correct instantion", function () {
            let result = new ChristmasMovies();
            assert.deepEqual(result.movieCollection, []);
            assert.deepEqual(result.watched, {});
            assert.deepEqual(result.actors, []);
        });
        it("Functions", function () {
            let = result = new ChristmasMovies();
            assert.isFunction(result.buyMovie);
            assert.isFunction(result.buyMovie);
            assert.isFunction(result.watchMovie);
            assert.isFunction(result.favouriteMovie);
            assert.isFunction(result.mostStarredActor);
        });
    });
    describe("Buy Movie tests", function () {
        it("BuyMovie works correctly", function () {
            let db = new ChristmasMovies();
            let outputActual = db.buyMovie("HP1", ["Daniel", "Rupert", "Emma"]);
            let outputExpected = `You just got HP1 to your collection in which Daniel, Rupert, Emma are taking part!`;
            assert.equal(outputActual, outputExpected);
            assert.equal(db.movieCollection.length, 1);
        });
        it("Non unique actors", function () {
            let db = new ChristmasMovies();
            let outputActual = db.buyMovie("HP1", ["Daniel", "Daniel", "Emma"]);
            let outputExpected = `You just got HP1 to your collection in which Daniel, Emma are taking part!`;
            assert.equal(outputActual, outputExpected);
            let actualActors = db.movieCollection[0]["actors"];
            let expectedActors = ["Daniel", "Emma"];
            assert.deepEqual(actualActors, expectedActors);
        })
        it("BuyMovie throws error", function () {
            let db = new ChristmasMovies();
            db.buyMovie("HP1", ["Daniel", "Rupert", "Emma"]);
            let result = () => {
                db.buyMovie("HP1", ["Daniel", "Rupert", "Emma"]);
            };
            let expected = `You already own HP1 in your collection!`;
            assert.throw(result, expected);
        });
    });
    describe("Discard Movie tests", function () {
        it("works correctly", function () {
            let db = new ChristmasMovies();
            db.buyMovie("HP1", ["Daniel", "Rupert", "Emma"]);
            db.watchMovie("HP1");
            assert.equal(db.watched.hasOwnProperty("HP1"), true);
            let actual = db.discardMovie("HP1");
            let expected = `You just threw away HP1!`
            assert.equal(actual, expected);
            assert.equal(db.movieCollection.length, 0);
            assert.equal(db.watched.hasOwnProperty("HP1"), false);
        });
        it("throws error", function(){
            let db = new ChristmasMovies();
            db.buyMovie("HP1", ["Daniel", "Rupert", "Emma"]);
            let actual = () => {
                db.discardMovie("HP1");
            };
            let expected = `HP1 is not watched!`;
            assert.throw(actual, expected);
            actual = ()=>{
                db.discardMovie("HP2");
            }
            expected = `HP2 is not at your collection!`;
            assert.throw(actual, expected);
        })
    });
    describe("Watch Movie tests", function(){
        it("Works correctly", function(){
            let db = new ChristmasMovies();
            db.buyMovie("HP1", ["Dan", "Rup", "Emma"]);
            db.watchMovie("HP1");
            let actual = db.watched["HP1"];
            assert.deepEqual(actual,1);
            db.watchMovie("HP1");
            db.watchMovie("HP1");
            actual = db.watched["HP1"];
            assert.deepEqual(actual, 3);
        });
        it("throws error", function(){
            let db = new ChristmasMovies();
            db.buyMovie("HP1", ["Dan", "Rup", "Emma"]);
            let actual = () =>{
                db.watchMovie("HP2");
            }
            let expected = "No such movie in your collection!";
            assert.throw(actual, expected);
        })
    });
    describe("Favorite Movie tests", function(){
        it("Works correctly", function(){
            let db = new ChristmasMovies();
            db.buyMovie("HP1", ["Dan", "Rup", "Emma"]);
            db.buyMovie("HP2", ["Daniel", "Rupert", "Emma"]);
            db.watchMovie("HP1");
            db.watchMovie("HP1");
            db.watchMovie("HP1");
            db.watchMovie("HP2");
            let expected = "Your favourite movie is HP1 and you have watched it 3 times!";
            let actual = db.favouriteMovie();
            assert.equal(actual,expected);
        });
        it("throws error", function(){
            let db = new ChristmasMovies();
            let expected = "You have not watched a movie yet this year!";
            let actual = () => {
                db.favouriteMovie();
            }
            assert.throw(actual, expected);
        });
    });
    describe("Most Starred Actor tests", function(){
        it("Throws error", function(){
            let db = new ChristmasMovies();
            let expected = "You have not watched a movie yet this year!";
            let actual = () => {
                db.mostStarredActor();
            }
            assert.throw(actual, expected);
        });
        it("Works correctly", function(){
            let db = new ChristmasMovies();
            db.buyMovie("HP1", ["Emma", "Dan", "Rup"]);
            db.buyMovie("HP2", ["Emma"]);
            db.watchMovie("HP1");
            db.watchMovie("HP2");
            let actual = db.mostStarredActor();
            let expected = "The most starred actor is Emma and starred in 2 movies!";
            assert.equal(actual, expected);
        });
    });
});