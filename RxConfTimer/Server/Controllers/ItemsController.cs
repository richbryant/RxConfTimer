using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RxConfTimer.Server.Data;
using RxConfTimer.Shared.Models;

namespace RxConfTimer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsData _data;

        public ItemsController(IItemsData data) => _data = data;

        [HttpGet]
        public async Task<IActionResult> Get()
            => await _data.TryGetItems()
                .ToActionResult();

        [HttpPost]
        public async Task<IActionResult> UpdateTime(Item item)
            => await _data.TryUpdateItem(item)
                .ToActionResult();
    }
}
