(function () {
    $(function () {
        console.log("~/view-resources/Views/Customers/details.js loaded");

        var _roleService = abp.services.app.Customer;
        var _$modal = $('#AddWorkOrderModal');
        var _$form = $('#AddWorkOrderForm');

        _$form.validate({
        });

        //attach refreshWorkorderslist() to the refreshbutton
        $('#RefreshButton').click(function () {
            refreshWorkOrderList();
        });

        // to pop up the _AddWorkOrder modal
        $('.add-workorder').click(function (e) {
            console.log("somebody clicked a button of class add-workorder");
            var id = $(this).attr("data-customer-id");
            console.log("id: " + id);
            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Customers/AddWorkOrderModal/' + id,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {                    
                    $('#AddWorkOrderModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        function refreshWorkOrderList() {
            location.reload(true);
        };

    });
})();