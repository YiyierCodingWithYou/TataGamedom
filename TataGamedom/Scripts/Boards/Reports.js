const baseAddress = "https://localhost:44398";


$(document).ready(function () {
  $("#ReportTable").DataTable({
    responsive: true,
    dom: "<'row'<'col-5 'Q><'col-7 d-flex justify-content-end align-items-center'<'mb-0 pb-0' B>>>flrtilp",
      buttons: ["copy", "csv", "excel"],
    select:true,
    language: {
      url: "//cdn.datatables.net/plug-ins/1.13.4/i18n/zh-HANT.json",
    },
    ajax: {
      type: "GET",
      url:  `${baseAddress}/api/ReportsApi`,
      dataSrc: function (data) {
        return data;
      },
    },
    columns: [
      { data: "Index", className: "text-center vertical-align-middle" },
      { data: "Type", className: "text-center vertical-align-middle" },
      {
        data: "Datetime",
        className: "text-center vertical-align-middle",
        render: function (data, type, row) {
          let date = new Date(data);
          let formattedDateTime = date.toLocaleDateString("ja-JP");
          return formattedDateTime;
        },
      },
      { data: "Account", className: "text-center vertical-align-middle" },
      { data: "Reason", className: "text-center vertical-align-middle" },
      { data: "ReportedId", className: "text-center vertical-align-middle" },
      {
        data: "ReportedContent",
        className: "text-center vertical-align-middle",
      },
      {
        data: "ReportedAccount",
        className: "text-center vertical-align-middle",
      },
      { data: "IsCommitText", className: "text-center vertical-align-middle" },
      { data: "ReviewComment", className: "text-center vertical-align-middle" },
      {
        data: "ReviewDatetime",
        className: "text-center vertical-align-middle",
      },
      {
        data: "BoardName",
        className: "text-center vertical-align-middle",
      }
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
    ],
    rowCallback: function (row, data) {
      if (data.IsCommitText.includes("完成")) {
        $("td", row).addClass("text-gray"); // Change text color to gray for rows with ActiveFlag = false
      } 
      $(row).on("dblclick", function () {
        $("#myModal").modal("show");

        $("#Type").text(data.Type);
        $("#Id").text(data.ReportId);
        $("#Reason").text(data.Reason);
        $("#Account").text(data.Account);
        $("#Datetime").text(data.Datetime);
        $("#ReviewComment").val(data.ReviewComment);
        $("#ReviewerBackendMemberAccount").text(
          data.ReviewerBackendMemberAccount
          );
          $("#ReviewDatetime").text(data.ReviewDatetime);
          $("#ReportedContent").text(data.ReportedContent);
          $("#ReportedAccount").text(data.ReportedAccount);
          $("#BoardName").text(data.BoardName);
          
        let reportedId = data.ReportedId;
          IsHidden(reportedId);
          IsBugcket();
          $("#ConfirmBtn").attr('disabled', data.IsCommit);

          $('#DeleContentBtn').on('click',function(){
            DeleContentPost(reportedId);
            
            IsBugcket();
          });
          
          
        });
    },
  });


  $('#ConfirmBtn').on('click',function(){
    SubmitReport();
    $('#myModal').modal("hide");
  });

  $("#AddBucketBtn").on("click", function () {
    let reportedAccount = $('#ReportedAccount').text();
    let boardName = $('#BoardName').text();
    Swal.fire({
      title: "加入新水桶名單",
      html:
        `<input id="MemberAccountList2" class="swal2-input" value="${reportedAccount}">` +
        `<input id="BoardNemeList2" class="swal2-input" value="${boardName}">`+
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
                IsBugcket();
                $("#ReportTable").DataTable().ajax.reload();
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
  });

  function SubmitReport () {
      let reportType;
      if ($("#Type").text().includes("留言")) {
        reportType = "Comment";
      } else {
        reportType = "Post";
      }
    
      let Id = $("#Id").text();
      let ReviewComment = $("#ReviewComment").val();
    
      $.ajax({
        type: "PUT",
        url: `${baseAddress}/api/ReportsApi/${Id}/${reportType}`,
        data: JSON.stringify({
          Id: `${Id}`,
            ReviewComment: `${ReviewComment}`,
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
              $("#ReportTable").DataTable().ajax.reload();
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
  };
  
  function DeleContentPost(reportedId){
    let reportType;
    if ($("#Type").text().includes("留言")) {
      reportType = "Comment";
    } else {
      reportType = "Post";
    }
    let Id = reportedId

    $.ajax({
      type: "DELETE",
      url: `${baseAddress}/api/${reportType}sApi/${Id}`
    })
      .done((data) => {
        console.log(data);
        if (data.IsSuccess) {
          Swal.fire({
            icon: "success",
            title: "成功",
            text: JSON.stringify(data.Message),
          }).then(() => {
            $("#ReportTable").DataTable().ajax.reload();
            IsHidden(reportedId);
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
  };

  function IsHidden(reportedId) {
    let reportType;
    let Id = reportedId;
    if ($("#Type").text().includes("留言")) {
      reportType = "Comment";
    } else {
      reportType = "Post";
    }
  
    $.ajax({
      type: "GET",
      url: `${baseAddress}/api/ReportsApi/IsHide/${Id}/${reportType}`,
      })
      .done((data) => {
        //console.log(reportType);
        console.log(data)
        $("#DeleContentBtn").attr('disabled', data);
        if(data){
          $('#RepotedCommStatus-1').addClass('d-none')
          $('#RepotedCommStatus-0').removeClass('d-none')
        }else{
          $('#RepotedCommStatus-0').addClass('d-none')
          $('#RepotedCommStatus-1').removeClass('d-none')
        }
      })
      .fail((err) => {
        console.log(err)
      });
  }
  
  function IsBugcket() {
    let boardName = $("#BoardName").text();
    let reportedAccount = $("#ReportedAccount").text();
  
    if ($("#Type").text().includes("留言")) {
      reportType = "Comment";
    } else {
      reportType = "Post";
    }
    $.ajax({
      type: "GET",
      url: `${baseAddress}/api/BucketLogsApi/CheckBucketStatus?boardName=${boardName}&memberAccount=${reportedAccount}`})
      .done((data) => {
        //console.log(reportType);
        console.log(data)
        $("#AddBucketBtn").attr('disabled', data);
        if(data){
          $('#RepotedAccount-1').addClass('d-none')
          $('#RepotedAccount-0').removeClass('d-none')
        }else{
          $('#RepotedAccount-0').addClass('d-none')
          $('#RepotedAccount-1').removeClass('d-none')
        }
  
      })
      .fail((err) => {
        console.log(err);;
      });
  }
  

});
