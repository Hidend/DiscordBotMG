using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotMG.Modules
{
	public class Ping : ModuleBase<SocketCommandContext>
	{
		[Command("ping")]
        [Summary("Te devuelve pong!")]
        public async Task PingCommand()
        {
            await Context.Channel.SendMessageAsync("Pong!");
        }
    }
}
