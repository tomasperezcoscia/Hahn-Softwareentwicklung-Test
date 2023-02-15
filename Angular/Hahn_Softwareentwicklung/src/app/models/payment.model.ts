import { PaymentMethodModel } from './paymentMethod.model';

export class PaymentModel {
    id: string;
    amount: number;
    paymentMethod: PaymentMethodModel;

    constructor(id: string, amount: number, paymentMethod: PaymentMethodModel) {
        this.id = id;
        this.amount = amount;
        this.paymentMethod = paymentMethod;
    }
}