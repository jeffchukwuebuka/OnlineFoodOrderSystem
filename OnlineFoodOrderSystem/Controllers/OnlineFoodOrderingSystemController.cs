using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderSystem.Data;
using OnlineFoodOrderSystem.Models;
using OnlineFoodOrderSystem.ViewModels;

namespace OnlineFoodOrderSystem.Controllers
{
    [Route("api/foodOrderingSys")]
    [ApiController]
    public class OnlineFoodOrderingSystemController : ControllerBase
    {
        private OnlineFoodOrderingDBContext _dBContext;
        public OnlineFoodOrderingSystemController(OnlineFoodOrderingDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpPost]
        [Route("restaurant/add")]
        public IActionResult AddRestaurant(RestaurantView model)
        {
            var restaurant = new Restaurant
            {
                Name = model.Name,
                Address = model.Address, 
                PhoneNumber = model.PhoneNumber,
                Website = model.Website
            };

            _dBContext.Restaurants.Add(restaurant);
            _dBContext.SaveChangesAsync();
            return Ok();

        }

        [HttpGet]
        [Route("restaurant")]
        public IActionResult GetAllRestaurants()
        {
            var restaurants = _dBContext.Restaurants.ToList();
            if (restaurants.Count > 0)
            {
                return Ok(restaurants);
            }
            return Ok("no records!");
        }

        [HttpGet]
        [Route("restaurant/{id}")]
        public IActionResult GetRestaurant(int id) 
        {
            var restaurant = _dBContext.Restaurants.Where(x => x.Id == id).FirstOrDefault();
            if (restaurant != null)
            {
                return Ok(restaurant);
            }
            return Ok("Record not found!");
        }

        [HttpPost]
        [Route("menu/add")]
        public IActionResult AddMenus(MenuView model)
        {
            var menu = new Menu
            {
                 Name = model.Name,
                 RestaurantID = model.RestaurantID,
                 Description = model.Description,
                 Price = model.Price
            };
            _dBContext.Menus.Add(menu);
            _dBContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("restaurants/{id}/menus")]
        public IActionResult GetMenus(int id)
        {
            var restaurant = _dBContext.Restaurants.Where(x => x.Id == id).FirstOrDefault(); 
            var menus = restaurant.Menus;
            if (menus != null)
            {
                return Ok(menus);
            }
            return Ok("No records!");
        }

        [HttpPost]
        [Route("orders")]
        public IActionResult AddOrder(OrderView model)
        {
            var order = new Order
            {

                MenuID = model.MenuID,
                Quantity = model.Quantity,
                RestaurantID = model.RestaurantID
            };
            _dBContext.Orders.Add(order);
            _dBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("orders/{id}")]
        public IActionResult GetOrders(int id)
        {
            var order = _dBContext.Orders.Where(x => x.Id == id).FirstOrDefault();
            
            if (order != null)
            {
                return Ok(order);
            }
            return Ok("No records!");
        }
    }
}
