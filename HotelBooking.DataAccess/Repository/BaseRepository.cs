using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
