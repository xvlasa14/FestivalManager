using System;
using FestivalManager.App.Messages;


namespace FestivalManager.App.Services
{
    public interface IMediator
    {
        void Register<TMessage>(Action<TMessage> action)
            where TMessage : IMessage;
        void Send<TMessage>(TMessage message)
            where TMessage : IMessage;
    }
    
}
