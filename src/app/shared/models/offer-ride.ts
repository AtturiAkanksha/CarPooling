export class OfferRide {
    startPoint: string;
    endPoint: string;
    date: string;
    timeSlot: string;
    seats: number;
    price: string;
    stops: string;
    userName: string;

    constructor(startPoint: string, endPoint: string, date: string, timeSlot: string, seats: number, stops: string, price: string, userName: string
    ) {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.date = date;
        this.timeSlot = timeSlot;
        this.seats = seats;
        this.price = price;
        this.userName = userName;
        this.stops = stops;
    }
}