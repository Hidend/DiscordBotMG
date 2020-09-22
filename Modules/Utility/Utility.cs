using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotMG.Modules.Utility
{
    public class Utility : ModuleBase<SocketCommandContext>
    {
        [Command("RandomUser")]
        public async Task RandomUserCommand()
        {
            List<IUser> users = (List<IUser>)Context.Channel.GetUsersAsync();
            Random rnd = new Random();
            int userCount = users.Count();
            await Context.Channel.SendMessageAsync(users[rnd.Next(userCount - 1)].Username);
        }
    }
}
