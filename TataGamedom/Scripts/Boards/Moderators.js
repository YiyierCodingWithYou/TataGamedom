
const baseAddress = "https://localhost:44398";
moment.locale('zh-tw');

$(document).ready(function () {
  let postTable = $("#ModeratorTable").DataTable({
    dom: "<'row'<'col-5 'Q><'col-7 d-flex justify-content-end align-items-center'<'mb-0 pb-0' B>>>flrtilp",
    //dom: 'QBflrtilp',
    responsive: true,
    select: true,
    buttons: ["copy", "csv", "excel"],
    language: {
      url: "//cdn.datatables.net/plug-ins/1.13.4/i18n/zh-HANT.json",
    },
    ajax: {
      type: "GET",
      url: `${baseAddress}/api/BoardsModeratorsApi`,
      dataSrc: function (data) {
        return data;
      },
    },
    columns: [
      { data: "Id", className: "text-center vertical-align-middle" },
      { data: "BoardName", className: "text-center vertical-align-middle" },
      { data: "MemberAccount", className: "text-center vertical-align-middle" },
      { data: "Status", className: "text-center vertical-align-middle"
      ,render: function (data, type, row) 
      {
        if (type === "display") {
          if (data === "在任") {
            return '<i class="fas fa-check text-success small">在任</i>'; // Font Awesome check icon for true (active)
          } else {
            return '<i class="fas fa-times text-body-tertiary small">退任</i>'; // Font Awesome times icon for false (inactive)
          }
        }
        return data;
      }, 
      },
      {
        data: "StartDate",
        className: "text-center vertical-align-middle",
        render: function (data, type, row) {
          let date = new Date(data);
          let formattedDateTime = date.toLocaleDateString("ja-JP");
          return formattedDateTime;
        },
      },
      {
        data: "EndDate",
        className: "text-center vertical-align-middle",
        render: function (data, type, row) {
          if(data==null){
            return "在職中"
          }else{
            let date = new Date(data);
            let formattedDateTime = date.toLocaleDateString("ja-JP");
            return formattedDateTime;
          }
        },
      },
      { data: "LastOnlineTime", className: "text-center vertical-align-middle",
      render: function (data, type, row) {

        let formattedDateTime = moment(data).fromNow();
        return formattedDateTime;
        } 
      }
    ],
    bSort: true,
    rowCallback: function (row, data) {
      if (data.Status.includes("退職")) {
        $("td", row).addClass("text-gray"); // Change text color to gray for rows with ActiveFlag = false
      }
      $(row).on("dblclick", function () {
        $("#myModal").modal("show");
      });
    },
  });
});
