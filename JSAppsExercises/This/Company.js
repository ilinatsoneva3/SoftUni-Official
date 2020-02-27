class Company {
  constructor() {
    this.departments = [];
  }

  addEmployee(username, salary, position, department) {
    if (!username || (!salary && salary !== 0) || !position || !department) {
      throw new Error("Invalid input!");
    }

    if (salary < 0) {
      throw new Error("Invalid input!");
    }

    let existingDepartment = this.departments.find(d => d.name === department);

    if (!existingDepartment) {
      existingDepartment = {
        name: department,
        employees: [],
        averageSalary: function() {
          return (
            this.employees.reduce((curr, next) => curr + next.salary, 0) /
            this.employees.length
          );
        }
      };
    }

    existingDepartment.employees.push({ username, salary, position });
    this.departments.push(existingDepartment);
    return `New employee is hired. Name: ${username}. Position: ${position}`;
  }

  bestDepartment() {
    let [best] = [...this.departments].sort((a, b) => {
      return a.averageSalary() - b.averageSalary;
    });

    let result = `Best Department is: ${best.name}\n`;
    result += `Average salary: ${best.averageSalary().toFixed(2)}\n`;
    result += [...best.employees]
      .sort(
        (a, b) => b.salary - a.salary || a.username.localeCompare(b.username)
      )
      .map(e => `${e.username} ${e.salary} ${e.position}`)
      .join("\n");

    return result.trim();
  }
}
