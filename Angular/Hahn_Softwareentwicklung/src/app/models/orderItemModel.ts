import { CarModel } from './carModel';

export class OrderItemModel {
    id: string;
    car: CarModel;
    quantity: number;

    constructor(id: string, car: CarModel, quantity: number) {
        this.id = id;
        this.car = car;
        this.quantity = quantity;
    }
}