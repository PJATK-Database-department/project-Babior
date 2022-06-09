using System;

namespace MarketWatch.Client.Services.Contracts
{
    public interface IMessageService
    {
        event Action OnState;
        void SendMessage();
    }
}