using ReceiptManagment.Application.Receipt.DTOs;
using ReceiptManagment.Core.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Application.Receipt.Interfaces
{
    public interface IITemService
    {
        Task<Guid> CreateItem(CreateItemDTO createItemDTO);
        Task<GetItemDTO> GetItem(Guid id);
        Task<UpdateItemDTO> UpdateItem(UpdateItemDTO updateItemDTO);
    
    }
}
