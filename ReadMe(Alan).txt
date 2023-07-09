Working On
    []改Index跟detail的View

To Do

	[] 進貨推薦清單

	[]退貨單

	[]分頁重構 Pagination , RouteValueDictionary , 0040
	[]使能選擇輸入欄位要篩什麼
	[]使能選擇
		訂單狀態 &  訂單編號 & 顯示幾筆
		訂單狀態 OR 訂單編號(輸入欄位) & 顯示幾筆

	[] 更改假資料 OrderItem要少於對應的庫存item

	Orders Create
	[] 貨態追蹤代碼對應寄送方式e.g. 7-11 11碼 

	Suppliers
	[] import Excel 檔案驗證

	View的錯誤訊息排版，Index的文字置中

	OrderItemReturn
	[] C : 一筆OrderItem只能被退貨一次，下拉清單不顯示已被退貨過的選項 ; 檢查編號是否產生
	[] R : Index 退款/退貨/重新入庫 改成文字 ; Detail 售價改#,# 退貨原訂單代碼獨立出來 
	[] U : Detail Edit 一筆OrderItem只能被退貨一次，下拉清單不顯示已被退貨過的選項
	[] D

	Order

	InventoryItem
	[] 開始寫多筆同時新增

	調整
	Orders
	[] C : []新增訂單與訂單明細合併進行
		   []Create OrderItem
		   []選已付款 => 每個日期都必填 ; 選已發貨 => 寄送日必填 ; 選已到達或已取貨 => 抵達日期必填
		   []貨態追蹤代碼對應寄送方式e.g. 7-11 11碼,
		   []dataType => date設定成不能選擇今天以後的
	[] R : []Detail  OrderItem Create debug，應改成新增訂單明細至該筆訂單 => 之後前端處理;  
	[] U : []下拉選單三種狀態的對應



	Inventory
	[] C : View 要改
	[] R : [v]Index View要改
	   
		   [v]detail 遊戲名稱獨立出來
		   [] 新增篩選分頁, 已售出未售出
	[] D : 讓沒被關聯的可以刪，在UI介面就擋掉


	StockInSheets
	[] C : Quantity? 反正規化? ProductId? 
	[] R
	[] U : 若改成已入庫，到貨日自動getDate
	[] D

		#統一調整 
		Edit dataType => 沒get到日期 編號 ; Edit => 沒get到日期
		檢查VM 售價及成本 改#,#  or 套用自訂attribution
		清單頁 => 排序篩選分頁

	[]Client Validation => JS

Completed
06/26
[v]Create EFModel
[v]Add Controller & View & LayOut2
[v]Add OrdersIndexVM, Add OrdersIndex Controller , Index View
[v]Orders Index()改三層式, 改的順序:DTO => IRepo => Repo => Services => Controller

06/27
[v]新增Service,Repo併為一個
[v]訂單狀態 & [v]訂單編號(輸入欄位)
[v]SelectList
[v]單元測試

6/28
[V]排序功能 Index CreatedAt Status*3 total  => ApplySort() 傳入參數放IEnumarable (已Debug)
[v]排序功能結合篩選功能, unitTest => TestGetUrl

06/29
[v]排序功能 Debug
[v]分頁功能
步驟
//View 呼叫連結
//取得Service.Search(criteria, sortInfo).Count() 作為TotalRecords 
// 設定PageInfo 
	property
	 => TotalRecords 篩選後資料筆數, PageSize 每頁幾筆 , PageNumber 點擊第幾頁
	       Pages 顯示幾頁(btn) 
	       PageItemCount(預設頁數?)
	       PageItemPrevNumber首頁btn對應頁數
	       PageItemNextNumber結尾btn對應頁數
	       PageBarItemCount(預設button數)

06/30
[v]Add Order Create() VM,Dto
[v]Order Create IRepo repo Service []功能 => Index編碼

07/01
[v] Order Create View Controller 
[v] Orders Create 修改DataAnnotations&下拉清單
[v] debug Index Sql
[v] Add Order Info()
[v] Order Edit Delete

07/02
[v] 庫存Index  => Service Search()
[v] Debug Order Info  *資料庫名稱 ShipmentStatusCode有誤
[v] 更改篩選剩餘庫存的SQL語法

07/03
[v] 庫存 detail => 庫存明細CRU
[v] 進貨單CRU

07/04
退貨單
[v] Dto VM Exts
[v] CRUD

07/05
Orders Create
[v] 隱藏退貨、退款選項, 寄送方式下拉式debug
[v] 檢查會員編號是否存在
[v] 訂單完成日期>抵達日期>寄送日期>訂單日期 (完成一半)

View => 訂單主檔的部分跟訂單明細的部分拆開，商品圖套用 ; 回首頁
隱藏退貨、退款選項, 寄送方式下拉式debug
畫面呈現正在編輯哪筆訂單
[v] D :  新增讓空的主檔可以被刪除、被關聯的主檔被刪除會被提醒
[v] 寄信功能，問是否需要寄信; 
[v] 新增自訂驗證

07/06
[v] 加入內建Controller SuppliersController 測試輸出CSV檔
[v] Export() 成功輸出CSV檔
[v] Export() 重構成StringBuilder
[v] Export() Excel
[v] import Excel
	[v]Client => Server

07/09
	[v]庫存篩選搜尋
