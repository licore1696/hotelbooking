namespace HotelBooking.DataAccess.Repository
{
    public class BaseRepository
    {
        public readonly BookingContext _context;

        public BaseRepository(BookingContext context)
        {  
            _context = context; 
        }
    }
}
