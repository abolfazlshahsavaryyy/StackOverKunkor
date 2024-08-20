using System.ComponentModel.DataAnnotations;

namespace Konkor.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Username {  get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
