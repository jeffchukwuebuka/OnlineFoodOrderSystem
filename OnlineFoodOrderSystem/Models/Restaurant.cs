namespace OnlineFoodOrderSystem.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public IList<Menu>Menus { get; set; }  
        public IList<Order> Orders { get; set; }    
    }
}
