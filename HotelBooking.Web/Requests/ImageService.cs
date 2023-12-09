using HotelBooking.Services.Contracts;

namespace HotelBooking.Web.Requests
{
    public class ImageService
    {
        
        private readonly string imagePath = "/images";


        public List<string> GetAllImageUrls(int hotelId)
        {
            // Получаем ссылки на изображения из объекта Hotel или базы данных
            var hotelImages = GetHotelImagesFromDatabase(hotelId);

            // Формируем полные URL-ы для изображений
            var imageUrls = hotelImages.Select(image => $"/images/{hotelId}/{image}").ToList();

            return imageUrls;
        }

        public Task<List<string>> GetImages(int hotelId)
        {
            return null;
        }

        public Task<List<string>> GetPreview(int hotelId)
        {
            throw new NotImplementedException();
        }

        private List<string> GetHotelImagesFromDatabase(int hotelId)
        {
            


            return new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" };
        }


    }
}
