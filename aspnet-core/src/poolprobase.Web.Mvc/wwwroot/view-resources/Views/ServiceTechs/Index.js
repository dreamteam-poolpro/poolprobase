(function () {
	$(function () {

		var _roleService = abp.services.app.serviceTech;
		var _$modal = $('#TechCreateModal');
		var _$form = _$modal.find('form');

		_$form.validate({
		});

		$('#RefreshButton').click(function () {
			refreshRoleList();
		});

		$('.delete-role').click(function () {
			var serviceTechId = $(this).attr("data-role-id");
			var firstName = $(this).attr('data-role-name');

            deleteTech(serviceTechId, firstName);
		});

		$('.edit-role').click(function (e) {
            var serviceTechId = $(this).attr("data-role-id");

			e.preventDefault();
			$.ajax({
                url: abp.appPath + 'ServiceTechs/CreateTechModal',
				type: 'GET',
				contentType: 'application/html',
				success: function (content) {
					$('#TechEditModal div.modal-content').html(content);
				},
				error: function (e) { }
			});
		});

		_$form.find('button[type="submit"]').click(function (e) {
			e.preventDefault();

			if (!_$form.valid()) {
				return;
			}
            var firstNameValue = $("#firstNameValue").val();
            var lastNameValue = $("#lastNameValue").val();
			
			abp.ui.setBusy(_$modal);
			/*_roleService.create(role).done(function () {
				_$modal.modal('hide');
				location.reload(true); //reload page to see new role!
			}).always(function () {
				abp.ui.clearBusy(_$modal);
			});*/
            $.post("/ServiceTechs/Create", { FirstName: firstNameValue, LastName: lastNameValue }, refreshRoleList);
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

        function deleteTech(serviceTechId, firstName) {
            var recordToDelete = serviceTechId;
            abp.message.confirm(
                "Are you sure you want to Delete: '" + firstName +  "'?",
				function (isConfirmed) {
                    if (isConfirmed) {
                        $.post("/ServiceTechs/Delete", { id: recordToDelete }, DeleteSuccessfull);
					}
				}
			);
		}
	});
})();