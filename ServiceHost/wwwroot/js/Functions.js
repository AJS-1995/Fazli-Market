total();
function total() {
    const rest = document.getElementById("Shop_Rest").value;
    const amount = document.getElementById("Shop_Amount").value;
    var total = rest - amount;
    console.log(total);
    if (total == 0) {
        document.getElementById("Shop_Total").value = 0;
    } else {
        document.getElementById("Shop_Total").value = total;
    }
}