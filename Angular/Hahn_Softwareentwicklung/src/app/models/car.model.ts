export class CarModel {
    id: string;
    brand: string;
    model: string;
    year: number;
    price: number;
    color: string;

    constructor(id: string, brand: string, model: string, year: number, price: number, color: string) {
        this.id = id;
        this.brand = brand;
        this.model = model;
        this.year = year;
        this.price = price;
        this.color = color;
    }
}
