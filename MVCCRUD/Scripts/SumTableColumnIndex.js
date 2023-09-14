const table = document.getElementById("MainTable");
const totalInput = document.getElementById("Result");

var total = "0"
for (let i = 1; i < table.rows.length; i++) {
    total = (parseFloat(total.replace(",", ".")) + parseFloat(table.rows[i].innerText.trim().split("\t")[1].replace(',', "."))).toFixed(2);
}
totalInput.textContent += total.replace(".", ",");

x = table.rows[2].innerText.trim().split("\t")[1];