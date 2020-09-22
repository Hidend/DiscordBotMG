using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotMG.Modules.Utility
{
    [Summary("Utility commands module")]
    public class RandomUser : ModuleBase<SocketCommandContext>
    {
        [Command("randomuser")]
        [Summary("Mentions random user from the whole server or from the specified role")]
        public async Task RandomUserCommand([Summary("The role from where the user is going to be taken")]IRole role)
        {
            String response;
            try
            {
                var users = Context.Guild.Users;
                Random rnd = new Random();
                var ServerRoles = Context.Guild.Roles;
                var roleUsers = users.Where(user => user.Roles.Contains(role));
                response = getRandomUser(rnd, roleUsers).Mention;
            }
            catch (Exception e)
            {
                response = "The specified role does not exist in the current server";
            }

            await Context.Channel.SendMessageAsync(response);
            
        }

        [Command("randomuser")]
        public async Task RandomUserCommand()
        {
            String response;
            var users = Context.Guild.Users;
            Random rnd = new Random();
            response = getRandomUser(rnd, users).Mention;
            await Context.Channel.SendMessageAsync(response);

        }

        private SocketGuildUser getRandomUser(Random rnd, IEnumerable<SocketGuildUser> users)
        {
            int userCount = users.Count();
            return users.ElementAt(rnd.Next(userCount));
        }
    }


}
