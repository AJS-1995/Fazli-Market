Step();

function Step() {

    const exchanges = document.querySelectorAll('input[name="Types"]');

    for(const exchange of exchanges)
    {
        if (exchange.value =="InOutInventory")
        {
            if (exchange.checked) 
            {
                $("#CreateInOutInventory").show();
                $("#CreateExpenses").hide();
                $("#ShopRentReceipts").hide();
                break;
            }
        }
        if (exchange.value =="Expenses")
        {
            if (exchange.checked) 
            {
                $("#CreateExpenses").show();
                $("#CreateInOutInventory").hide();
                $("#ShopRentReceipts").hide();
                break;
            }
        }
        if (exchange.value =="RentReceipts")
        {
            if (exchange.checked) 
            {
                $("#ShopRentReceipts").show();
                $("#CreateInOutInventory").hide();
                $("#CreateExpenses").hide();
                break;
            }
        }
    }
}