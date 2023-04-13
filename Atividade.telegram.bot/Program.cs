// See https://aka.ms/new-console-template for more information
using Atividade.telegram.bot;
using Telegram.Bot;

Console.WriteLine("BOT INICIADO");

var bot = new TelegramBot();
bot.AcionarBot();

Console.ReadKey();



