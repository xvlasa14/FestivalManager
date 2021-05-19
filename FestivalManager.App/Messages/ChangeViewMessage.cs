using FestivalManager.BL.Models;

namespace FestivalManager.App.Messages
{
    public class ChangeViewMessage<T> : Message<T>
        where T : IModel
    {
    }
}
