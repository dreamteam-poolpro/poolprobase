// this is for workorders/index

(function () {
    $(function () {
        console.log("index.js loaded")
        //not sure what this is and don't see where' it's being used
        var _roleService = abp.services.app.serviceTech;

        // the modal that's defined in the view's code'
        var _$modal = $('#WorkOrderCreateModal');

        //I see where this is used but not exactly sure what it does
        var _$form = _$modal.find('form');

        _$form.validate({
        });

        //attach refresh tole list to the refresh link
        $('#RefreshButton').click(function () {
            console.log("somebody clicked the refresh button");
            refreshRoleList();
        });

        //grab appropriate for and attach the delete function to the
        //delete link
        $('.delete-role').click(function () {
            console.log("somebody clicked the delete link");
            //grab workorderid
            var WorkOrderId = $(this).attr('data-role-id');
            //grab customer name
            var CustomerName = $(this).attr('data-role-name');
            //delete the work order record
            deleteWorkOrder(WorkOrderId, CustomerName);

        });

        //create and attach the edit workOrder function
        $('.edit-role').click(function (e) {
            console.log("sombody clicked the edit link");            
            //grab the id of the work order to be edited
            var id = $(this).attr("data-role-id");
            console.log("for id: " + id);
            // not sure what this does, prevent default value assignment?
            // prevent defautl error message?
            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'WorkOrders/EditWorkOrderModal/' + id,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#WorkOrderEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });

        });

        //define delete customer function
        function deleteWorkOrder(WorkOrderId, CustomerName) {
            //assigning the parameter so we can use it indirectly
            var recordToDelete = WorkOrderId;
            //from the abp js api?
            abp.message.confirm(
                //the message to display in the confirmation popup
                "Are you sure you want to Delete Work Order #: " +WorkOrderId 
                +"From " +CustomerName +"'s account?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        //delete if they actually click the confirmation button
                        //by posting to the controllers delete action
                        $.post("/WorkOrders/Delete", { id: recordToDelete }, DeleteSuccessful);
                    }
                }
            );
        };


        //define refreshRoleList();
        //reloads the page after creating, editing, or deleting any work orders
        function refreshRoleList() {
            location.reload(true);
        };

        //defint DeleteSuccessful();
        //refreshes the page after successfully deleting a work order record
        function DeleteSuccessful() {
            refreshRoleList();
        };

    });
})();