using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.RateLimiting;
namespace DotNet7_News.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateLimitTestController : ControllerBase
    {
        [HttpGet]
        [EnableRateLimiting("basicLimiter")]
        public IActionResult RateLimitControl()
        {
            return Ok();
        }

        [HttpGet("DisableRateLimitingFunction")]
        [DisableRateLimiting] //RateLimiter'ı bu attribute ile devre dışı bırakabiliyoruz.
        public IActionResult DisableRateLimit()
        {
            return Ok();
        }

        
    }
}
#region RateLimiter Nedir?
//Client tarafından yapılan requestleri sınırlamayı sağlayan yapıdır. Microsoft.AspNetCore.RateLimiting kütüphanesi kullanılarak configure edilmektedir. DotNet 7 ile gelen özelliktir. 
#endregion
#region Fixed Window
//Sabit bir zaman aralığı kullanarak istekleri sınırlandıran algoritmadır.
#endregion
#region Sliding Window
//Fixed Windows algoritmasına benzerlik göstermektedir. Her sabit sürede bir zamana aralığında istekleri sınırlandırmamaktadır. Lakin sürenin yaırısndan sonra diğer periyodun request kotasını harcayacak şekilde istekleri karşılar.
#endregion
#region Token Bucket
//Her periyotta işlenecek request sayısı kadar token üretilmektedir. Eğer ki bu tokenlar kullanıldıysa diğer periyottan borç alınabilir. Lakin her periyotta token üretim miktarı kadar token üretilecek ve bu şekilde rate limit uygulanacaktır. Şunu unutmamak lazımdır ki, her periyoun maximum token limiti verilen sabit sayı kadar olacaktır.
#endregion
#region Concurrency
//Asenkron requestleri sınırlanmak için kullanılan bir algoritmadır. Her istek concurrency sınırını bir azaltmakta ve bittikleri taktirde bu sınırı bir arttırmaktadırlar. Diğer algoritmalara nazaran sadece asenkron requestleri sınırlandırır. 
#endregion

#region Attribute'lar
#region EnableRateLimiting
//Controller yahut action seviyesinde istenilen politikada rate limiti devreye sokmamızı sağlayan bir attribute'dur.
#endregion
#region DisableRateLimiting
//Controller seviyesinde devreye sokulmuş bir rate limit politikasıonın action seviyesinde pasifleştirilmesini sağlayan bir attributedur.
#endregion
#endregion

#region Minimal API'lar da Rate Limiting
//RequireRateLimiting
#endregion

#region OnRejected Property'si
//Rate limit uygulanan operasyonlarda sınırdan dolayı boşa çıkan request'lerin söz konusu olduğu durumlarda loglama vs. gibi işlemleri yapabilmek için kullandıuımız event mantığında bir properydir.

//options.AddFixedWindowLimiter("basicLimiter", opt =>
//{
//    opt.Window = TimeSpan.FromSeconds(10);
//    opt.PermitLimit = 5;
//    opt.QueueLimit = 5;
//    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//});
//options.OnRejected (context, calcellationToken) =>
//{
//    //Loglama vs işlemleri yapılır.
//    return new();
//};
#endregion

