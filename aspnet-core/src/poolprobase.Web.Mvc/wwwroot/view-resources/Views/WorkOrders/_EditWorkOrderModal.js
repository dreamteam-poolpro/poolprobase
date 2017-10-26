(function ($) {

    var _roleService = abp.services.app.role;
    var _$modal = $('#EditWorkModelModal');
    var _$form = $('form[name=WorkOrderEditForm]');

    function save() {
        console.log("somebody clicked the save button");
        if (!_$form.valid()) {
            return;
        }
        var id = $('#WorkOrderId').val();
        var CustomerId = $('#CustomerId').text();
        var ServiceTechId = $("#ServiceTechId").val();
        console.log("workorderid: " + WorkOrderId);
        console.log("customerid: " + CustomerId);
        console.log("servicetechid: " + ServiceTechId);

        abp.ui.setBusy(_$form);
        $.post("/WorkOrders/Edit/", { WorkOrderID: id, CustomerID: CustomerId, ServiceTechID: ServiceTechId }).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited role!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
        //$.post("/WorkOrders/Edit/" + WorkOrderId + "?CustomerID=" + CustomerId + "&ServiceID=" + ServiceTechId).done(refreshWorkOrderList);
        
        //_$modal.modal('hide');
        //location.reload(true);
        //WorkOrderID,CustomerID,ServiceTechID
    };

    function refreshWorkOrderList() {
        location.reolad(true); //reload the page to reflect the changes
    }

    //handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    //$.AdminBSB.input.active(_$form);


    //_$modal.on('shown.bs.modal', function () {
    //    _$form.find('input[type=text]:first').focus();
    //});

})(jQuery);