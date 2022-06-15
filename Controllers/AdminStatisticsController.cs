using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.Swagger.Annotations;
using WebApi;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminStatisticsController : ControllerBase
    {
        private readonly WebApiContext _context;

        public AdminStatisticsController(WebApiContext context)
        {
            _context = context;
        }
        [DisableCors]
        // GET: api/AdminStatistics
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AdminStatistics>> GetStatistics()
        {
            return await StatisticsMethods.GetAdminStatistics(_context);
        }
    }
}
