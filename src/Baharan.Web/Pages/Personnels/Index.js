$(function () {
    var l = abp.localization.getResource('Baharan');
    var createModal = new abp.ModalManager(abp.appPath + 'Personnels/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Personnels/EditModal');
    var documentModal = new abp.ModalManager(abp.appPath + 'Documents/CreateModal');
    var experincesModal = new abp.ModalManager(abp.appPath + 'Experiences/CreateModal');

    var dataTable = $('#PersonnelsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(baharan.personnels.personnel.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('Baharan.Personnels.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Documents'),
                                    visible: abp.auth.isGranted('Baharan.Documents'),
                                    action: function (data) {
                                        documentModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Experiences'),
                                    visible: abp.auth.isGranted('Baharan.Experiences'),
                                    action: function (data) {
                                        experincesModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('Baharan.Personnels.Delete'),
                                    confirmMessage: function (data) {
                                        return l('PersonnelDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        baharan.personnels.personnel
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('FirstName'),
                    data: "firstName"
                },
                {
                    title: l('LastName'),
                    data: "lastName"
                },
                {
                    title: l('NationalCode'),
                    data: "nationalCode"
                },
                {
                    title: l('BirthDate'),
                    data: "birthDate",
                    dataFormat: "datetime"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewPersonnelButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
