const StringBuilder = require('./StringBuilder');

let expect = require("chai").expect;
let assert = require("chai").assert;

describe("Test Stringbuilder class", function () {
    it("Test the methods of StringBuilder", function () {
        assert.isFunction(StringBuilder.prototype.append, "Append is not a function");
        assert.isFunction(StringBuilder.prototype.insertAt, "InsertAt is not a function");
        assert.isFunction(StringBuilder.prototype.prepend, "Prepend is not a function");
        assert.isFunction(StringBuilder.prototype.remove, "Remove is not a function");
        assert.isFunction(StringBuilder.prototype.toString, "ToString is not a function");
    })
    it("Correctly instantion SB with a string value", function () {
        let expected = new StringBuilder("test");
        assert.instanceOf(expected, StringBuilder, "Expected an instantion with a passed argument");
    });
    it("Correctly instantion SB with a string value", function () {
        let expected = new StringBuilder();
        assert.instanceOf(expected, StringBuilder, "Expected an instantion without an argument");
    });
    it("String array property contains an array of chars", function () {
        let sb = new StringBuilder();
        sb.append("Test");
        assert.isArray(sb._stringArray);
        assert.lengthOf(sb._stringArray, 4, "Expected append to create a string array");
    });
    it("Append adds text at the end of the StringBuilder", function () {
        let expected = ["a", "b", "c", "d"];
        let sb = new StringBuilder("ab");
        assert.deepEqual(sb.append("cd"),undefined);
        assert.deepEqual(sb._stringArray, expected, "Length does not match");
    });
    it("Append throws an error if argument is not a string", function () {
        let actualResult = () =>  {
            let sb = new StringBuilder("test");
            sb.append(5);
        };
        let expectedResult = "Argument must be string";
        assert.throw(actualResult, expectedResult);
    });
    it("Prepend adds text at the beginning of the Stringbuilder", function () {
        let sb = new StringBuilder("cd");
        sb.prepend("ab");
        expect(sb._stringArray[0]).to.be.deep.equal("a");
    });
    it("Prepend throws an error if argument is not a string", function () {
        let actualResult = () => {
            let sb = new StringBuilder("test");
            sb.prepend(5);
        };
        let expectedResult = "Argument must be string";
        assert.throw(actualResult, expectedResult);
    });
    it("Insert at works correctly", function () {
        let sb = new StringBuilder("abde");
        sb.insertAt("c", 2);
        assert.equal(sb._stringArray[2], "c", "Expected c to be inserted at 2 index");
        assert.deepEqual(sb._stringArray,['a','b','c','d','e']);
        sb.insertAt("fg",6);
        assert.deepEqual(sb._stringArray,['a','b','c','d','e','f','g'])
    });
    it("Insert throws error when argument is not a string", function () {
        let actualResult = () => {
            let sb = new StringBuilder("test");
            sb.insertAt(5, 1);
        };
        let expectedResult = "Argument must be string";
        assert.throw(actualResult, expectedResult);
    });    
    it("Removes works correctly", function () {
        let sb = new StringBuilder("abcd");        
        assert.equal(sb.remove(1, 1), undefined);
        assert.deepEqual(sb._stringArray, ['a', 'c', 'd'], "Expected to remove 1 element");
        sb.remove(1,5);
        assert.deepEqual(sb._stringArray,['a']);
    });
    it("to string", function () {
        let expected = "abcd";
        let sb = new StringBuilder("abcd");
        assert.equal(sb.toString(), expected);
    });
});