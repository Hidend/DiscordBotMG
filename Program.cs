﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBotMG.Services;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBotMG
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            using (var services = ConfigureServices())
            {
                var client = services.GetRequiredService<DiscordSocketClient>();

                await client.LoginAsync(TokenType.Bot, " ");
                await client.StartAsync();

                await services.GetRequiredService<CommandHandlingService>().InitializeAsync();

                await Task.Delay(-1);
            }
        }

        private ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                .BuildServiceProvider();
        }
    }
}
