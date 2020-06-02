let SkiResort = require('./solution');

let assert = require("chai").assert;

describe('SkiResort', function () {
    it("constructor", function () {
        let testObj = new SkiResort("test");
        assert.equal(testObj.name, "test");
        assert.equal(testObj.voters, 0);
        assert.deepEqual(testObj.hotels, []);
    });
    it("best hotel", function () {
        let testObj = new SkiResort("test");
        let actualResult = testObj.bestHotel;
        assert.equal(actualResult, "No votes yet");
    });
    it("build", function () {
        let test = new SkiResort("test");
        let result = test.build("Beach", 10);
        let expected = "Successfully built new hotel - Beach";
        assert.equal(result, expected);
        assert.equal(test.hotels.length, 1);
    });
    it("build throws error", function () {
        let test = new SkiResort("test");
        let error = () => {
            test.build("", 10);
        }
        assert.throw(error, "Invalid input");
        error = () => {
            test.build("Beach", 0);
        }
        assert.throw(error, "Invalid input");
    });
    it("book", function () {
        let test = new SkiResort("test");
        test.build("Beach", 10);
        let result = test.book("Beach", 5);
        assert.equal(result, "Successfully booked");
        assert.equal(test.hotels[0].beds, 5);
    });
    it("book errors", function () {
        let test = new SkiResort("test");
        test.build("Beach", 10);
        let error = () => {
            test.book("", 10);
        };
        assert.throw(error, "Invalid input");
        error = () => {
            test.book("Beach", 0);
        }
        assert.throw(error, "Invalid input");
        error = () => {
            test.book("Morena", 10);
        }
        assert.throw(error, "There is no such hotel");
        error = () => {
            test.book("Beach", 15);
        }
        assert.throw(error, "There is no free space");
    });
    it("leave", function () {
        let test = new SkiResort("test");
        test.build("Beach", 10);
        let result = test.leave("Beach", 5, 5);
        assert.equal(result, "5 people left Beach hotel");
        assert.equal(test.hotels[0].points,25);
        assert.equal(test.hotels[0].beds,15);
        assert.equal(test.voters,5);
    });
    it("leave errors", function(){
        let test = new SkiResort("test");
        test.build("Beach", 10);
        let error = ()=>{
            test.leave("", 10);
        }
        assert.throw(error, "Invalid input");
        error = () =>{
            test.leave("Beach", 0);
        }
        assert.throw(error, "Invalid input");
        error = () =>{
            test.leave("Morena", 10);
        }
        assert.throw(error,"There is no such hotel");
    });
    it("average grade", function(){
        let test = new SkiResort("test");
        test.build("Beach", 10);
        test.leave("Beach", 10, 10);
        let result = test.averageGrade();
        assert.equal(result, "Average grade: 10.00");
    });
    it("average grade errors", function(){
        let test = new SkiResort("test");
        test.build("Beach", 10);
        let result = test.averageGrade();
        assert.equal(result, "No votes yet");
    });
    it("best hotel", function(){
        let test = new SkiResort("test");
        test.build("Beach", 10);
        test.build("Morena", 100);
        test.leave("Beach", 2, 3);
        test.leave("Morena", 25, 10);
        let result = test.bestHotel;
        assert.equal(result, "Best hotel is Morena with grade 250. Available beds: 125")
    });
});
