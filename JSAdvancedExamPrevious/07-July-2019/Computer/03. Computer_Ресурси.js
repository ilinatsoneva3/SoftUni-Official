class Computer {
    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory = ramMemory;
        this.cpuGHz = cpuGHz;
        this.hddMemory = hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];
    }

    installAProgram(name, requiredSpace) {
        if (this.hddMemory < requiredSpace) {
            throw new Error(`There is not enough space on the hard drive`);
        }        
        let program = {
            name,
            requiredSpace
        }
        if(this.installedPrograms.find(p=>p.name===name)===undefined){
            this.installedPrograms.push(program);
        }       
        this.hddMemory -= requiredSpace;
        return this.program;
    }

    uninstallAProgram(name) {
        let program = this.installedPrograms.find(p => p.name === name);
        if (program === undefined) {
            throw new Error(`Control panel is not responding`);
        }
        let index = this.installedPrograms.indexOf(program);
        this.installedPrograms.splice(index, 1);
        this.hddMemory += program.requiredSpace;
        return this.installedPrograms;
    }

    openAProgram(name) {
        let program = this.installedPrograms.find(p => p.name === name);
        if (program === undefined) {
            throw new Error(`The ${name} is not recognized`);
        }
        if(this.taskManager.find(p=>p.name===name)){
            throw new Error(`The ${name} is already open`);
        }
        let requiredRAM = (program.requiredSpace / this.ramMemory) * 1.5;
        let requiredCPU = ((program.requiredSpace / this.cpuGHz) / 500) * 1.5;

        let allRequiredRAM = this.taskManager.reduce((a, b)=>a.ramUsage+b.ramUsage,0);
        let allRequiredCPU = this.taskManager.reduce((a, b)=>a.cpuUsage+b.cpuUsage,0);

        if (requiredRAM +allRequiredRAM >= 100) {
            throw new Error(`${program.name} caused out of memory exception`);
        }
        if (requiredCPU + allRequiredCPU >= 100) {
            throw new Error(`${program.name} caused out of cpu exception`);
        }
        let obj = {
            name,
            ramUsage: requiredRAM,
            cpuUsage: requiredCPU
        }
        this.taskManager.push(obj);
        return obj;
    }

    taskManagerView() {
        if (this.taskManager.length === 0) {
            return `All running smooth so far`;
        }
        let result = '';
        for (const program of this.taskManager) {
            result += `Name - ${program.name} | Usage - CPU: ${(this.taskManager.filter(x=>x.name===program.name)[0].cpuUsage).toFixed(0)}%, RAM: ${(this.taskManager.filter(x=>x.name===program.name)[0].ramUsage).toFixed(0)}%\n`;
        }

        return result.trim();
    }
}

let computer = new Computer(4096, 7.5, 250000);

computer.installAProgram('Word', 7300);
computer.installAProgram('Excel', 10240);
computer.installAProgram('PowerPoint', 12288);
computer.installAProgram('Solitare', 1500);

computer.openAProgram('Word');
computer.openAProgram('Excel');
computer.openAProgram('PowerPoint');
computer.openAProgram('Solitare');

console.log(computer.taskManagerView());

