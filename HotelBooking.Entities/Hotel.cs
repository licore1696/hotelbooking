﻿using HotelBooking.Entities;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
	public string Country { get; set; }
	public decimal PricePerNight { get; set; }
    public double Rating { get; set; }
    public int Stars {  get; set; }

    public List<string>? Images { get; set; }

    public List<Room> Rooms { get; set; }
    public List<Review> Reviews { get; set; }

}
