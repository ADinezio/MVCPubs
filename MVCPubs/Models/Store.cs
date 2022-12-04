using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVCPubs.Models
{
    public partial class Store
    {
        public Store()
        {
            Sales = new HashSet<Sales>();
        }

        [Key]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string StorId { get; set; }
        [Display(Name ="Stor Name")]
        [Required(ErrorMessage ="Campo obligatorio")]
        public string StorName { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Stor Address")]
        public string StorAddress { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string City { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string State { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Zip { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}
