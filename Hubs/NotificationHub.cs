using AppApi.Models.ModelSignelR;
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
        public async Task OnConnectHub(string UserId, string Channel)
        {
            var find = UserOnline.FirstOrDefault(c => c.UserId == UserId && c.Channel == Channel);

            if (find != null)
            {
                UserOnline.Add(new ModelClient { ConnectionId = Context.ConnectionId, UserId = UserId, Channel = Channel });
            }
            else
            {
                UserOnline.Remove(find);
                ModelClient addNew = new ModelClient { ConnectionId = Context.ConnectionId, UserId = UserId, Channel = Channel };
                UserOnline.Add(addNew);
            }

            string Ojson = JsonConvert.SerializeObject(new ModelResponseSignelR
            {
                Item = JsonConvert.SerializeObject(new ModelClient { ConnectionId = Context.ConnectionId, UserId = UserId, Channel = Channel }),
                Channel = Channel
            });

            await Clients.Clients(Context.ConnectionId).SendAsync("OnConnected", Ojson);
        }
        public async Task<bool> OnSendNotificationAsync(string UserId, string Channel, string jsonString)
        {
            if (jsonString != "" && UserId != "" && Channel != "")
            {
                var user = UserId.Split(',');
                if (user.Count() == 1)
                {
                    var find = UserOnline.FirstOrDefault(c => c.UserId == user[0] && c.Channel == Channel);
                    if (find != null)
                    {
                        string Ojson = JsonConvert.SerializeObject(new ModelResponseSignelR
                        {
                            Item = jsonString,
                            Channel = Channel
                        });
                        await HubNow.Clients.Clients(find.ConnectionId).SendAsync("ReceiveNotification", Ojson);
                        return true;
                    }
                }
                else
                {
                    foreach (var users in user)
                    {
                        var find = UserOnline.FirstOrDefault(c => c.UserId == users && c.Channel == Channel);
                        if (find != null)
                        {
                            string Ojson = JsonConvert.SerializeObject(new ModelResponseSignelR
                            {
                                Item = jsonString,
                                Channel = Channel
                            });
                            await HubNow.Clients.Clients(find.ConnectionId).SendAsync("ReceiveNotification", Ojson);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}