using AppApi.Hubs;
using Microsoft.AspNetCore.Builder;

namespace AppApi.Configs
{
    public static class SignalRMapHub
    {
        public static void SignalRMapHubConfigure(IApplicationBuilder app){

            app.UseSignalR(routes =>{ routes.MapHub<NotificationHub>("/notification"); });
            
        }
    }
}