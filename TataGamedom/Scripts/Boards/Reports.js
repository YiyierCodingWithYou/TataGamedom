const baseAddress = 'https://localhost:44398';

$(document).ready(function () {
    $('#ReportTable').DataTable
        ({
            responsive: true,
            dom: "<'row'<'col-5 'Q><'col-7 d-flex justify-content-end align-items-center'<'mb-0 pb-0' B>>>flrtilp",
            buttons: ['copy', 'csv', 'excel'],
            language: {
                url: '//cdn.datatables.net/plug-ins/1.13.4/i18n/zh-HANT.json',
            },
            ajax: {
                type: 'GET',
                url: `${baseAddress}/api/ReportsApi`,
                dataSrc: function (data) { return data; }
            },
            columns: [
                { "data": "Index", "className": "text-center vertical-align-middle" },
                { "data": "Type", "className": "text-center vertical-align-middle" },
                {
                    "data": "Datetime",
                    "className": "text-center vertical-align-middle",
                    "render": function (data, type, row) {
                        let date = new Date(data);
                        let formattedDateTime = date.toLocaleDateString('ja-JP');
                        return formattedDateTime;
                    }
                },
                { "data": "Account", "className": "text-center vertical-align-middle" },
                { "data": "Reason", "className": "text-center vertical-align-middle" },
                { "data": "ReportedId", "className": "text-center vertical-align-middle" },
                { "data": "ReportedContent", "className": "text-center vertical-align-middle" },
                { "data": "ReportedAccount", "className": "text-center vertical-align-middle" },
                { "data": "IsCommitText", "className": "text-center vertical-align-middle" },
                { "data": "ReviewComment", "className": "text-center vertical-align-middle" },
                { "data": "ReviewDatetime", "className": "text-center vertical-align-middle" },
                { "data": "ReviewerBackendMemberAccount", "className": "text-center vertical-align-middle" }
            ],
            columnDefs: [
                {
                    target: 3,
                    visible: false,
                },
                {
                    target: 5,
                    visible: false,
                },
                {
                    target: 7,
                    visible: false,
                },
                {
                    target: 9,
                    visible: false,
                },
                {
                    target: 10,
                    visible: false,
                },
                {
                    target: 11,
                    visible: false,
                },
            ],
            "rowCallback": function (row, data) {
                if (data.IsCommitText.includes('完成')) {
                    $("td", row).addClass("text-gray"); // Change text color to gray for rows with ActiveFlag = false
                }

                $(row).on("click", function () {
                    $('#myModal').modal('show');

                });
            }
        })
})