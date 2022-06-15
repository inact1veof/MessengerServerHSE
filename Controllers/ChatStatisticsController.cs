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
    public class ChatStatisticsController : ControllerBase
    {
        private readonly WebApiContext _context;

        public ChatStatisticsController(WebApiContext context)
        {
            _context = context;
        }
        [DisableCors]
        // GET: api/UserStatistic/5
        [HttpGet("{ChatId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ChatStatistics>> GetStatistics(int ChatId)
        {
            var chat = await StatisticsMethods.GetChatStatistics(ChatId, _context);
            return chat;
        }

    }
}
