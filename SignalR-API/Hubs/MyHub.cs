using Microsoft.AspNetCore.SignalR;

namespace SignalR_API.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessage(string message,string connectionId)
        {
            string logMessage= await Clients.Client(connectionId).InvokeAsync<string>("receiveMessage",message,new());
            
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
