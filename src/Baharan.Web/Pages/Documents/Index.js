$(function () {
    var l = abp.localization.getResource('Baharan');
    var createModal = new abp.ModalManager(abp.appPath + 'Documents/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Documents/EditModal');

    //var dataTable = $('#DocumentsTable').DataTable(
    //    abp.libs.datatables.normalizeConfiguration({
    //        serverSide: true,
    //        paging: true,
    //        order: [[1, "asc"]],
    //        searching: false,
    //        scrollX: true,
    //        ajax: abp.libs.datatables.createAjax(baharan.documents.document.getList),
    //        columnDefs: [
    //            {
    //                title: l('Actions'),
    //                rowAction: {
    //                    items:
    //                        [
    //                            {
    //                                text: l('Edit'),
    //                                visible: abp.auth.isGranted('Baharan.Documents.Edit'),
    //                                action: function (data) {
    //                                    editModal.open({ id: data.record.id });
    //                                }
    //                            },
    //                            {
    //                                text: l('Delete'),
    //                                visible: abp.auth.isGranted('Baharan.Documents.Delete'),
    //                                confirmMessage: function (data) {
    //                                    return l('DocumentDeletionConfirmationMessage', data.record.name);
    //                                },
    //                                action: function (data) {
    //                                    baharan.documents.Document
    //                                        .delete(data.record.id)
    //                                        .then(function () {
    //                                            abp.notify.info(l('SuccessfullyDeleted'));
    //                                            dataTable.ajax.reload();
    //                                        });
    //                                }
    //                            }
    //                        ]
    //                }
    //            },
    //            {
    //                title: l('NationalCart'),
    //                data: "nationalCartImageUrl"
    //            },
    //            {
    //                title: l('BirthCertificate'),
    //                data: "birthCertificateImageUrl"
    //            }
    //        ]
    //    })
    //);

    //createModal.onResult(function () {
    //    dataTable.ajax.reload();
    //});

    //editModal.onResult(function () {
    //    dataTable.ajax.reload();
    //});

    $('#NewDocumentButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
