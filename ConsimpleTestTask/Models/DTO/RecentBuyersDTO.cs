﻿namespace ConsimpleTestTask.Models.DTO
{
    public class RecentBuyersDTO
    {
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public DateTime? LastPurchaseDate { get; set; }
    }
}
