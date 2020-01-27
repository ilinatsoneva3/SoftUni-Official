function solve(arr=[]){
    let result = "";
    result+="<table>"+"\n";

    for(let item of arr){
       let newItem = JSON.parse(item);
       result+="	<tr>"+"\n";
       result+=`		<td>${escapeHTML(newItem.name)}</td>` + "\n" 
       + `		<td>${escapeHTML(newItem.position)}</td>`+"\n"
       +`		<td>${Number(newItem.salary)}</td>`;
       result+="\n" + "	</tr>"+"\n";
    }

    result+="</table>";

    function escapeHTML(value) {
        return value
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;");
    }

    console.log(result);
}

solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
);