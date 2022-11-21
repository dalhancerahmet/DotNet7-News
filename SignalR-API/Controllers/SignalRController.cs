using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_API.Hubs;

namespace SignalR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController : ControllerBase
    {
        public async Task SendMessage()
        {
            MyHub hub = new();
            await hub.SendMessage("SignalR ile mesaj gönderildi");
        }
    }
}
