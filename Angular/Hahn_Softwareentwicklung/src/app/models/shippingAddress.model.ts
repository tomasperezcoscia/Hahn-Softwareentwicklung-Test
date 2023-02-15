export class ShippingAddressModel {
    id: string;
    addressLine1: string;
    addressLine2: string;
    city: string;
    state: string;
    postalcode: string;
    country: number;

    constructor(id: string, addressLine1: string, addressLine2: string, city: string, state: string, postalcode: string, country: number) {
        this.id = id;
        this.addressLine1 = addressLine1;
        this.addressLine2 = addressLine2;
        this.city = city;
        this.state = state;
        this.postalcode = postalcode;
        this.country = country;
    }
  }