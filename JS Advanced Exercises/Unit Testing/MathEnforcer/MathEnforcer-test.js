const mathEnforcer = require('./MathEnforcer');

let assert = require("chai").assert;

describe("Test mathEnforcer function", function(){
    it("Add5 to return undefined when argument is not a number", function() {
        let actual = mathEnforcer.addFive("2");
        assert.equal(actual, undefined, "Expected undefined when argument is not a number");
    });
    it("Add5 adds five to the positive number passed as an argument", function(){
        let expected = 10;
        let actual = mathEnforcer.addFive(5);
        assert.equal(actual, expected, "Expected to add 5 successfully");
    });
    it("Add5 adds five to the negative number passed as an argument", function(){
        let expected = 0;
        let actual = mathEnforcer.addFive(-5);
        assert.equal(actual, expected, "Expected to add 5 successfully");
    });
    it("Add5 adds five to the floating number passed as an argument", function(){
        let expected = 7.5;
        let actual = mathEnforcer.addFive(2.5);
        assert.equal(actual, expected, "Expected to add 5 successfully");
    });
    it("Subtract10 to return undefined when argument is not a number", function() {
        let actual = mathEnforcer.subtractTen("2");
        assert.equal(actual, undefined, "Expected undefined when argument is not a number");
    });
    it("Subtract10 subtracts 10 from the positive number passed as an argument", function(){
        let expected = 10;
        let actual = mathEnforcer.subtractTen(20);
        assert.equal(actual, expected, "Expected to subtract ten successfully");
    });
    it("Subtract10 subtracts 10 from the negative number passed as an argument", function(){
        let expected = -20;
        let actual = mathEnforcer.subtractTen(-10);
        assert.equal(actual, expected, "Expected to subtract ten successfully");
    });
    it("Subtract10 subtracts 10 from the floating number passed as an argument", function(){
        let expected = -5.5;
        let actual = mathEnforcer.subtractTen(4.5);
        assert.closeTo(actual, expected, 0.01, "Expected to subtract ten successfully");
    });
    it("Sum returns undefined when first argument is string", function(){
        let actual = mathEnforcer.sum("boom", 5);
        assert.equal(actual, undefined, "Expected undefined when first argument is not a number");
    });
    it("Sum returns undefined when second argument is string", function(){
        let actual = mathEnforcer.sum(5, "boom");
        assert.equal(actual, undefined, "Expected undefined when second argument is not a number");
    });
    it("Sum works correctly for two positive numbers", function(){
        let expected = 10;
        let actual = mathEnforcer.sum(5,5);
        assert.equal(actual, expected, "Expected 5 + 5 to equal 10");
    });
    it("Sum works correctly for two negative numbers", function(){
        let expected = -10;
        let actual = mathEnforcer.sum(-5,-5);
        assert.equal(actual, expected, "Expected -5 + -5 to equal -10");
    });
    it("Sum works correctly for two floating numbers", function(){
        let expected = 2.4;
        let actual = mathEnforcer.sum(1.2,1.2);
        assert.closeTo(actual, expected, 0.01, "Expected 1.2+1.2 to equal 2.4");
    });
});