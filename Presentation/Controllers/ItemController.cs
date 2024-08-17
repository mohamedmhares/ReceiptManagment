

using Microsoft.AspNetCore.Mvc;
using ReceiptManagment.Application.Receipt;
using ReceiptManagment.Application.Receipt.DTOs;
using ReceiptManagment.Application.Receipt.Interfaces;
using ReceiptManagment.Core.Receipt;

namespace ReceiptManagment.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IITemService _itemService;

        public ItemController(IITemService itemService)
        {
            _itemService = itemService;
        }
        [HttpPost("CreatItem")]
        public async Task<IActionResult> CreateItem(CreateItemDTO createItemDTO) 
        {
            var id = await _itemService.CreateItem(createItemDTO);
            return Ok(id);
        }
        [HttpGet("GetItemByID")]
        public async Task<ActionResult<GetItemDTO>> GetItembbyID(Guid id) 
        {
            var item = await _itemService.GetItem(id);
            if (item == null ) 
                return NotFound("Item With this Id not Found");
            return Ok(item);
        }
        [HttpPut("UpdateItem")]
        public async Task<ActionResult<UpdateItemDTO>> UpdateItem(UpdateItemDTO updateItemDTO) 
        {
            var item = await _itemService.UpdateItem(updateItemDTO);
            if (item == null ) 
                return NotFound("Item With this Id not Found");
            return Ok(item);
        }
        
    }
}
