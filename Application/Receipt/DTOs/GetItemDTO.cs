using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Application.Receipt.DTOs
{
    public class GetItemDTO : CreateItemDTO
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
    }
}
