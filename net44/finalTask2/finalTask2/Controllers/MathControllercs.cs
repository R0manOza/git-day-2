using Microsoft.AspNetCore.Mvc;

namespace finalTask2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathControllercs : ControllerBase
    {
        [HttpPost]
        public double Square(double x, double y)
        {
            return x * x + y * y;
        }
    }
}
