using System;
using MarketWatch.Client.Services.Contracts;

namespace MarketWatch.Client.Services
{
    public class MessageService : IMessageService
    {
        public event Action OnState;

        public void SendMessage()
        {
            OnState?.Invoke();
        }
    }
}