using AppApi.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppApi.Hubs
{
    public class NotificationHub : Hub
    {
        public static List<ModelClient> UserOnline = new List<ModelClient>();
        private IHubContext<NotificationHub> HubNow;
        public NotificationHub(IHubContext<NotificationHub> Hub)
        {
            HubNow = Hub;
        }
        public async Task OnConnectHub(string UserId, string Chanel)
        {
            var find = UserOnline.FirstOrDefault(c => c.UserId == UserId && c.Chanel == Chanel);

            if (find != null)
            {
                UserOnline.Add(new ModelClient { ConnectionId = Context.ConnectionId, UserId = UserId, Chanel = Chanel });
            }
            else
            {
                UserOnline.Remove(find);
                ModelClient addNew = new ModelClient { ConnectionId = Context.ConnectionId, UserId = UserId, Chanel = Chanel };
                UserOnline.Add(addNew);
            }

            string Ojson = JsonConvert.SerializeObject(new ModelResponseSignelR
            {
                Item = JsonConvert.SerializeObject(new ModelClient { ConnectionId = Context.ConnectionId, UserId = UserId, Chanel = Chanel }),
                Chanel = Chanel
            });

            await Clients.Clients(Context.ConnectionId).SendAsync("OnConnected", Ojson);
        }
        public async Task OnSendNotification(string UserId, string Chanel, string jsonString)
        {
            if (jsonString != null)
            {
                var find = UserOnline.FirstOrDefault(c => c.UserId == UserId && c.Chanel == Chanel);
                if (find != null)
                {
                    string Ojson = JsonConvert.SerializeObject(new ModelResponseSignelR
                    {
                        Item = jsonString,
                        Chanel = Chanel
                    });
                    await HubNow.Clients.Clients(find.ConnectionId).SendAsync("ReceiveNotification", Ojson);
                }
            }
        }
    }
}