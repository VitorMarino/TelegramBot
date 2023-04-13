using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;


namespace Atividade.telegram.bot
{
    public class TelegramBot
    {
        TelegramBotClient botClient = new TelegramBotClient("6252101320:AAGYyOPQvfpW7wnORbBSczON4p_6vQbNdOs");

        CancellationTokenSource cancellantionToken = new CancellationTokenSource();


        public void AcionarBot()
        {
            botClient.StartReceiving(
                 updateHandler: UpdateHandlerAsync,
                 pollingErrorHandler: PollingErrorHandlerAsync,
                 receiverOptions: new ReceiverOptions
                 {
                     AllowedUpdates = Array.Empty<UpdateType>()
                 },
             cancellationToken: cancellantionToken.Token);
        }

        Task PollingErrorHandlerAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cts)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }

        async Task UpdateHandlerAsync(ITelegramBotClient botClient, Update update, CancellationToken cts)
        {
            if (update.Message is not { } message)
                return;

            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;



            Console.WriteLine($"Mensagem recebida: {messageText}");
            if (message.Text == "1")
            {
                var enviarMensagem1 = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Você pode agendar os exames entrando em contato no nosso número de atendimento: (11)97530-9215",
                    cancellationToken: cts);
            }
            else if(message.Text == "2") 
            {
                var enviarMensagem2 = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Aceitamos convênios da Porto Seguro,  Intermédica e Plena Saúde\r\n",
                    cancellationToken: cts);
            }
            else if(message.Text == "3")
            {
                var enviarMensagem3 = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "As consultas podem ser feitas entrando em contato no nosso número de atendimento: (11)99907-8760",
                    cancellationToken: cts);
            }
            else if(message.Text == "4")
            {
                var enviarMensagem4 = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Para realização de procedimentos sem convênio cobramos uma taxa para realizar a consulta com nossos especialistas, para agendar consultas entre em contato no número (11)99907-8760",
                    cancellationToken: cts);
            }
            else if(message.Text == "5")
            {
                var enviarMensagem5 = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Localização: Bairro Casa Verde, São Paulo, N°315\r\nContato:\r\n    - Exames: (11)97530-9215\r\n    - Consultas: (11)99907-8760",
                    cancellationToken: cts);
            }
            else 
            {
                var conteudoBoasVindas = "Hospital Casa Verde\r\nOlá, eu sou a Alana. Estou aqui para tirar dúvidas a respeito do nosso hospital.\r\nAs principais dúvidas são:\r\n1. Como agendo exames?\r\n2. Quais convênios são aceitos?\r\n3. Como faço o agendamento de consultas?\r\n4. Realização de procedimentos sem convênio?\r\n5. Endereço e telefones de contato.";
                var enviarMensagem6 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: conteudoBoasVindas,
                        cancellationToken: cts
                    );
            }
            
        }
    }
}
