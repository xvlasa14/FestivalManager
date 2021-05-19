using System;

namespace FestivalManager.BL.Models
{
    public abstract class ModelBase : IModel
    {
        public Guid Id { get; set; }
    }
}
