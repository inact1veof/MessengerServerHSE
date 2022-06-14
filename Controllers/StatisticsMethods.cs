using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;


namespace WebApi
{
    public class StatisticsMethods
    {
        public static async Task<ActionResult<UserStatistics>> GetUserStatistics(int UserId, WebApiContext _context)
        {
            var chats = await _context.Chat.Where(p => p.Members.Contains(UserId)).ToListAsync();
            int chatCount = chats.Count();

            int mesCount = 0;
            foreach (var chat in chats)
            {
                var mes = await _context.Message.Where(p => p.ReceiverChatId == chat.Id && p.SenderUserId == UserId).ToListAsync();
                mesCount += mes.Count();
            }

            var files = await _context.File.Where(f => f.OwnerId == UserId).ToListAsync();
            int filesCount = files.Count();

            UserStatistics user = new UserStatistics { CountChats = chatCount, CountMessages = mesCount, CountFiles = filesCount };
            
            return user;
        }

        public static async Task<ActionResult<AdminStatistics>> GetAdminStatistics(WebApiContext _context)
        {
            var users = await _context.User.ToListAsync();
            int userCount = users.Count();

            var chats = await _context.Chat.ToListAsync();
            int chatCount = chats.Count();

            var mes = await _context.Message.ToListAsync();
            int mesCount = mes.Count();
            int avMesCount = mesCount;
            if (chatCount != 0) avMesCount /= chatCount;

            int avChatUsers = 0;
            TimeSpan time = TimeSpan.Zero;
            foreach (var chat in chats)
            {
                avChatUsers += chat.Members.Count();
                time += DateTime.Now - chat.CreationDate;
            }
            if (chatCount != 0) avChatUsers /=  chatCount;

            int freq = 0;
            if (chatCount != 0) freq = (int)(mesCount / time.Seconds);

            AdminStatistics stat = new AdminStatistics { CountChats = chatCount, CountUsers = userCount, 
                AverageNumberChatUsers = avChatUsers, AverageNumberMessages = avMesCount, Frequency = freq};
            
            return stat;
        }

        public static async Task<ActionResult<ChatStatistics>> GetChatStatistics(int ChatId, WebApiContext _context)
        {
            var chat = await _context.Chat.FirstOrDefaultAsync(p => p.Id == ChatId);

            var userCount = chat.Members.Count();

            var mes = await _context.Message.Where(p => p.ReceiverChatId == chat.Id).ToListAsync();
            var mesCount = mes.Count();

            TimeSpan time = DateTime.Now - chat.CreationDate;

            ChatStatistics stat = new ChatStatistics { CountMessages = mesCount, CountUsers = userCount, LifeTime = time };

            return stat;
        }
    }
}
