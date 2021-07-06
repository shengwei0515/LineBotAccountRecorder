# Reference
* https://superlevin.ifengyuan.tw/%E5%88%9D%E6%8E%A2-asp-net-core-%E6%89%93%E9%80%A0-line-bot/
* https://ithelp.ithome.com.tw/articles/10217452
* https://github.com/isdaviddong/LineBotSdkExample/blob/master/LineBotSdkExample/Controllers/LineChatController.cs

# 解決無法 using 同個專案的 sub project 問題
* 表徵：無法透過 using 找到別層的程式碼
* 解決方法： https://www.skylinetechnologies.com/Blog/Skyline-Blog/February_2018/how-to-use-dot-net-core-cli-create-multi-project
    * 簡單來說就是透過dotnet add <who_want_to_import.csproj> reference <project_to_import.csproj> 這樣的指令來新增 reference
