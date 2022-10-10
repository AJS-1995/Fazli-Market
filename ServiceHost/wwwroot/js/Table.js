Result();

function Result() {

    var TotalAmountReceipt = 0;
    $("#AmountReceipttd").each(function(index,value){
        currentRow = parseFloat($(this).text());
        TotalAmountReceipt += currentRow
    });
    document.getElementById("AmountReceipt").value = TotalAmountReceipt;


    var TotalAmountSlavery = 0;
    $("#AmountSlaverytd").each(function(index,value){
      currentRow = parseFloat($(this).text());
      TotalAmountSlavery += currentRow
    });
    document.getElementById("AmountSlavery").value = TotalAmountSlavery;

    document.getElementById("Amount").value = TotalAmountReceipt - TotalAmountSlavery;
}