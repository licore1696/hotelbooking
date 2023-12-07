
using HotelBooking.BookingDTO.RoomDtos;
using HotelBooking.Services;



namespace HotelBooking.UnitTests.Services
{
    // Ваш код и пространства имен...

    // Используйте NuGet для установки xunit
    

    // ...

    public class HotelServiceTests
    {
        [Fact]
        public void IsSubsetWithRepeats_ShouldReturnTrue()
        {
            var hotelService = new HotelService();

            // Arrange
            var rooms = new List<Room>
        {
            new Room { Capacity = 1 },
            new Room { Capacity = 2 },
            new Room { Capacity = 2 },
            new Room { Capacity = 3 }
            // Добавьте другие комнаты при необходимости
        };

            var cards = new List<RoomCardDto>
        {
            new RoomCardDto { Capacity = 1 },
            new RoomCardDto { Capacity = 2 },
            new RoomCardDto { Capacity = 2 }
            // Добавьте другие карты при необходимости
        };

            // Act
            var result = hotelService.IsSubsetWithRepeats(rooms, cards);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSubsetWithRepeats_ShouldReturnFalse()
        {

            var hotelService = new HotelService();
            // Arrange
            var rooms = new List<Room>
        {
            new Room { Capacity = 1 },
            new Room { Capacity = 2 },
            new Room { Capacity = 2 },
            new Room { Capacity = 3 }
            // Добавьте другие комнаты при необходимости
        };

            var cards = new List<RoomCardDto>
        {
            new RoomCardDto { Capacity = 1 },
            new RoomCardDto { Capacity = 2 },
            new RoomCardDto { Capacity = 2 },
            new RoomCardDto { Capacity = 4 } // Добавленная карта с несовпадающей вместимостью
            // Добавьте другие карты при необходимости
        };

            // Act
            var result = hotelService.IsSubsetWithRepeats(rooms, cards);

            // Assert
            Assert.False(result);
        }
    }

}
