using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
    public class UserStatisticsController : ControllerBase
    {
        private readonly WebApiContext _context;

        public UserStatisticsController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/UserStatistic/5
        [HttpGet("{UserId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserStatistics>> GetStatistics(int UserId)
        {
            var user = await StatisticsMethods.GetUserStatistics(UserId, _context);
            return user;
        }
       
    }
}
