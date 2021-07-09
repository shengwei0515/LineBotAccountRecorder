using System;
using LineBotAccountRecorder.Utils.Middleware.ExceptionHandler;
using Microsoft.AspNetCore.Builder;

namespace LineBotAccountRecorder.Utils.Extensions
{
    public static class IApplicationExtension
    {
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
