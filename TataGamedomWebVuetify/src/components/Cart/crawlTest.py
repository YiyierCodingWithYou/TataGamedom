import requests
import pandas as pd

# 建立一個縣市的list

city = [
    '基隆市',
    '台北市',
    '新北市',
    '桃園市',
    '新竹市',
    '新竹縣',
    '苗栗縣',
    '台中市',
    '彰化縣',
    '雲林縣',
    '南投縣',
    '嘉義縣',
    '嘉義市',
    '台南市',
    '高雄市',
    '屏東縣',
    '台東縣',
    '花蓮縣',
    '宜蘭縣',
    '連江縣',
    '金門縣',
    '澎湖縣'
]

#使用迴圈來依序取得每一個城市的門市資訊

for index, city in enumerate(city):
    
    #剛剛在開發者模式觀察到的Post發出的資訊是那些

    data = {
        'strTargetField':'COUNTY',
        'strKeyWords':'%s' % city
    }

    res = requests.post('https://www.ibon.com.tw/retail_inquiry_ajax.aspx', data=data)
    
    # 第一次迴圈建立dataframe，並將城市填入。資料的形式是table，所以直接使用read_html快速拿下!

    if index == 0:
        df_711_store = pd.read_html(res.text, header=0)[0]
        df_711_store['縣市'] = city
     
    # 第二次迴圈以上就將資訊直接append到dataframe裡

    if index > 0:
        df_711_store_ = pd.read_html(res.text, header=0)[0]
        df_711_store_['縣市'] = city
        df_711_store = pd.concat([df_711_store, df_711_store_], ignore_index=True)
    
    #打印出進度

    print('%2d) %-*s %4d' % (index, 5, city, pd.read_html(res.text, header=0)[0].shape[0]))

#將資料輸出成Excel

df_711_store.to_excel('7-11門市.xlsx', index=False)
