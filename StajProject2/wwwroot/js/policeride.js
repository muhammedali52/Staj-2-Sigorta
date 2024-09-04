$(function () {
    // Marka kodu değiştiğinde çağrılan fonksiyon
    $('#VehicleBrandCode').on('input', function () {
        var brandCode = $(this).val();
        if (brandCode) {
            $.ajax({
                url: '@Url.Action("GetVehicleInfo", "Police")', // Controller'daki GetVehicleInfo metodunun URL'si
                type: 'GET',
                data: { vehicleBrandCode: brandCode },
                success: function (response) {
                    if (response) {
                        $('#VehicleBrand').val(response.Brand);
                        $('#VehicleModel').val(response.Model);
                    } else {
                        $('#VehicleBrand').val('');
                        $('#VehicleModel').val('');
                    }
                },
                error: function () {
                    alert('Araç bilgileri yüklenirken hata oluştu.');
                }
            });
        } else {
            $('#VehicleBrand').val('');
            $('#VehicleModel').val('');
        }
    });
});