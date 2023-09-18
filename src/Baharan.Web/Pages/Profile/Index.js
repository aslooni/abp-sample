var l = abp.localization.getResource('Baharan');

var editPersonnelModal = new abp.ModalManager(abp.appPath + 'Personnels/EditModal');
var createDocumentModal = new abp.ModalManager(abp.appPath + 'Documents/CreateModal');
var editExperienceModal = new abp.ModalManager(abp.appPath + 'Experiences/EditModal');
var createExperienceModal = new abp.ModalManager(abp.appPath + 'Experiences/CreateModal');
function editPersonelFunction(id) {
    editPersonnelModal.open({ id: id });
}

function createDocumentFunction(id) {
    createDocumentModal.open({ id: id });
}
var dataTable = $('#ExperienceTable').DataTable(
    abp.libs.datatables.normalizeConfiguration({
        serverSide: true,
        paging: true,
        order: [[1, "asc"]],
        searching: false,
        scrollX: true,
        ajax: abp.libs.datatables.createAjax(baharan.experiences.experience.getList),
        columnDefs: [
            {
                title: l('Actions'),
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('Baharan.Experiences.Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Baharan.Experiences.Delete'),
                                confirmMessage: function (data) {
                                    return l('DocumentDeletionConfirmationMessage', data.record.name);
                                },
                                action: function (data) {
                                    baharan.experiences.Experience
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
                title: l('Company Title'),
                data: "companyTitle"
            },
            {
                title: l('StartDate'),
                data: "startDate"
            },
            {
                title: l('EndData'),
                data: "endDate"
            }
        ]
    })
);
createExperienceModal.onResult(function () {
    dataTable.ajax.reload();
});
editExperienceModal.onResult(function () {
    dataTable.ajax.reload();
});