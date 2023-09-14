const CouponInputs = document.querySelectorAll("input[AdditionalValues]");

const Persent = document.getElementById('Percent');
const Nominal = document.getElementById("Nominal");
let base_nominal = 1000;

let onValueInput = function (e) {
    let input = e.target,
        inputValue = input.value;
    if (!Nominal.value) {
        Nominal.value = base_nominal;
    }

    
    Persent.value = String(parseFloat(inputValue.replace(",", ".") * 2 / Nominal.value)).replace(".", ",");
    console.log('inputValue', inputValue);
}

for (var i = 0; i < CouponInputs.length; i++) {
    let input = CouponInputs[i];
    input.addEventListener("input", onValueInput);
}
