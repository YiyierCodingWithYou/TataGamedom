const baseAddress = "https://localhost:44398";
moment.locale("zh-tw");

function donuts(likeCount, dislikeCount, selectorId) {

  var dataset = [
    { label: "讚", count: likeCount },
    { label: "倒讚", count: dislikeCount },
  ];

    if (likeCount + dislikeCount == 0) {
        dataset = [
            { label: "資料", count: 1},
            { label: "無", count: 1},
        ];
    };

  var width = 150;
  var height = 150;
  var radius = Math.min(width, height) / 2;

  var svg = d3
    .select(selectorId)
    .append("g")
    .attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");

  var color = d3
    .scaleOrdinal()
    .domain(
      dataset.map(function (d) {
        return d.label;
      })
    )
    .range(["#ff8c00", "#98abc5"]); // 設定顏色

  var pie = d3.pie().value(function (d) {
    return d.count;
  });

  var path = d3
    .arc()
    .outerRadius(radius - 10)
    .innerRadius(radius - 50);

  var label = d3
    .arc()
    .outerRadius(radius - 40)
    .innerRadius(radius - 50);

  var arc = svg
    .selectAll(".arc")
    .data(pie(dataset))
    .enter()
    .append("g")
    .attr("class", "arc");

  arc
    .append("path")
    .attr("d", path)
    .attr("fill", function (d) {
      return color(d.data.label);
    });

  arc
    .append("text")
    .attr("transform", function (d) {
      return "translate(" + label.centroid(d) + ")";
    })
    .attr("dy", "0.35em")
    .text(function (d) {
      return d.data.label;
    });
}

