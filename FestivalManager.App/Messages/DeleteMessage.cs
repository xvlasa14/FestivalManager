using FestivalManager.BL.Models;

namespace FestivalManager.App.Messages
{
    public class DeleteMessage<T> : Message<T>
        where T : IModel
    {
    }
}
