let Parser = require("./solution.js");
let assert = require("chai").assert;

describe("MyTests", () => {
  it("constructor", function() {
    let parser = new Parser('[ {"Nancy":"architect"}]');
    assert.instanceOf(parser, Parser);
    assert.deepEqual(parser._log, []);
    assert.isFunction(parser._addToLog);
    assert.isFunction(parser._addToLogInitial);
    assert.isFunction(parser.print);
    assert.isFunction(parser.addEntries);
    assert.isFunction(parser.removeEntry);
  });
  it("get data", function() {
    let parser = new Parser('[ {"Nancy":"architect"}]');
    let result = parser.data;
    let expected = JSON.parse('[ {"Nancy":"architect"}]');
    assert.deepEqual(result, expected);
    assert.equal(parser._log[0], "0: getData");
    assert.deepEqual(JSON.stringify(result), '[{"Nancy":"architect"}]');
  });
  it("print", function() {
    let parser = new Parser('[ {"Nancy":"architect"}]');
    let result = parser.print();
    let expected = `id|name|position\n`;
    expected += `0|Nancy|architect`;
    assert.deepEqual(result, expected);
    assert.equal(parser._log.length, 1);
    assert.equal(parser._log[0], "0: print");
  });
  it("addEnties", function() {
    let parser = new Parser('[ {"Nancy":"architect"}]');
    let result = parser.addEntries("Steven:tech-support Edd:administrator");
    assert.equal(result, "Entries added!");
    assert.equal(parser._log.length, 1);
    assert.equal(parser._log[0], "0: addEntries");
    assert.equal(parser._data.length, 3);
  });
  it("removeEntry", function() {
    let parser = new Parser('[ {"Nancy":"architect"}]');
    let result = parser.removeEntry("Nancy");
    assert.equal(result, "Removed correctly!");
    assert.equal(parser._log.length, 1);
    assert.equal(parser._log[0], "0: removeEntry");
    assert.deepEqual(parser._data[0].deleted, true);
  });
  it("removeEnty error", function() {
    let parser = new Parser('[ {"Nancy":"architect"}]');
    let error = () => {
      parser.removeEntry("Error");
    };
    assert.throw(error, "There is no such entry!");
  });
});
