﻿using System.ComponentModel.DataAnnotations;

namespace ConsimpleTestTask.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
