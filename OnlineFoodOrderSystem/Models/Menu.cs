namespace OnlineFoodOrderSystem.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IList<Menu> Menus { get; set; }
        public IList<Order> Orders { get; set; }
    }   
}
