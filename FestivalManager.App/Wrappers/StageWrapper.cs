using FestivalManager.BL.Models;

namespace FestivalManager.App.Wrappers
{
    public class StageWrapper : ModelWrapper<StageDetailModel>
    {
        public StageWrapper(StageDetailModel model)
            : base(model)
        {
        }

        public string Name
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Image
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Info
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public static implicit operator StageWrapper(StageDetailModel detailModel)
            => new(detailModel);

        public static implicit operator StageDetailModel(StageWrapper wrapper)
            => wrapper.Model;
    }
}
