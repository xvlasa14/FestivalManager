using FestivalManager.BL.Models;

namespace FestivalManager.App.Messages
{
    public class DetailViewMessage<T> : Message<T>
        where T : IModel
    {
    }
}
