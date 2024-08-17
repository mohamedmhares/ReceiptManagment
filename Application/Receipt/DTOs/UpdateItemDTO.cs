using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Application.Receipt.DTOs
{
    public class UpdateItemDTO : CreateItemDTO
    {
       public Guid Id { get; set; }
    }
}
