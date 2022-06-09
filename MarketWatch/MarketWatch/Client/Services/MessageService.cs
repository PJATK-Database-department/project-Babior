using System;
using MarketWatch.Client.Services.Contracts;

namespace MarketWatch.Client.Services
{
    public class MessageService : IMessageService
    {
        public event Action<string> OnState;

        public void SendMessage(string message)
        {
            OnState?.Invoke(message);
        }
    }
}