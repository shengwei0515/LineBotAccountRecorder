using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
<<<<<<< HEAD
//using LineBotAccountRecorder.Core.Models.DTO;
=======
using LineBotAccountRecorder.Core.Models.DTO;
>>>>>>> TBD: add a service and repository to quert database

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

<<<<<<< HEAD
        //[HttpPost]
        //[Route("AddDebt")]
        //public async Task<DtoDebt> AddDebt([FromBody] DtoDebt dtoDebt)
        //{
        //    return dtoDebt;
        //}
=======
        [HttpPost]
        [Route("AddDebt")]
        public async Task<DtoDebt> AddDebt([FromBody] DtoDebt dtoDebt)
        {
            return dtoDebt;
        }
>>>>>>> TBD: add a service and repository to quert database
    }
}
