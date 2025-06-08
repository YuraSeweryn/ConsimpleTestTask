using ConsimpleTestTask.Models;
using ConsimpleTestTask.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly Context _dbContext;
        public ClientsController(Context context)
        {
            _dbContext = context;
        }

        [HttpGet("ClientsWithBirthdays")]
        public IEnumerable<ClientDTO> GetClientsWithBirthdays(DateTime date)
        {
            return _dbContext.Clients
                .Where(u => u.Bithdate.Month == date.Month && u.Bithdate.Day == date.Day)
                .Select(u => new ClientDTO { Id = u.Id, FullName = u.FullName });
        }

        [HttpGet("RecentBuyers")]
        public IEnumerable<RecentBuyersDTO> GetRecentBuyers(int numberOfDays)
        {
            var dateFrom = DateTime.Now.AddDays(-numberOfDays);
            return _dbContext.Clients
                .Include(c => c.Purchases)
                .Select(c => new RecentBuyersDTO
                {
                    ClientId = c.Id,
                    FullName = c.FullName,
                    LastPurchaseDate = c.Purchases
                        .Where(p => p.Date >= dateFrom)
                        .OrderByDescending(p => p.Date)
                        .FirstOrDefault().Date
                })
                .Where(c => c.LastPurchaseDate != null);
        }

        [HttpGet("ClientsCategories")]
        public IEnumerable<ClientCategoriesDTO> GetClientsCategories(int clientId)
        {
            var clientShopingItems = _dbContext.Purchases
                .Where(p => p.ClientId == clientId)
                .Include(p => p.ShopingListItems)
                .ThenInclude(sli => sli.Item)
                .ThenInclude(i => i.Category)
                .SelectMany(p => p.ShopingListItems);

            return clientShopingItems.GroupBy(sli => sli.Item.Category.Name)
                .Select(g => new ClientCategoriesDTO
                {
                    CategoryName = g.Key,
                    ProductCount = g.Count()
                });
        }
    }
}
