import { OrderModel } from './order.model';

export class BuyerModel {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
    dateOfBirth: Date;
    budget: number;
    orders: OrderModel[];


    constructor(
        id: string,
        firstName: string,
        lastName: string,
        email: string,
        phoneNumber: string,
        dateOfBirth: Date,
        budget: number,
        orders: OrderModel[],
    ){
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.dateOfBirth = dateOfBirth;
        this.budget = budget;
        this.orders = orders;
    }
}