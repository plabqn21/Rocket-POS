$(document).ready(function () {
    $('#MainMenuId').change(function () {
        $('#SubMenuId option').remove();
        $.getJSON('/Permissions/GetSubMenues', { MainMenuId: $('#MainMenuId').val() }, function (data) {
            $('#SubMenuId').append(new Option("Select", ""));


            $.each(data, function () {
                $('#SubMenuId').append('<option value=' + this.Id + '>' + this.SubMenuName + '</option>');
            });
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Error!');
        });
    });


    $('#myTable').DataTable();
})