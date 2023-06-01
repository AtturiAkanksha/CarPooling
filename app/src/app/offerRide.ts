
export class OfferRide{
    startpoint: string;
    endPoint: string;
    date:string;
    timeSlot:string;
    seats:number;
    price:string;
    stops:string;
    userName:string;
    userId:number;
    
    constructor(startpoint: string,endPoint: string, date:string ,timeSlot:string, seats:number, stops:string, price:string, userName:string,userId:number
        ){
        this.startpoint=startpoint;
        this.endPoint = endPoint;
        this.date= date;
        this.timeSlot = timeSlot;
        this.seats= seats;
        this.price = price;
        this.userName = userName;
        this.userId = userId;
        this.stops =stops;
    }
}