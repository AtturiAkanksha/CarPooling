﻿namespace CarPooling.Models
{
    public class AddRideRequest
    {
        public string name { get; set; } = null!;

        public string startPoint { get; set; } = null!;

        public string endPoint { get; set; } = null!;

        public string date { get; set; } = null!;

        public string startTime { get; set; } = null!;

        public string endTime { get; set; } = null!;

        public string price { get; set; } = null!;

        public string seats { get; set; } = null!;

        public string rideType { get; set; } = null!;
    }
}
