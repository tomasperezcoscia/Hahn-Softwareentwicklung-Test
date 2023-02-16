export class PaymentMethodModel{
    id: string;
    name: string;

    constructor(id: string, name: string){
        this.id = id;
        this.name = name;
    }


}

export enum PaymentMethods
        {
            None,
            CreditCard,
            DebitCard,
            NetBanking,
            UPI,
            Wallet
        }