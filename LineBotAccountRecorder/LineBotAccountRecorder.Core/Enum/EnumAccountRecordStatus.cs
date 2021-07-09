using System;
using System.ComponentModel;

namespace LineBotAccountRecorder.Core.Enum
{
    public enum EnumAccountRecordStatus
    {
        [Description("A new account record and have not been paied")]
        Outstanding = 1,

        [Description("Triggered settle process but have not confimed")]
        Settling = 2,

        [Description("Accounts have confirmed to be paied")]
        Closed = 3
    }
}
