class Vacation {
  constructor(organizer, destination, budget) {
    this.organizer = organizer;
    this.destination = destination;
    this.budget = +budget;
    this.kids = {};
  }

  get numberOfChildren() {
    let count = 0;
    for (const grade in this.kids) {
      if (this.kids.hasOwnProperty(grade)) {
        count += this.kids[grade].length;
      }
    }
    return count;
  }

  registerChild(name, grade, budget) {
    if (budget < this.budget) {
      return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
    }
    if (!this.kids.hasOwnProperty(grade)) {
      this.kids[grade] = [];
    }
    let kid = this.kids[grade].find(x => x === `${name}-${budget}`);
    if (kid) {
      return `${name} is already in the list for this ${this.destination} vacation.`;
    }
    this.kids[grade].push(`${name}-${budget}`);
    return this.kids[grade];
  }

  removeChild(name, grade) {
    if (!this.kids.hasOwnProperty(grade)) {
      return `'We couldn't find ${name} in ${grade} grade.`;
    }

    let kid = this.kids[grade].find(x => x.startsWith(name));
    if (!kid) {
      return `'We couldn't find ${name} in ${grade} grade.`;
    }
    let index = this.kids[grade].findIndex(x => x.startsWith(name));
    this.kids[grade].splice(index, 1);
    return this.kids[grade];
  }

  toString() {
    if (this.numberOfChildren === 0) {
      return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`;
    }
    let result = `${this.organizer} will take ${this.numberOfChildren} children on trip to ${this.destination}\n`;

    for (const grade in this.kids) {
      if (this.kids.hasOwnProperty(grade)) {
        const kids = this.kids[grade];
        result += `Grade: ${grade}\n`;

        let count = 1;

        for (const kid of kids) {
          result += `${count++}. ${kid}\n`;
        }
      }
    }

    return result;
  }
}

let vacation = new Vacation("Miss. Elizabeth", "The bahamas", 400);

vacation.registerChild("Gosho", 12, 3400);
vacation.registerChild("Pesho", 12, 400);
vacation.registerChild("Pesho", 12, 400);
vacation.registerChild("Skaro", 11, 400);
vacation.registerChild("Gosho", 11, 3444);
console.log(vacation.getNumberOfChildren());
console.log(vacation.toString());
