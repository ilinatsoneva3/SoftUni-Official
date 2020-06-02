class Library {
    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: this.libraryName.length,
            special: this.libraryName.length * 2,
            vip: Number.MAX_SAFE_INTEGER
        }
    }

    subscribe(name, type) {
        if (!this.subscriptionTypes.hasOwnProperty(type)) {
            throw new Error(`The type ${type} is invalid`);
        }
        let subscriber = this.subscribers.find(s => s.name === name);
        if (subscriber === undefined) {
            subscriber = {
                name,
                type,
                books: []
            }
            this.subscribers.push(subscriber);
        } else {
            subscriber.type = type;
        }
        return subscriber;
    }

    unsubscribe(name) {
        let subscriber = this.subscribers.find(s => s.name === name);
        if (subscriber === undefined) {
            throw new Error(`There is no such subscriber as ${name}`);
        }
        let index = this.subscribers.indexOf(subscriber);
        this.subscribers.splice(index, 1);
        return this.subscribers;
    }

    receiveBook(subscriberName, bookTitle, bookAuthor) {
        let subscriber = this.subscribers.find(s => s.name === subscriberName);
        if (subscriber === undefined) {
            throw new Error(`There is no such subscriber as ${subscriberName}`);
        }

        let numberOfAllowedBooks = this.subscriptionTypes[subscriber.type];

        if (numberOfAllowedBooks > subscriber.books.length) {
            let book = {
                title: bookTitle,
                author: bookAuthor
            }
            subscriber.books.push(book);
            return subscriber;
        } else{
            throw new Error(`You have reached your subscription limit ${numberOfAllowedBooks}!`);
        }
    }

    showInfo(){
        let result = '';
        if(this.subscribers.length===0){
            return `${this.libraryName} has no information about any subscribers`
        }

        for (const subscriber of this.subscribers) {
            result+=`Subscriber: ${subscriber.name}, Type: ${subscriber.type}\n`;

            let boooks = subscriber.books.map(x=>`${x.title} by ${x.author}`);
            result+=`Received books: ${boooks.join(", ")}\n`;
        }

        return result;
    }
}

let lib = new Library('Lib');

lib.subscribe('Peter', 'normal');
lib.subscribe('John', 'special');

lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
lib.receiveBook('Peter', 'Lord of the rings', 'J. R. R. Tolkien');
lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling');

console.log(lib.showInfo());
