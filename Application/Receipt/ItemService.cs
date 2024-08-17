using Core.Shared;
using ReceiptManagment.Application.Receipt.DTOs;
using ReceiptManagment.Application.Receipt.Interfaces;
using ReceiptManagment.Core.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Application.Receipt
{
    public class ItemService : IITemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> CreateItem(CreateItemDTO createItemDTO)
        {
            var item = new Item()
            {
                Balance = createItemDTO.Balance,
                Name = createItemDTO.Name,
                ItemPrice = createItemDTO.ItemPrice
            };
            
            await _itemRepository.InsertAsync(item);
            await _unitOfWork.CommitAsync();
            return item.Id;
        }

        public async Task<GetItemDTO> GetItem(Guid id)
        {

           var Item = await _itemRepository.GetByIdAsync(id);
            if (Item == null)
                return null;
            var ItemDTO = new GetItemDTO()
            {
                Balance = Item.Balance, 
                Id = Item.Id,
                Name = Item.Name,
                ItemPrice = Item.ItemPrice,
            };

           
           return ItemDTO;
        }
        public async Task<UpdateItemDTO> UpdateItem(UpdateItemDTO updateItemDTO)
        {
            var item = await _itemRepository.GetByIdAsync(updateItemDTO.Id) ;
            if (item == null)
                return null;
            item.Balance = updateItemDTO.Balance;
            item.Name = updateItemDTO.Name;
            item.ItemPrice = updateItemDTO.ItemPrice;
            await _itemRepository.UpdateAsync(item);
            await _unitOfWork.CommitAsync();
            return updateItemDTO;
           
        }
    }
}
