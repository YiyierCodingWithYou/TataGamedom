const baseAddress = "https://localhost:44398";
let postId;
let boardId;
let Id;
let respondPost;
let selectData;

$(document).ready(function () {
  function DelePost() {
    $.ajax({
      type: "DELETE",
      url: `${baseAddress}/api/PostsApi/${Id}`,
    })
      .done((data) => {
        if (data.IsSuccess) {
          Swal.fire({
            icon: "success",
            title: "成功",
            text: JSON.stringify(data.Message),
          }).then(() => {
            $("#postsCommentsTable").DataTable().ajax.reload();
            $("#littleTable").DataTable().ajax.reload();
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
        Swal.fire({
          icon: "error",
          title: "失敗",
          text: err.statusText,
        });
      });
  }
  function DeleComm() {
    $.ajax({
      type: "DELETE",
      url: `${baseAddress}/api/CommentsApi/${Id}`,
    })
      .done((data) => {
        if (data.IsSuccess) {
          Swal.fire({
            icon: "success",
            title: "成功",
            text: JSON.stringify(data.Message),
          }).then(() => {
            $("#postsCommentsTable").DataTable().ajax.reload();
            $("#littleTable").DataTable().ajax.reload();
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
        Swal.fire({
          icon: "error",
          title: "失敗",
          text: err.statusText,
        });
      });
  }
  function RecoverPost() {
    $.ajax({
      type: "PUT",
      url: `${baseAddress}/api/PostsApi/${Id}`,
    })
      .done((data) => {
        if (data.IsSuccess) {
          Swal.fire({
            icon: "success",
            title: "成功",
            text: JSON.stringify(data.Message),
          }).then(() => {
            $("#postsCommentsTable").DataTable().ajax.reload();
            $("#littleTable").DataTable().ajax.reload();
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
        Swal.fire({
          icon: "error",
          title: "失敗",
          text: err.statusText,
        });
      });
  }
  function RecoverComm() {
    $.ajax({
      type: "PUT",
      url: `${baseAddress}/api/CommentsApi/${Id}`,
    })
      .done((data) => {
        if (data.IsSuccess) {
          Swal.fire({
            icon: "success",
            title: "成功",
            text: JSON.stringify(data.Message),
          }).then(() => {
            $("#postsCommentsTable").DataTable().ajax.reload();
            $("#littleTable").DataTable().ajax.reload();
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
        Swal.fire({
          icon: "error",
          title: "失敗",
          text: err.statusText,
        });
      });
  }
  function GetPostdata(id) {
    $.ajax({
      type: "GET",
      url: `${baseAddress}/api/PostsApi/${postId}`,
      success: function (data) {
        postData = JSON.stringify(data);
        $("#littleTable").DataTable().ajax.reload();
      },
      error: function (err) {
        console.log(err.statusText);
      },
    });
  }

  function ClickFunction(data) {
    Id = data.ID;
    respondPost = data.RespondedPost;
    boardName = data.BoardName;

    if (data.Type === "Post") {
      postId = Id;
      $("#textContent").text("I'm a post");
    }

    if (data.Type === "Comment") {
      postId = respondPost;
      $("#textContent").text("I'm a Comment");
    }

    let memberAccount = data.MemberAccount;
    $("#memberAccount").text(data.MemberAccount);
    littleTable.ajax.url(`${baseAddress}/api/PostsApi/${postId}`).load();
    $("#myModal").modal("show");
    boardName = data.BoardName;
  }

  //TODO
  let littleTable = $("#littleTable").DataTable({
    dom: "rtip",
    responsive: true,
    language: {
      url: "//cdn.datatables.net/plug-ins/1.13.4/i18n/zh-HANT.json",
    },
    ajax: {
      type: "GET",
      url: `${baseAddress}/api/PostsApi`,
      dataSrc: function (data) {
        return data;
      },
    },
    columns: [
      {
        data: "BoardName",
        className: "text-center vertical-align-middle",
        width: "10%",
      },
      {
        data: "Type",
        className: "text-center vertical-align-middle",
        width: "5%",
      },
      {
        data: "Content",
        className: "text-center vertical-align-middle w-25",
        width: "800px",
      },
      {
        data: "MemberAccount",
        className: "text-center vertical-align-middle",
        width: "10%",
      },
      {
        data: "DateTime",
        className: "text-center vertical-align-middle",
        className: "text-center vertical-align-middle",
        render: function (data, type, row) {
          let date = new Date(data);
          let formattedDate = date.toLocaleDateString("ja-JP");
          let formattedTime = date.toLocaleTimeString("ja-JP");
          let formattedDateTime = formattedDate + "<br/>" + formattedTime;
          return formattedDateTime;
        },
        width: "10%",
      },
      {
        data: "LikesCount",
        className: "text-center vertical-align-middle",
        width: "5%",
      },
      {
        data: "UnlikesCount",
        className: "text-center vertical-align-middle",
        width: "5%",
      },
      {
        data: "CommentsCount",
        className: "text-center vertical-align-middle",
        width: "5%",
      },
      {
        data: "ActiveFlagText",
        className: "text-center vertical-align-middle",
        render: function (data, type, row) {
          if (type === "display") {
            if (data === "顯示") {
              return '<i class="fas fa-check text-success small">顯示</i>'; // Font Awesome check icon for true (active)
            } else {
              return '<i class="fas fa-times text-danger small">隱藏</i>'; // Font Awesome times icon for false (inactive)
            }
          }
          return data;
        },
      },
      {
        data: null,
        targets: -1,
        defaultContent: "",
        render: function (data, type, row) {
          if (type === "display") {
            if (data.Type === "Post" && data.ActiveFlagText.includes("顯示")) {
              return '<button class="btn btn-outline-warning changeBtn postDele">隱藏</button>';
            }
            if (
              data.Type === "Comment" &&
              data.ActiveFlagText.includes("顯示")
            ) {
              return '<button class="btn btn-outline-warning changeBtn commentDele">隱藏</button>';
            }
            if (data.Type === "Post" && data.ActiveFlagText.includes("隱藏")) {
              return '<button class="btn btn-outline-light changeBtn postRecover">還原</button>';
            }
            if (
              data.Type === "Comment" &&
              data.ActiveFlagText.includes("隱藏")
            ) {
              return '<button class="btn btn-outline-light changeBtn commentRecover">還原</button>';
            }
          }
        },
      },
    ],
    rowCallback: function (row, data) {
      let type = "Comment";
      let memberAccount = $("#memberAccount").text();
      //let memberAccount = 'sarahT';

      if (data.ActiveFlagText.includes("隱藏")) {
        $("td", row).addClass("text-gray"); // Change text color to gray for rows with ActiveFlag = false
      }
      if (data.Type === "Post") {
        $(row).addClass("fw-bold"); // Change text color to gray for rows with ActiveFlag = false
      }
      if (data.MemberAccount === memberAccount) {
        $(row).addClass("bg-orange"); // Change text color to gray for rows with ActiveFlag = false
      }
      $(row).on("click", function () {
        Id = data.ID;
        respondPost = data.RespondedPost;
        boardName = data.BoardName;

        if (data.Type === "Post") {
          postId = Id;
          $("#textContent").text("I'm a post");
        }

        if (data.Type === "Comment") {
          postId = respondPost;
          $("#textContent").text("I'm a Comment");
        }

        let memberAccount = data.MemberAccount;
        $("#memberAccount").text(data.MemberAccount);
        littleTable.ajax.url(`${baseAddress}/api/PostsApi/${postId}`).load();
        $("#myModal").modal("show");
        boardName = data.BoardName;
      });
    },
  });

  let postTable = $("#postsCommentsTable").DataTable({
    dom: "<'row'<'col-5 'Q><'col-7 d-flex justify-content-end align-items-center'<'mb-0 pb-0' B>>>flrtilp",
    //dom: 'QBflrtilp',
    responsive: true,
    select: true,
    buttons: [
      "copy",
      "csv",
      "excel",
      {
        text: "批次隱藏",
        extend: "selected",
        action: function (e, dt, node, config) {
          let successfulDeletes = 0;
          let ignoredDeletes = 0;
          let rows = dt.rows({ selected: true }).count();
          let selectedRows = dt.rows({ selected: true }).data();
          let selectedData = [];

          selectedRows.each(function (rowData) {
            let type = rowData.Type;
            let id = rowData.ID;
            let activeFlag = rowData.ActiveFlag;
            selectedData.push({ type: type, id: id, activeFlag: activeFlag });
          });
          Swal.fire({
            title: "隱藏貼文請三思",
            text: "此動作將大量隱藏貼文內容，你確定嗎？",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "確定",
            cancelButtonText: "取消",
          }).then((result) => {
            if (result.isConfirmed) {
              ignoredDeletes = selectedData.filter(
                (item) => item.activeFlag == false
              ).length;
    
              successfulDeletes = selectedData.filter(
                (item) =>
                  item.activeFlag &&
                  (item.type === "Post" || item.type === "Comment")
              ).length;
    
              selectedData
                .filter(
                  (item) =>
                    item.activeFlag &&
                    (item.type === "Post" || item.type === "Comment")
                )
                .forEach((item) => {
                  const endpoint = `${item.type}sApi`;
                  const id = item.id;
                  console.log(":D");
                  $.ajax({
                    type: "DELETE",
                    url: `${baseAddress}/api/${endpoint}/${id}`,
                  })
                    .done((data) => {
                      console.log(":DD");
                      successfulDeletes + 1;
                    })
                    .fail((err) => {
                      ignoredDeletes + 1;
                    });
                });
              Swal.fire({
                icon: "success",
                title: "執行完成",
                text: `隱藏 ${successfulDeletes} 筆，早已隱藏忽略不做 ${ignoredDeletes} 筆`,
              });
              $("#postsCommentsTable").DataTable().ajax.reload();
    
              // Output the results
              successfulDeletes = 0;
              ignoredDeletes = 0;
            }
          });
          
        },
      },
    ],
    language: {
      url: "//cdn.datatables.net/plug-ins/1.13.4/i18n/zh-HANT.json",
    },
    ajax: {
      type: "GET",
      url: `${baseAddress}/api/PostsApi`,
      dataSrc: function (data) {
        return data;
      },
    },
    columns: [
      { data: "BoardName", className: "text-center vertical-align-middle" },
      { data: "Type", className: "text-center vertical-align-middle" },
      { data: "Content", className: "text-center vertical-align-middle w-25" },
      { data: "MemberAccount", className: "text-center vertical-align-middle" },
      {
        data: "DateTime",
        className: "text-center vertical-align-middle",
        render: function (data, type, row) {
          let date = new Date(data);
          let formattedDateTime = date.toLocaleDateString("ja-JP");
          return formattedDateTime;
        },
      },
      { data: "LikesCount", className: "text-center vertical-align-middle" },
      { data: "UnlikesCount", className: "text-center vertical-align-middle" },
      { data: "CommentsCount", className: "text-center vertical-align-middle" },
      {
        data: "ActiveFlagText",
        className: "text-center vertical-align-middle",
        render: function (data, type, row) {
          if (type === "display") {
            if (data === "顯示") {
              return '<i class="fas fa-check text-success small">顯示</i>'; // Font Awesome check icon for true (active)
            } else {
              return '<i class="fas fa-times text-danger small">隱藏</i>'; // Font Awesome times icon for false (inactive)
            }
          }
          return data;
        },
      },
      {
        data: null,
        targets: -1,
        defaultContent: "",
        render: function (data, type, row) {
          if (type === "display") {
            if (data.Type === "Post" && data.ActiveFlagText.includes("顯示")) {
              return '<button class="btn btn-outline-warning changeBtn postDele">隱藏</button>';
            }
            if (
              data.Type === "Comment" &&
              data.ActiveFlagText.includes("顯示")
            ) {
              return '<button class="btn btn-outline-warning changeBtn commentDele">隱藏</button>';
            }
            if (data.Type === "Post" && data.ActiveFlagText.includes("隱藏")) {
              return '<button class="btn btn-outline-light changeBtn postRecover">還原</button>';
            }
            if (
              data.Type === "Comment" &&
              data.ActiveFlagText.includes("隱藏")
            ) {
              return '<button class="btn btn-outline-light changeBtn commentRecover">還原</button>';
            }
          }
        },
      },
    ],
    bSort: true,
    rowCallback: function (row, data) {
      if (data.ActiveFlagText.includes("隱藏")) {
        $("td", row).addClass("text-gray"); // Change text color to gray for rows with ActiveFlag = false
      }
      $(row).on("click", function () {
        Id = data.ID;
      });
      $(row).on("dblclick", function () {
        Id = data.ID;
        respondPost = data.RespondedPost;
        boardName = data.BoardName;

        if (data.Type === "Post") {
          postId = Id;
          $("#textContent").text("I'm a post");
        }

        if (data.Type === "Comment") {
          postId = respondPost;
          $("#textContent").text("I'm a Comment");
        }

        $("#memberAccount").text(data.MemberAccount);
        littleTable.ajax.url(`${baseAddress}/api/PostsApi/${postId}`).load();
        $("#myModal").modal("show");
        boardName = data.BoardName;
      });
    },
  });

  $(document).on("click", ".postDele", function (event) {
    //$('#myModal').modal('hide');
    Swal.fire({
      title: "刪除貼文",
      text: "此動作將刪除貼文內容，你確定嗎？",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "確定",
      cancelButtonText: "取消",
    }).then((result) => {
      if (result.isConfirmed) {
        // 使用者選擇確定，執行 SaveEdit()
        DelePost();
        $("#postsCommentsTable").DataTable().ajax.reload();
        $("#littleTable").DataTable().ajax.reload();
      }
    });
  });
  $(document).on("click", ".commentDele", function (event) {
    /*                $('#myModal').modal('hide');*/
    Swal.fire({
      title: "刪除留言？",
      text: "此動作將刪除留言內容，你確定嗎？",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "確定",
      cancelButtonText: "取消",
    }).then((result) => {
      if (result.isConfirmed) {
        DeleComm();
        $("#postsCommentsTable").DataTable().ajax.reload();
        $("#littleTable").DataTable().ajax.reload();
      }
    });
  });
  $(document).on("click", ".postRecover", function (event) {
    //$('#myModal').modal('hide');
    Swal.fire({
      title: "復原貼文？",
      text: "此動作將復原推文內容，你確定嗎？",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "確定",
      cancelButtonText: "取消",
    }).then((result) => {
      if (result.isConfirmed) {
        RecoverPost();
        $("#postsCommentsTable").DataTable().ajax.reload();
        $("#littleTable").DataTable().ajax.reload();
      }
    });
  });
  $(document).on("click", ".commentRecover", function (event) {
    //$('#myModal').modal('hide');
    Swal.fire({
      title: "復原留言？",
      text: "此動作將復原評論內容，你確定嗎？",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "確定",
      cancelButtonText: "取消",
    }).then((result) => {
      if (result.isConfirmed) {
        RecoverComm();
        $("#postsCommentsTable").DataTable().ajax.reload();
        $("#littleTable").DataTable().ajax.reload();
      }
    });
  });
});
