$(document).ready(function () {
    $("#InvoiceDate").datepicker().datepicker("setDate", new Date());
    $("#SampleReceiveDate").datepicker().datepicker("setDate", new Date());
    $("#ReportDeliveryDate").datepicker().datepicker("setDate", new Date());

    $("#SampleReceiveTime").timepicker({ 'scrollDefault': 'now' });
    $("#ReportDeliveryTime").timepicker({ 'scrollDefault': 'now' });
    
    document.getElementById("TotalPayable").readOnly = true;
    document.getElementById("TotalBill").readOnly = true;
   
    $("#Discount").change(function () {
        var TotalBill = $("#TotalBill").val();
        var Discount = $("#Discount").val();
        var TotalPayable = TotalBill - ((TotalBill * Discount) / 100);
            $("#TotalPayable").val(TotalPayable);

        });
});