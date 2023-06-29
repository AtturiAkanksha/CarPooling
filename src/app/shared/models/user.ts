export class User {
    [x: string]: string;
    email: any;
    password: any;
    constructor(email: any, password: any) {
        this.email = email;
        this.password = password;
    }
}