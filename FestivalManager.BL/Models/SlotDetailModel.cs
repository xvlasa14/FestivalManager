using System;

namespace FestivalManager.BL.Models
{
    public class SlotDetailModel :ModelBase
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid StageId { get; set; }
        public StageListModel Stage { get; set; }
        public Guid BandId { get; set; }
        public BandListModel Band { get; set; }

    }
}
