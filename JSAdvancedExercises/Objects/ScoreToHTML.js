function solve(input) {
    let arr = JSON.parse(input);
    let result = ['<table>'];
    result.push('  <tr><th>name</th><th>score</th></tr>');
    arr.forEach((obj) => result.push(valueRows(obj)));
    result.push('</table>');


    function valueRows(obj) {
        let name = escapeHTML(obj['name']);
        let result = '   <tr><td>' + name + '</td><td>' + Number(obj['score']) + '</td></tr>';
        return result;
    }

    function escapeHTML(value) {
        return value
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;");
    }

    console.log(result.join('\n'));
}