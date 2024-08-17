using Infrastructure.Peresistence.Data;
using Infrastructure.Peresistence.Shared;
using ReceiptManagment.Core.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Infrastructure.Peresistence.ReceiptManagment
{
    public class ItemRepository : Repository<Item> , IItemRepository 
    {
        public ItemRepository(ApplicationDbContext dbContext) : base(dbContext) { }
     
    }
}
