using System.ComponentModel.DataAnnotations;

namespace ConsimpleTestTask.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime Bithdate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
