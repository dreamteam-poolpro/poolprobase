(function () {
    $(function () {
        console.log("details.js loaded");

        var _roleService = abp.services.app.workOrder;
        var _$modal = $('#AddLineItemModal');
        var _$form = $('form[name=AddLineItemForm]');

        _$form.validate({
        });

        //attach refreshrolelist() to the refresh button
        $('#RefreshButton').click(function () {
            refreshRoleList();
        });

        //to pop up the _EditLineItemsModal
        $('.add-lineitem').click(function (e) {
            console.log("somebody clicked a button of class add-lineitem");        
            var id = $(this).attr("data-role-id");
            console.log("id: " + id);
            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'WorkOrders/AddLineItemModal/' + id,
                type: 'POST',
                contentType: 'application/html',
                success: function(content) {
                    $('#AddLineItemModal div.modal-content').html(content);
                    console.log("ajax call was successful");
                },
                error: function (e) { }
            });
        });        

        function refreshRoleList() {
            location.reload(true);
        };
    });
})();