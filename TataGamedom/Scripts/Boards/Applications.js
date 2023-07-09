const baseAddress = "https://localhost:44398";
moment.locale("zh-tw");

function donuts(likeCount, dislikeCount, selectorId) {
  var dataset = [
    { label: "讚", count: likeCount },
    { label: "倒讚", count: dislikeCount },
  ];

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
    .range(["#98abc5", "#ff8c00"]); // 設定顏色

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

donuts(10, 20, "#MemberThisBoardDonuts");
donuts(10, 20, "#MemberAllBoardDonuts");

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
        let id=data.Id;
        let memberAccount=data.MemberAccount;
        let boardName=data.BoardName;
        let applyDate=data.ApplyDate;
        let addorRemoveText=data.AddOrRemoveText;
        let appplyReason=data.ApplyReason;
        let approvalStatus=data.ApprovalStatus;
        let approvalResultText=data.ApprovalResultText;
        let backendMemberAccount=data.BackendMemberAccount;
        let approvalStatusDate=data.ApprovalStatusDate;
        console.log(boardName)
        $('#BoardName').text(boardName);
        $('#AddOrRemoveText').text(addorRemoveText);
        $('#Id').text(id);
        $('#ApplyReason').text(appplyReason);
        $('#Account').text(memberAccount);
        $('#ApplyDate').text(applyDate);
        $('#ApprovalResultText').text(approvalResultText);
        $('#BackendMemberAccount').text(backendMemberAccount);
        $('#ApprovalStatusDate').text(approvalStatusDate);
        $('#MemberPostAtBoardNum').text(1);
        $('#MemberPostAtAllNum').text(5);
        
        if (approvalStatus === '已完成') {
          $('#OkBtn').attr('disabled', true);
          $('#NoBtn').attr('disabled', true);
        }else{
          $('#OkBtn').attr('disabled', false);
          $('#NoBtn').attr('disabled', false);
        }
        
        if (addorRemoveText === '離職') {
          $('#OkBtn').attr('disabled', false);
          $('#NoBtn').attr('disabled', true);
        }
        
        if (addorRemoveText === '加入') {
          $('#OkBtn').attr('disabled', false);
          $('#NoBtn').attr('disabled', false);
        }
        

        $("#myModal").modal("show");
      });
    },
    order: [[0, "desc"]],
  });

  $('#OkBtn').on('click',AddOK);
  function AddOK() {
    let AddId = $('#Id').text();
    let MemberAccount = $('#Account').text();
    let BoardName = $('#BoardName').text()
    console.log(MemberAccount)
    console.log(BoardName)
    $.ajax({
        type: 'PUT',
        url: `${baseAddress}/api/BoardsModeratorsApplicationsApi/Join/${AddId}`,
        data: JSON.stringify({
            "ApprovalResult": true,
            "MemberAccount": MemberAccount,
            "BoardName": BoardName,
        }),
        contentType: "application/json"
    })
        .done(data => {
            console.log(data);
            if (data.IsSuccess) {
                Swal.fire({
                    icon: 'success',
                    title: '成功',
                    text: JSON.stringify(data.Message)
                }).then(() => {
                    $('#ApplicationTable').DataTable().ajax.reload();
                });
            } else {
                Swal.fire({
                    icon: 'error',
                    title: '失敗',
                    text: JSON.stringify(data.Message)
                });
            }
        })
        .fail(err => {
            console.log('no...')
            Swal.fire({
                icon: 'error',
                title: '失敗',
                text: err.statusText
            })
        })
  }
});
