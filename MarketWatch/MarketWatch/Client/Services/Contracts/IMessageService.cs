using System;

namespace MarketWatch.Client.Services.Contracts
{
    public interface IMessageService
    {
        event Action<string> OnState;
        void SendMessage(string message);
    }
}