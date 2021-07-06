using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using LineBotAccountRecorder.Core.Models.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LineBotAccountRecorder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopController : Controller
    {
        private readonly ILogger<DevelopController> logger = null;

        public DevelopController(
            ILogger<DevelopController> logger
            )
        {
            this.logger = logger;
        }

        //[HttpPost]
        //[Route("AddDebt")]
        //public async Task<DtoDebt> AddDebt([FromBody] DtoDebt dtoDebt)
        //{
        //    return dtoDebt;
        //}
    }
}
