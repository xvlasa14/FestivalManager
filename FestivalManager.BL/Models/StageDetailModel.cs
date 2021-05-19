using System.Collections.Generic;

namespace FestivalManager.BL.Models
{
    public class StageDetailModel :ModelBase
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Info { get; set; }
        public ICollection<SlotDetailModel> Slots { get; set; } = new List<SlotDetailModel>();
    }
}
