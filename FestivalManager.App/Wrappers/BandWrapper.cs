using FestivalManager.BL.Models;

namespace FestivalManager.App.Wrappers
{
    public class BandWrapper : ModelWrapper<BandDetailModel>
    {
        public BandWrapper(BandDetailModel model)
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

        public string Genre
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string LongDescription
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string ShortDescription 
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Country
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public static implicit operator BandWrapper(BandDetailModel detailModel)
            => new(detailModel);

        public static implicit operator BandDetailModel(BandWrapper wrapper)
            => wrapper.Model;
    }
}
