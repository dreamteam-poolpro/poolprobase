(function () {
    $(function () {
        console.log("_AddLineItemModal.js loaded");
        //still dont know what this is for? DI maybe?
        var _roleService = abp.services.app.lineItem;    
        var _$modal = $('#AddLineItemModal');
        var _$form = $('form[name=AddLineItemForm')

        // pointo f reference for the line item model
        /*
            //primary key
           public int LineItemID { get; set; }

            //foreign key
            public int WordOrderID { get; set; }

            //data
            public string Description { get; set; }
            public string Units { get; set; }
            public double UnitCost { get; set; }
            public int Quantity { get; set; }

        */
        //define save function
        function save() {
            console.log("somebody clicked the save button")
            if (!_$form.valid()) {
                return;
            }
            var workorderid = $('#workorderidinput').val();
            var description = $('#descriptioninput').val();
            var quantity = $('#quantityinput').val();
            var units = $('#unitsinput').val();
            var unitcost = $('#unitcostinput').val();
            console.log("workorderid: " + workorderid);
            console.log("quantity: " + quantity);
            console.log("units: " + units);
            console.log("unit cost: " + unitcost);
            /*
            abp.ui.setBusy(_$form);
            $.post("/WorkOrders/AddLineItem/", { WorkOrderID: workorderid, Description: description, Units: units, UnitCost: unitcost, Quantity: quantity }).done(function () {
                _$modal.modal('hide');
                location.reload(true);
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
            */
        };

        //handle clicking the save button
        _$form.closest('div.modal-content').find(".save-button").click(function (e) {
            e.preventDefault();
            save();
        });

        //handle pressing the enter key
        _$form.find('input').on('keypress', function (e) {
            if (e.which === 13) {
                e.preventDefault();
                save();
            }
        });

        $.AdminBSB.input.activate(_$form);

        _$modal.on('shown.bs.modal', function () {
            _$form.find('input[type-text]:first').focus;
        });

    });
})();