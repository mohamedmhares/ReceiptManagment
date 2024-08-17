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
    public class ReceiptRepository : Repository<Receipt> , IReceiptRepository
    {
        public ReceiptRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    }
}
