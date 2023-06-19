export class BookRideRequest{
    startpoint: string;
    endPoint: string;
    date:string;
    timeSlot:string;
    
    constructor(startpoint: string,endPoint: string, date:string ,timeSlot:string
        ){
        this.startpoint=startpoint;
        this.endPoint = endPoint;
        this.date= date;
        this.timeSlot = timeSlot;
    }
}