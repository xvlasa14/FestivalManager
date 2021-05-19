using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FestivalManager.DAL.Entities
{
    public class Band : EntityBase
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Genre { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Country { get; set; }
        public ICollection<Slot> Slots { get; } = new List<Slot>();

        private sealed class BandEqualityComparer : IEqualityComparer<Band>
        {
            public bool Equals(Band x, Band y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null) return false;
                if (y is null) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id) && x.Name == y.Name
                                         && StructuralComparisons.StructuralEqualityComparer.Equals(x.Image, y.Image)
                                         && x.Genre == y.Genre
                                         && x.LongDescription == y.LongDescription
                                         && x.ShortDescription == y.ShortDescription
                                         && x.Country == y.Country;
            }

            public int GetHashCode(Band obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.Id);
                hashCode.Add(obj.Name);
                hashCode.Add(obj.Image);
                hashCode.Add(obj.Genre);
                hashCode.Add(obj.LongDescription);
                hashCode.Add(obj.ShortDescription);
                hashCode.Add(obj.Country);
                hashCode.Add(obj.Slots);
                return hashCode.ToHashCode();
            }
        }

        public static IEqualityComparer<Band> BandComparer { get; } = new BandEqualityComparer();
    }
}
