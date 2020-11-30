namespace SwaggerLoggerProject.Models
{
    public class ReservationMenuItems
    {
        public int Id { set; get; }
        public int MenuItemId { set; get; }
        public int ReservationId { set; get; }
        public Reservation Reservation { set; get; }
        public MenuItem MenuItem { set; get; }
    }
}
