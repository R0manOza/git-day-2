using FinalTASK4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.WebSockets;

namespace FinalTASK4.Controllers
{
    public class HomeController : Controller
    {
        public void talk()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                WebSocket sock = HttpContext.WebSockets.AcceptWebSocketAsync().Result;
                Dotalking(sock);
            }
        }
        void Dotalking(WebSocket sock)
        {
            byte[] buffer = new byte[1024];
            WebSocketReceiveResult n;
            n = sock.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None).Result;
            String info = System.Text.Encoding.UTF8.GetString(buffer, 0, n.Count);
            String result = new String(info.Reverse().ToArray());
            sock.SendAsync(new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(result)) ,
                WebSocketMessageType.Text , true , CancellationToken.None ).Wait();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
