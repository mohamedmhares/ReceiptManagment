using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Application.Receipt.DTOs
{
    public class CreateItemDTO
    {
        public string Name { get; set; }
        [Range(0,int.MaxValue)]
        public int Balance { get; set; }
        [Range(0,double.MaxValue)]
        public decimal ItemPrice { get; set; }
    }
}