function setDonutsAndNums(memberAccount, boardName){
  let ma = memberAccount, bn = boardName;
  $.ajax({
    type: "Get",
    url: `${baseAddress}/api/BoardsApi/MemberBoardDate?ma=${ma}&bn=${bn}`,
    })
    .done((data) => {
      console.log(data);
      console.log(data.MemberThisBoardLikes);
      $('#MemberThisBoardLikes').text(data[0].MemberThisBoardLikes);
      $('#MemberThisBoardUnlikes').text(data[0].MemberThisBoardUnlikes);
      $('#MemberThisBoardPostsCount').text(data[0].MemberThisBoardPostsCount);
      $('#MemberAllBoardLikes').text(data[0].MemberAllBoardLikes);
      $('#MemberAllBoardUnlikes').text(data[0].MemberAllBoardUnlikes);
      $('#MemberAllBoardPostsCount').text(data[0].MemberAllBoardPostsCount);
      donuts(data[0].MemberThisBoardLikes, data[0].MemberThisBoardUnlikes, "#MemberThisBoardDonuts");
      donuts(data[0].MemberAllBoardLikes, data[0].MemberAllBoardUnlikes, "#MemberAllBoardDonuts");

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

function PutApplication(IsAdd, endpoint) {
  let AddId = $("#Id").text();
  let MemberAccount = $("#Account").text();
  let BoardName = $("#BoardName").text();
  console.log(MemberAccount);
  console.log(BoardName);
  $.ajax({
    type: "PUT",
    url: `${baseAddress}/api/BoardsModeratorsApplicationsApi/${endpoint}/${AddId}`,
    data: JSON.stringify({
      ApprovalResult: `${IsAdd}`,
      MemberAccount: MemberAccount,
      BoardName: BoardName,
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
          $("#ApplicationTable").DataTable().ajax.reload();
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
// function GetModalText(){
//   $('#AddOrRemoveText').text(addorRemoveText);
//   $('#Id').text(id);
//   $('#ApplyReason').text(appplyReason);
//   $('#Account').text(applyDate);
//   $('#ApplyDate').text(addorRemoveText);
//   $('#ApprovalResultText').text(approvalResultText);
//   $('#BackendMemberAccount').text(backendMemberAccount);
//   $('#ApprovalStatusDate').text(approvalStatusDate);
//   $('#MemberPostAtBoardNum').text(1);
//   $('#MemberPostAtAllNum').text(5);
// }


$(document).ready(function () {
  let appTable = $("#ApplicationTable").DataTable({
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
      url: `${baseAddress}/api/BoardsModeratorsApplicationsApi`,
      dataSrc: function (data) {
        return data;
      },
    },
    columns: [
      { data: "Id", className: "text-center vertical-align-middle" },
      { data: "BoardName", className: "text-center vertical-align-middle" },
      {
        data: "AddOrRemoveText",
        className: "text-center vertical-align-middle",
      },
      {
        data: "MemberAccount",
        className: "text-center vertical-align-middle",
      },
      {
        data: "ApplyDate",
        className: "text-center vertical-align-middle",
        render: function (data, type, row) {
          let date = new Date(data);
          let formattedDateTime = date.toLocaleDateString("ja-JP");
          return formattedDateTime;
        },
      },
      {
        data: "ApplyReason",
        className: "text-center vertical-align-middle",
      },
      {
        data: "ApprovalStatus",
        className: "text-center vertical-align-middle",
      },
      {
        data: "ApprovalResultText",
        className: "text-center vertical-align-middle",
      },
      {
        data: "BackendMemberAccount",
        className: "text-center vertical-align-middle",
      },
      {
        data: "ApprovalStatusDate",
        className: "text-center vertical-align-middle",
        render: function (data, type, row) {
          if (type === "display") {
            if (data == null) {
              return "尚未審查";
            } else {
              let date = new Date(data);
              let formattedDateTime = date.toLocaleDateString("ja-JP");
              return formattedDateTime;
            }
          }
          return data;
        },
      },
    ],
    bSort: true,
    rowCallback: function (row, data) {
      if (data.ApprovalStatus.includes("待處理")) {
        $("td", row).addClass("bg-orange"); // Change text color to gray for rows with ActiveFlag = false
      }
      $(row).on("dblclick", function () {
        let id = data.Id;
        let memberAccount = data.MemberAccount;
        let boardName = data.BoardName;
        let applyDate = data.ApplyDate;
        let addorRemoveText = data.AddOrRemoveText;
        let appplyReason = data.ApplyReason;
        let approvalStatus = data.ApprovalStatus;
        let approvalResultText = data.ApprovalResultText;
        let backendMemberAccount = data.BackendMemberAccount;
        let approvalStatusDate = data.ApprovalStatusDate;
        console.log(boardName);
        $("#BoardName").text(boardName);
        $("#AddOrRemoveText").text(addorRemoveText);
        $("#Id").text(id);
        $("#ApplyReason").text(appplyReason);
        $("#Account").text(memberAccount);
        $("#ApplyDate").text(applyDate);
        $("#ApprovalResultText").text(approvalResultText);
        $("#BackendMemberAccount").text(backendMemberAccount);
        $("#ApprovalStatusDate").text(approvalStatusDate);
        $("#MemberPostAtBoardNum").text(1);
        $("#MemberPostAtAllNum").text(5);

        setDonutsAndNums(memberAccount,boardName);
       

        $("#OkBtn").attr("disabled", true);
        $("#NoBtn").attr("disabled", true);
        
        if (data.ApprovalStatus.includes("已完成")) {
          $("#OkBtn").attr("disabled", true);
          $("#NoBtn").attr("disabled", true); 
        } 
        if (data.ApprovalStatus.includes("待處理")&&addorRemoveText.includes("離職")) {
          $("#OkBtn").attr("disabled", false);
          $("#NoBtn").attr("disabled", true);
          $("#OkBtn").on("click", function () {
            Swal.fire({
              title: "確認",
              text: "確認執行【允許版主離職】",
              icon: "warning",
              showCancelButton: true,
              confirmButtonText: "確定",
              cancelButtonText: "取消",
            }).then((result) => {
              if (result.isConfirmed) {
                PutApplication(true, "left");
              }
            });
          });
        }
        if (data.ApprovalStatus.includes("待處理")&&addorRemoveText.includes("加入")) {
          $("#OkBtn").attr("disabled", false);
          $("#NoBtn").attr("disabled", false);
          $("#OkBtn").on("click", function () {
            Swal.fire({
              title: "確認",
              text: "確認執行【允許版主申請】",
              icon: "warning",
              showCancelButton: true,
              confirmButtonText: "確定",
              cancelButtonText: "取消",
            }).then((result) => {
              if (result.isConfirmed) {
                PutApplication(true, "Join");
              }
            });
          });
          $("#NoBtn").on("click", function () {
            Swal.fire({
              title: "確認",
              text: "確認執行【拒絕版主申請】",
              icon: "warning",
              showCancelButton: true,
              confirmButtonText: "確定",
              cancelButtonText: "取消",
            }).then((result) => {
              if (result.isConfirmed) {
                PutApplication(false, "Join");
              }
            });
          });
        }

        $("#myModal").modal("show");
      });
    },
    order: [[0, "desc"]],
  });
});
