using System;
using FestivalManager.BL.Models;

namespace FestivalManager.App.Wrappers
{
    public class SlotWrapper : ModelWrapper<SlotDetailModel>
    {
        public SlotWrapper(SlotDetailModel model)
            : base(model)
        {
        }

        public DateTime StartTime
        {
            get => GetValue<DateTime>();
            set => SetValue(value);
        }

        public DateTime EndTime
        {
            get => GetValue<DateTime>();
            set => SetValue(value);
        }

        public Guid BandId
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        public Guid StageId
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        public static implicit operator SlotWrapper(SlotDetailModel detailModel)
            => new(detailModel);

        public static implicit operator SlotDetailModel(SlotWrapper wrapper)
            => wrapper.Model;
    }
}
