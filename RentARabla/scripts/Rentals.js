
$(document).ready(function () {
    setupTypeSelection();
});


function setupTypeSelection() {
    $('#CarType').on('change', function () {
        var brandDropdown = $('#CarModel_CarBrand');
        var selectedValue = parseInt($(this).val());
        var url = '/rentals/selecttype?carType=' + selectedValue;

        $.ajax({
            url: url,
            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    brandDropdown.append('<option>'+ data[i] +'</option>')
                }
            }
        });
    });
}