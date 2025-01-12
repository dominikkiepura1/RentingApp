namespace RentingApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public int ItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
