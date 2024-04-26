using System.ComponentModel.DataAnnotations;

namespace CRUDinASP.netCoreMVC.Models
{
    public class Products1
    {
        [Key]
        public int Pid { get; set; } 
        public string? Pname { get; set; }    
        public string? Pcat { get; set; }
        public decimal? Price { get; set; }

    }
}
