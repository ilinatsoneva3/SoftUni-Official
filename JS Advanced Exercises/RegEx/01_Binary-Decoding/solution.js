function solve() {
	let input = document.getElementById("input").value;

	let sum = calculateSum(input);

	input = trimInput(input, sum);

	let arr = input.match(/\d{1,8}/g);
	
	let result = ""

	for (const line of arr) {
		let newChar =  String.fromCharCode(parseInt(line, 2).toString(10));
		let regEx = /[a-zA-Z ]+/gm;
		if(regEx.exec(newChar)){
			result+=newChar;
		}
	};

	document.getElementById("resultOutput").innerHTML = result;

	function trimInput(string, num) {
		string = string.slice(num);
		string = string.slice(0, -num);
		return string;
	};

	function calculateSum(input) {
		while(input > 9){
			input = returnSum(input);
		}		
		return input;
	};

	function returnSum(input) {
		return Array.from(input.toString()).map(Number).reduce((a, b) => a + b, 0);
	};
}