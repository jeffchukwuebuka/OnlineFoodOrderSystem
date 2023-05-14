namespace OnlineFoodOrderSystem.Models
{
    public class Order
    {
        public int Id { get; set; } 
        public int MenuID { get; set; }
        public Menu Menus { get; set; }
        public int RestaurantID { get; set; }   
        public Restaurant Restaurants { get; set; }
        public int Quantity{ get; set; }
    }
}
