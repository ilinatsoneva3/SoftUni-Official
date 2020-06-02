const isOddOrEven = require("../oddOrEven.js");

let expect = require("chai").expect;
let assert = require("chai").assert;

describe("Test isOddEven function", function(){
    it("Return undefined", function(){
        let result = isOddOrEven(1);
        assert.equal(result,undefined);
    });
    it("Returns even when correct parameter is provided", function(){
        let result = isOddOrEven("22");
        assert.equal(result,"even");
    });
    it("Returns odd when correct parameter is provided", function(){
        let result = isOddOrEven("2");
        assert.equal(result, "odd");
    })
});