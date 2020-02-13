const lookupChar = require("./CharLookup");

let expect = require("chai").expect;
let assert = require("chai").assert;

describe("Test char look up function", function(){
    it("To return char index correctly", function(){
        let expectedResult = "G";
        let actualResult = lookupChar("George", 0);
        assert.equal(actualResult, expectedResult);
    });
    it("To return char index correctly", function(){
        let expectedResult = "r";
        let actualResult = lookupChar("George", 3);
        assert.equal(actualResult, expectedResult);
    });
    it("To return undefined when parameter is not a string", function(){
        let expectedResult = undefined;
        let actualResult = lookupChar(569, 0);
        assert.equal(actualResult, expectedResult, "Expected a string value");
    });
    it("To return undefined when index is floating number", function(){
        let expectedResult = undefined;
        let actualResult = lookupChar("George", 3.14);
        assert.equal(actualResult, expectedResult, "Expected an integer for index");
    });
    it("To return undefined when index is string", function(){
        let expectedResult = undefined;
        let actualResult = lookupChar("George", "G");
        assert.equal(actualResult, expectedResult, "Expected a number for index");
    });
    it("To return error message when index is greater or equal to length", function(){
        let expectedResult = "Incorrect index";
        let actualResult = lookupChar("George", 6);
        assert.equal(actualResult, expectedResult, "Expected a an integer for index");
    });
    it("To return error message when index is greater or equal to length", function(){
        let expectedResult = "Incorrect index";
        let actualResult = lookupChar("George", 99);
        assert.equal(actualResult, expectedResult, "Expected a valid index");
    });
    it("To return error message when index is smaller than 0", function(){
        let expectedResult = "Incorrect index";
        let actualResult = lookupChar("George", -1);
        assert.equal(actualResult, expectedResult, "Expected a positive number for index");
    });
});