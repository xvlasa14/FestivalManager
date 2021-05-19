using System;
using FestivalManager.BL.Models;

namespace FestivalManager.App.Messages
{
    public abstract class Message<T> : IMessage
        where T : IModel
    {
        private Guid? _id;

        public Guid Id
        {
            get => _id ?? Model.Id;
            set => _id = value;
        }
        public T Model { get; set; }
    }
}
