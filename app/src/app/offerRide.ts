
export class OfferRide{
    startpoint: any;
    endPoint: any;
    date:any;
    timeSlot:any;
    seats:number;
    price:any;
    userName:string;

    
    constructor(startpoint: any,endPoint: any, date:any ,timeSlot:any, seats:number,  price:any, userName:string){
        this.startpoint=startpoint;
        this.endPoint = endPoint;
        this.date= date;
        this.timeSlot = timeSlot;
        this.seats= seats;
        this.price = price;
        this.userName = userName;
    }
}