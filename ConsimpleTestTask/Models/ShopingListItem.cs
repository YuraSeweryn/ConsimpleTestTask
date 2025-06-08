using System.ComponentModel.DataAnnotations;

namespace ConsimpleTestTask.Models
{
    public class ShopingListItem
    {
        [Key]
        public int Id { get; set; }

        public int PurchaseId { get; set; }
        public Purchase Purchase{ get; set; }

        public int ItemId { get; set; }
        public Item Item{ get; set; }

        public int Amount { get; set; }
    }
}
