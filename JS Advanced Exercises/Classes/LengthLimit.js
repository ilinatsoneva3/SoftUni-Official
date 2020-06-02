class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength - length < 0 ? this.innerLength = 0 : this.innerLength -= length;
    }

    toString() {
        return this.innerLength === 0 ? "..." : 
        this.innerString.length > this.innerLength ? this.innerString.slice(0, -this.innerLength)+"..." : this.innerString;
    }
}