using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WardrobeJR.Models
{
    public class Outfit
    {
        public Outfit()
        {
            Accessories = new HashSet<Accessory>();
        }

        public int OutfitId { get; set; }
        public int TopId { get; set; }
        public int BottomId { get; set; }
        public int ShoeId { get; set; }

        public virtual Top Top { get; set; }
        public virtual Bottom Bottom { get; set; }
        public virtual Shoe Shoe { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }
    }
}