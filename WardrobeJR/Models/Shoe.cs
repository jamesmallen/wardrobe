using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WardrobeJR.Models
{
    public class Shoe
    {
        public int ShoeId { get; set; }
        public string ShoeName { get; set; }
        public string ShoePhoto { get; set; }
        public int? ColorId { get; set; }
        public int? SeasonId { get; set; }
        public int? OccasionId { get; set; }

        public virtual Color Color { get; set; }
        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }

        public virtual ICollection<Outfit> Outfits { get; set; }

    }
}