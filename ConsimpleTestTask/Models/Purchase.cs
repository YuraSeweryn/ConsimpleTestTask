using System.ComponentModel.DataAnnotations;

namespace ConsimpleTestTask.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public float TotalCost { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<ShopingListItem> ShopingListItems { get; set; }
    }
}
