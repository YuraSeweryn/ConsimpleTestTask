using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsimpleTestTask.Models
{
    public class Item
    {
        [Key]
        public int Article { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public float Price { get; set; }
    }
}
