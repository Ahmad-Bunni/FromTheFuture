using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FromTheFuture.API.FutureBox
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutureBoxesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

       
    }
}
