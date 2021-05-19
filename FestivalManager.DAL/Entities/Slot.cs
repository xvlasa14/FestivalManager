using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.DAL.Entities
{
    public class Slot : EntityBase
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Stage Stage { get; set; }
        public Guid StageId { get; set; }
        public Band Band { get; set; }
        public Guid BandId { get; set; }

        private sealed class SlotEqualityComparer : IEqualityComparer<Slot>
        {
            public bool Equals(Slot x, Slot y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null) return false;
                if (y is null) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id) && x.StartTime.Equals(y.StartTime) 
                                         && x.EndTime.Equals(y.EndTime) 
                                         && Entities.Stage.StageComparer.Equals(x.Stage, y.Stage)
                                         && x.StageId == y.StageId
                                         && Entities.Band.BandComparer.Equals(x.Band, y.Band)
                                         && x.BandId == y.BandId;
            }

            public int GetHashCode(Slot obj)
            {
                return HashCode.Combine(obj.Id, obj.StartTime, obj.EndTime, obj.Stage, obj.Band);
            }
        }

        public static IEqualityComparer<Slot> SlotComparer { get; } = new SlotEqualityComparer();
    }
}
