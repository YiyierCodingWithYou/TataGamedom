const baseAddress = "https://localhost:44398";
moment.locale("zh-tw");
let modId;
let appNum;
let MemberAccountList = ["hi", "liho"];
let BoardNameList = ["hi", "liho"];

function DeleteMod(id) {
  $.ajax({
    type: "Delete",
    url: `${baseAddress}/api/BucketLogsApi/${id}`,
  })
    .done((data) => {
      console.log(data);
      if (data.IsSuccess) {
        Swal.fire({
          icon: "success",
          title: "成功",
          text: JSON.stringify(data.Message),
        }).then(() => {
          $("#BucketLogTable").DataTable().ajax.reload();
          clearForm();
        });
      } else {
        Swal.fire({
          icon: "error",
          title: "失敗",
          text: JSON.stringify(data.Message),
        });
      }
    })
    .fail((err) => {
      console.log("no...");
      Swal.fire({
        icon: "error",
        title: "失敗",
        text: err.statusText,
      });
    });
}


$(document).ready(function () {
    let moderatorTable = $("#BucketLogTable").DataTable({
    dom: "<'row'<'col-5 'Q><'col-7 d-flex justify-content-end align-items-center'<'mb-0 pb-0' B>>>flrtilp",
    //dom: 'QBflrtilp',
    responsive: true,
    select: true,
    buttons: [
      "copy",
      "csv",
      "excel",
      {
        text: "退水桶",
        action: function (e, dt, node, config) {
          let selectedRows = dt.rows({ selected: true }).data();
          if (selectedRows.length > 1) {
            Swal.fire({
              title: "做人不能太貪心!",
              text: "一次選一個，細心檢查很重要",
              imageUrl: "/Files/Images/kill.jpg",
              imageWidth: 400,
              imageHeight: 400,
              imageAlt: "Custom image",
            });
          } else if (selectedRows[0].Status == "退任") {
            console.log(selectedRows[0]);
            console.log(selectedRows[0].Status);
            Swal.fire({
              title: "人家早已自由了!",
              text: "想清楚再行動",
              imageUrl: "/Files/Images/kill.jpg",
              imageWidth: 400,
              imageHeight: 400,
              imageAlt: "Custom image",
            });
          } else if (selectedRows.length === 1) {
            Swal.fire({
              title: "確認後再行動",
              text: "此動作將解除水桶且無法復原，你確定嗎？",
              icon: "warning",
              showCancelButton: true,
              confirmButtonText: "確定",
              cancelButtonText: "取消",
            }).then((result) => {
              if (result.isConfirmed) {
                modId = selectedRows[0].Id;
                DeleteMod(modId);
              }
            });
          }
        },
      },
    ],
    language: {
      url: "//cdn.datatables.net/plug-ins/1.13.4/i18n/zh-HANT.json",
    },
    ajax: {
      type: "GET",
      url: `${baseAddress}/api/BucketLogsApi`,
      dataSrc: function (data) {
        return data;
      },
    },
    columns: [
      { data: "Id", className: "text-center vertical-align-middle" },
      { data: "BoardName", className: "text-center vertical-align-middle" },
      { data: "BucketMemberAccount", className: "text-center vertical-align-middle" },
      { data: "BucketReason", className: "text-center vertical-align-middle" },
      {
        data: "BucketStatus",
        className: "text-center vertical-align-middle",
        render: function (data, type, row) {
          if (type === "display") {
            if (data === "水桶中") {
              return '<i class="fas fa-handcuffs text-dangerous small">水桶中</i>'; // Font Awesome check icon for true (active)
            } else {
              return '<i class="fas fa-person-running text-body-tertiary small">已結束</i>'; // Font Awesome times icon for false (inactive)
            }
          }
          return data;
        },
      },
      {
        data: "StartTime",
        className: "text-center vertical-align-middle",
        render: function (data, type, row) {
          let date = new Date(data);
          let formattedDateTime = date.toLocaleDateString("ja-JP");
          return formattedDateTime;
        },
      },
      {
        data: "EndTime",
        className: "text-center vertical-align-middle",
        render: function (data, type, row) {
            let date = new Date(data);
            let formattedDateTime = date.toLocaleDateString("ja-JP");
            return formattedDateTime;
        },
      },
      {
        data: "ActionType",
        className: "text-center vertical-align-middle"
      },
      {
        data: "ActionAccount",
        className: "text-center vertical-align-middle"
      }
    ],
    bSort: true,
    rowCallback: function (row, data) {
      if (data.BucketStatus.includes("已結束")) {
        $("td", row).addClass("text-gray"); // Change text color to gray for rows with ActiveFlag = false
      }
      // $(row).on("dblclick", function () {
      //   $("#myModal").modal("show");
      // });
    },
    order: [[0, "desc"]],
  });

  $("#AddMod").on("click", function () {
    Swal.fire({
      title: "加入新水桶名單",
      html:
        '<input id="MemberAccountList2" class="swal2-input" placeholder="會員帳號">' +
        '<input id="BoardNemeList2" class="swal2-input" placeholder="討論版名稱">'+
        '<input type="number" id="Days" class="swal2-input" min="0" max="36500"><span>天</sapn>'+
        '<input id="BucketReason" class="swal2-input" placeholder="理由" value="違反社群規範">',
      inputAttributes: {
        autocapitalize: "off",
      },
      showCancelButton: true,
      confirmButtonText: "加入水桶名單",
      showLoaderOnConfirm: true,
      preConfirm: () => {
        const memberAccount = $("#MemberAccountList2").val();
        const boardName = $("#BoardNemeList2").val();
        const days = $("#Days").val();
        const bucketReason = $("#BucketReason").val();
        return $.ajax({
          type: "POST",
          url: `${baseAddress}/api/BucketLogsApi`,
          data: JSON.stringify({
            BucketMemberAccount: memberAccount,
            BoardName: boardName,
            BucketReason:bucketReason,
            Days:days
          }),
          contentType: "application/json",
        })
          .done((data) => {
            console.log(data);
            if (data.IsSuccess) {
              Swal.fire({
                icon: "success",
                title: "成功",
                text: JSON.stringify(data.Message),
              }).then(() => {
                $("#BucketLogTable").DataTable().ajax.reload();
                clearForm();
              });
            } else {
              Swal.fire({
                icon: "error",
                title: "失敗",
                text: JSON.stringify(data.Message),
              });
            }
          })
          .fail((err) => {
            console.log("no...");
            Swal.fire({
              icon: "error",
              title: "失敗",
              text: err.statusText,
            });
          });
      },
      allowOutsideClick: () => !Swal.isLoading(),
    }).then((result) => {
      if (result.isConfirmed) {
        Swal.fire({
          title: `${result.value.login}'s avatar`,
          imageUrl: result.value.avatar_url,
        });
      }
    });

    //autocomplete1
    $.ajax({
      type: "Get",
      url: `${baseAddress}/api/MembersApi/AccountList`,
    })
      .done((data) => {
        MemberAccountList = data;
        $("#MemberAccountList2").autocomplete({
          source: MemberAccountList,
        });
      })
      .fail((err) => {
        console.log(err);
      });

    //autocomplete2
    $.ajax({
      type: "Get",
      url: `${baseAddress}/api/BoardsApi/NameList`,
    })
      .done((data) => {
        BoardNameList = data;
        $("#BoardNemeList2").autocomplete({
          source: BoardNameList,
        });
      })
      .fail((err) => {
        console.log(err);
      });

    
  });
});
