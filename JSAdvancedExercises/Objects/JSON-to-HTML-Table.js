function solve(input) {
    let data = JSON.parse(input);
    let result = [];
    result.push('<table>');

    let headers = [];
    for (let key in data[0]) {
        headers.push(escapeHTML(key));
    }

    result.push(createHeader(headers));

    data.forEach(obj => result.push(createRow(obj)));
    result.push("</table>");

    function createHeader(arr = []) {
        let result = "   <tr>";
        Object.keys(arr).forEach(x => result += `<th>${escapeHTML(String(arr[x]))}</th>`);
        result += "</tr>";
        return result;
    }

    function createRow(obj) {
        let string = "   <tr>";
        Object.values(obj).forEach(x => string += `<td>${escapeHTML(String(x))}</td>`);
        string += "</tr>";
        return string;
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