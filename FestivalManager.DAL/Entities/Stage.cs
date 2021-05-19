using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FestivalManager.DAL.Entities
{
    public class Stage : EntityBase
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Info { get; set; }
        public virtual ICollection<Slot> Slots { get; } = new List<Slot>();

        private sealed class StageEqualityComparer : IEqualityComparer<Stage>
        {
            public bool Equals(Stage x, Stage y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null) return false;
                if (y is null) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id) && x.Name == y.Name
                                         && StructuralComparisons.StructuralEqualityComparer.Equals(x.Image, y.Image)
                                         && x.Info == y.Info;
            }

            public int GetHashCode(Stage obj)
            {
                return HashCode.Combine(obj.Id, obj.Name, obj.Image, obj.Info, obj.Slots);
            }
        }

        public static IEqualityComparer<Stage> StageComparer { get; } = new StageEqualityComparer();
    }
}
