using Sinina.OnlineShop.API.Authentication;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Sinina.OnlineShop.API.Controllers
{
    [RoutePrefix("api/Items")]
    public class ItemsController : ApiController
    {
        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(Item.CreateItems());
        }
    }


    #region Helpers

    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public bool Shippable { get; set; }


        public static List<Item> CreateItems()
        {
            List<Item> ItemList = new List<Item>
            {
                new Item { ItemID = 10248, ItemName = "Taiseer Joudeh", ItemPrice = 500, Shippable = true },
                new Item { ItemID = 10249, ItemName = "Ahmad Hasan", ItemPrice = 300, Shippable = false},
                new Item { ItemID = 10250, ItemName = "Tamer Yaser", ItemPrice = 320, Shippable = false },
                new Item { ItemID = 10251, ItemName = "Lina Majed", ItemPrice = 540, Shippable = false},
                new Item { ItemID = 10252, ItemName = "Yasmeen Rami", ItemPrice = 1020, Shippable = true}
            };

            return ItemList;
        }
    }

    #endregion
}
