using System.ComponentModel.DataAnnotations;

namespace Konkor.Models
{
    public class Talk
    {
        [Key]
        public int Id { get; set; }
        public string Question {  get; set; }
        public string? Answer { get; set; }

    }
}
