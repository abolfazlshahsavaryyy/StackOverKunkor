using System.ComponentModel.DataAnnotations;

namespace Konkor.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string RamsShab {  get; set; }
    }
}
