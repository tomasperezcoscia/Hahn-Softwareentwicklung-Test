export class WorkerModel {
    id: string;
    name: string;
    email: string;
    phoneNumber: string;
    password: string;
    position: string;
    salary: number;

    constructor(id:string, name:string, email:string, phoneNumber:string, password:string, position:string, salary:number){
        this.id = id;
        this.name = name;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.password = password;
        this.position = position;
        this.salary = salary;
    }
  }