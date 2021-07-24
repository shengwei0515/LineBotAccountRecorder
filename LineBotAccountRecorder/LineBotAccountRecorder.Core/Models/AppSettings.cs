namespace LineBotAccountRecorder.Core.Models
{
    public class AppSettings
    {
        public string AllowedHosts { get; set; } = "*";

        public LineBotOptions LineBot { get; set; }
    }
}
