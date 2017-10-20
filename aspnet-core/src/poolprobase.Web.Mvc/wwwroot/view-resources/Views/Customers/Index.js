(function () {
	$(function () {

		var _roleService = abp.services.app.serviceTech;
		var _$modal = $('#CustomerCreateModal');
		var _$form = _$modal.find('form');


		_$form.validate({
		});

		$('#RefreshButton').click(function () {
			refreshRoleList();
		});

		$('.delete-role').click(function () {
			var CustomerId = $(this).attr("data-role-id");
			var firstName = $(this).attr('data-role-name');

            deleteCustomer(CustomerId, firstName);
		});

		$('.edit-role').click(function (e) {
            var id = $(this).attr("data-role-id");

			e.preventDefault();
			$.ajax({
                url: abp.appPath + 'Customers/EditCustomersModal?id=' + id,
				type: 'POST',
				contentType: 'application/html',
				success: function (content) {
                    $('#RoleEditModal div.modal-content').html(content);
				},
				error: function (e) { }
			});
            //$.POST('/ServiceTechs/EditTechsModal?id=' + id);
		});

		_$form.find('button[type="submit"]').click(function (e) {
			e.preventDefault();

			if (!_$form.valid()) {
				return;
			}
            var firstNameValue = $("#firstNameValue").val();
            var lastNameValue = $("#lastNameValue").val();
            var addressValue = $("#addressValue").val();
            var phoneNumberValue = $("#phoneNumberValue").val();
            var emailAddressValue = $("#emailAddressValue").val();
			
			abp.ui.setBusy(_$modal);
			/*_roleService.create(role).done(function () {
				_$modal.modal('hide');
				location.reload(true); //reload page to see new role!
			}).always(function () {
				abp.ui.clearBusy(_$modal);
			});*/
            $.post("/Customers/Create", { FirstName: firstNameValue, LastName: lastNameValue, Address: addressValue, PhoneNumber: phoneNumberValue, EmailAddress: emailAddressValue }, refreshRoleList);
		});

		_$modal.on('shown.bs.modal', function () {
			_$modal.find('input:not([type=hidden]):first').focus();
		});

		function refreshRoleList() {
			location.reload(true); //reload page to see new role!
        }

        function DeleteSuccessfull() {
            refreshRoleList();
        };

        function deleteCustomer(customerId, firstName) {
            var recordToDelete = customerId;
            abp.message.confirm(
                "Are you sure you want to Delete: '" + firstName +  "'?",
				function (isConfirmed) {
                    if (isConfirmed) {
                        $.post("/Customers/Delete", { id: recordToDelete }, DeleteSuccessfull);
					}
				}
			);
		}
	});
})();