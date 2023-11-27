namespace HotelBooking.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Booking> Bookings { get; set; }
        public List<Review> Reviews { get; set; }
        public int AccessLevel { get; set; } = 0;
    
    }


}