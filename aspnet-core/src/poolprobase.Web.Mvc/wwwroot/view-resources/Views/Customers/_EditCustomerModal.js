(function ($) {

    var _roleService = abp.services.app.role;
    var _$modal = $('#EditCustomerModal');
    var _$form = $('form[name=RoleEditForm]');

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var id = $("#id").val();
        var firstNameValue = $("#rolename").val();
        var lastNameValue = $("#displayname").val();
        var AddressValue = $("#address").val();
        var PhoneNumberValue = $("#phoneNumber").val();
        var emailAddressValue = $("#emailAddress").val();

        var role = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
        role.permissions = [];
        var _$permissionCheckboxes = $("input[name='permission']:checked:visible");
        if (_$permissionCheckboxes) {
            for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
                var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
                role.permissions.push(_$permissionCheckbox.val());
            }
        }

        abp.ui.setBusy(_$form);
        $.post("/Customers/Edit", { CustomerID: id, FirstName: firstNameValue, LastName: lastNameValue, Address: AddressValue, PhoneNumber: PhoneNumberValue, EmailAddress: emailAddressValue }).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited role!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);