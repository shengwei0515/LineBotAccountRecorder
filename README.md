# LineBotAccountRecorder

# Migrate Command
*  create migrate cs file
```
dotnet ef migrations add AddAccountRecourd -s ../LineBotAccountRecorder/LineBotAccountRecorder.csproj --verbose
```

* run migrate
```
dotnet ef database update -s ../../LineBotAccountRecorder/LineBotAccountRecorder.csproj
```

