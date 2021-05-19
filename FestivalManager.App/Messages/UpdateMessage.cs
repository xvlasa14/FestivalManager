using FestivalManager.BL.Models;

namespace FestivalManager.App.Messages
{
    public class UpdateMessage<T> : Message<T>
        where T : IModel
    {
    }
}
