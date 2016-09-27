using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WardrobeJR.Models
{
    public class Bottom
    {
        public int BottomId { get; set; }
        public string BottomName { get; set; }
        public string BottomPhoto { get; set; }
        [Required]
        public int? ColorId { get; set; }
        [Required]
        public int? SeasonId { get; set; }
        [Required]
        public int? OccasionId { get; set; }

        public virtual Color Color { get; set; }
        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }

        public virtual ICollection<Outfit> Outfits { get; set; }

    }
}