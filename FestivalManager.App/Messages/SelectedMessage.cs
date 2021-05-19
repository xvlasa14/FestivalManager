using FestivalManager.BL.Models;

namespace FestivalManager.App.Messages
{
    public class SelectedMessage<T> : Message<T>
        where T : IModel
    {
    }
}
