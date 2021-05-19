using System.Collections.Generic;

namespace FestivalManager.BL.Models
{
    public class BandDetailModel :ModelBase
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Genre { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Country { get; set; }

        public ICollection<SlotDetailModel> Slots { get; set; } = new List<SlotDetailModel>();
    }
}
