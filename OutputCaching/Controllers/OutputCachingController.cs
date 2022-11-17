using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OutputCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutputCachingController : ControllerBase
    {
        [HttpGet]
        [OutputCache(PolicyName ="CustomCaching")] //OutputCache attribute'ü ile özelleştirdiğimiz ve adına CustomCachig verdiğimiz caching'i devreye sokuyoruz. Action düzeyde uyguladık fakat Controller seviyesinde de uygulanabilmektedir.
        public IActionResult actionResultGet()
        {
            return Ok(DateTime.UtcNow);
        }
    }
}

#region Output Caching

// .Net 7 ile birlikte gelen 3. parti uygulamalarına gerek kalmadan caching işlemleri yapmamızı sağlayan hazır kütüphanedir.
#region Caching Configuration
// Program cs üzerinden yapılır. Bknz: Program.cs
#endregion
#region Caching Kullanımı
//Class veya controller bazında kullanıma uygundur ve attribute ile kullanılır.
#endregion
#endregion
