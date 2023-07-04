Working On

調整
Orders
[] C : 隱藏退貨、退款選項, 寄送方式下拉式debug, 貨態追蹤代碼對應寄送方式e.g. 7-11 11碼
[] R : Detail =>OrderItem  Create debug，應改成新增訂單明細至該筆訂單  ;  View => 訂單主檔的部分跟訂單明細的部分拆開，商品圖套用 ; 回首頁
[] U : 畫面呈現正在編輯哪筆訂單，及寄信功能; 下拉選單三種狀態的對應
[] D : 新增讓空的主檔可以被刪除、被關聯的主檔被刪除會被提醒

OrderItemReturn
[] C
[] R
[] U
[] D


Inventory
[] C
[] R
[] U
[] D
Get 呈現原本的值(參考Order):  Inventory Detail & 

StockInSheets
[] C
[] R
[] U
[] D




To Do
[] Order 變更物流狀態 => 寄信
[] 進貨推薦清單
[] Create Order 要檢查Member id是否存在

[]退貨單
[]Edit Order 變更物流狀態時寄信

[]分頁重構 Pagination , RouteValueDictionary , 0040
[]使能選擇輸入欄位要篩什麼
[]使能選擇
	訂單狀態 &  訂單編號 & 顯示幾筆
	訂單狀態 OR 訂單編號(輸入欄位) & 顯示幾筆

[] 更改假資料 OrderItem要少於對應的庫存item


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
[v]Order Create View Controller 
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