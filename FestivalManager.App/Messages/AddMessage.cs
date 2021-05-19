using FestivalManager.BL.Models;

namespace FestivalManager.App.Messages
{
    public class AddMessage<T> : Message<T>
        where T : IModel
    {
    }
}
