const PaymentPackage = require("./PaymentPackage");

let assert = require("chai").assert;

describe("Test PaymentPackage", function () {
    it("Test successfull instance creation with two param", function () {
        let result = new PaymentPackage("Test", 10);
        assert.equal(result.name, "Test");
        assert.equal(result.value, 10);
        assert.equal(result.VAT, 20);
        assert.equal(result.active, true);
        result.name = "Test2";
        assert.equal(result.name, "Test2");
        result.value = 20;
        assert.equal(result.value, 20);
    });
    it("Instance creation exceptions", function () {
        let error = () => {
            new PaymentPackage("Test");
        }
        assert.throw(error);
        error = () => {
            new PaymentPackage(10);
        };
        assert.throw(error);
        error = () => {
            new PaymentPackage(0, 10);
        };
        assert.throw(error);
        error = () => {
            new PaymentPackage('', 10);
        };
        assert.throw(error);
        error = () => {
            new PaymentPackage("Test", -1);
        };
        assert.throw(error);
        error = () => {
            new PaymentPackage("Test", "Test2");
        };
        assert.throw(error);
    });
    it("Test VAT property", function () {
        let result = new PaymentPackage("Test", 10);
        result.VAT = 20;
        assert.equal(result.VAT, 20);
        result.VAT = 10;
        assert.equal(result.VAT, 10);
    });
    it("Random VAT test", function(){
        let result = new PaymentPackage("Test", 10);
        result.VAT=0;
        assert.equal(result.value,10);
        assert.equal(result.VAT, 0);
        result.value=0;
        result.VAT=10;
        assert.equal(result.value,0);
        assert.equal(result.VAT,10);
    })
    it("Test VAT with errors", function () {
        let result = new PaymentPackage("Test", 10);
        let error = () => {
            result.VAT = "Test";
        };
        assert.throw(error);
        error = () => {
            result.VAT = -1;
        };
        assert.throw(error);
        error = () => {
            result.VAT = null;
        };
        assert.throw(error);
    });
    it("Test Active property", function () {
        let result = new PaymentPackage("Test", 10);
        assert.equal(result.active, true);
        result.active = false;
        assert.equal(result.active, false);
    });
    it("Test Active with errors", function () {
        let result = new PaymentPackage("Test", 10);
        let error = () => {
            result.active = "";
        };
        assert.throw(error);
        error = () => {
            result.active = 5;
        };
        assert.throw(error);
        error = () => {
            result.active = null;
        };
        assert.throw(error);
    });
    it("Test ToString", function () {
        let package = new PaymentPackage("Test", 1500);
        let result = [`Package: Test`,
            `- Value (excl. VAT): 1500`,
            `- Value (VAT 20%): 1800`
        ].join('\n');
        let actual = package.toString();
        assert.equal(actual, result);
        result = [`Package: Test (inactive)`,
            `- Value (excl. VAT): 1500`,
            `- Value (VAT 20%): 1800`
        ].join('\n');
        package.active = false;
        actual = package.toString();
        assert.equal(actual, result);
    });
});