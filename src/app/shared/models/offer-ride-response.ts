export class OfferRideResponseDTO {
    startPoint: string;
    endPoint: string;
    date: string;
    timeSlot: string;
    seats: number;
    price: string;
    userName: string;
    offerRideId: string;

    constructor(startPoint: string, endPoint: string, date: string, timeSlot: string, seats: number, price: string, userName: string, offerRideId: string

    ) {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.date = date;
        this.timeSlot = timeSlot;
        this.seats = seats;
        this.price = price;
        this.userName = userName;
        this.offerRideId = offerRideId;

    }
}