function solve(tickets, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let resultUnsorted = [];

    for (const data of tickets) {
        let [destination, price, status] = data.split('|');
        price = +price;
        resultUnsorted.push(new Ticket(destination, price, status));
    }

    let resultSorted = [];

    switch (criteria) {
        case "destination": resultSorted = resultUnsorted.sort((a,b) => { return a.destination.localeCompare(b.destination)}); break;
        case "status": resultSorted = resultUnsorted.sort((a,b) => { return a.status.localeCompare(b.status)}); break;
        case "price": resultSorted = resultUnsorted.sort((a,b) => { return a.price - b.price}); break;
    }

    return resultSorted;
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));