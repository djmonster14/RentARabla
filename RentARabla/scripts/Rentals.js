
$(document).ready(function () {
    setupTypeSelection();
});


function setupTypeSelection() {
    $('#Type').on('change', function () {
        var brandDropdown = $('#Brand');
        var selectedValue = $(this).val();
        var value = $('#Type').find('option[value=' + selectedValue + ']').text();
        var url = '/rentals/selecttype?carType=' + value;

        $.ajax({
            url: url,
            success: function (data) {
                brandDropdown.empty();
                for (var i = 0; i < data.length; i++) {
                    brandDropdown.append('<option>'+ data[i] +'</option>')
                }
            }
        });
    });
}