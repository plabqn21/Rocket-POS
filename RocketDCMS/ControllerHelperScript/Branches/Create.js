$(document).ready(function () {

    $('#OpeningDate').datepicker().datepicker("setDate", new Date());
    $('#CloseDate').datepicker();

    $('#myTable').DataTable();

})