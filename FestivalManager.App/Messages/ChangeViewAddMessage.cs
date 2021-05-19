using FestivalManager.BL.Models;

namespace FestivalManager.App.Messages
{
    public class ChangeViewAddMessage<T> : Message<T>
        where T : IModel
    {
    }
}
