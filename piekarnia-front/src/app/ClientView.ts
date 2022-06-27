export interface IClientView{
    clientId: number;
    clientName: string;
    clientSurname: string;
    clientCity: string;
    clientMail: string;   
}

export class ClientView implements IClientView{
    clientId: number;
    clientName: string;
    clientSurname: string;
    clientCity: string;
    clientMail: string;

    constructor(clientId: number, clientName: string, clientSurname: string, clientCity: string, clientMail: string){
        this.clientId = clientId;
        this.clientName = clientName;
        this.clientSurname = clientSurname;
        this.clientCity = clientCity;
        this.clientMail = clientMail;
    }
}