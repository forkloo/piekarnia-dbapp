import { EventEmitter, Injectable, Output } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { ClientView, IClientView } from '../ClientView';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private apiUrl = 'http://localhost:5000/api/v1/client/'
  @Output() displayClientInfo = new EventEmitter<IClientView>();

  constructor(private http: HttpClient) { }

  getClientList(): Observable<IClientView[]>{
    return this.http.get<IClientView[]>(this.apiUrl+'list');
  }

  // getClientByNameAndSurname(cname: string, csurname: string){
  //   let clientList: IClientView[]
  //   var clientId: number = -1
  //   this.getClientList().subscribe( (cList) => {clientList = cList})

  //   // clientList.forEach( (_client) => {
  //   //   if(clientId === -1){
  //   //       if(_client.clientName == cname && _client.clientSurname == csurname){
  //   //         clientId = _client.clientId
  //   //       }
  //   //   }
  //   // })
  // }

  getClient(clientId: number): Observable<IClientView>{
    return this.http.get<IClientView>(this.apiUrl+clientId.toString());
  }

  deleteClient(clientId: number){
    this.http.delete(this.apiUrl+'delete/'+clientId.toString()).subscribe();
    window.location.reload();
  }

  updateClient(client: IClientView){
    this.http.patch(this.apiUrl+'edit/'+client.clientId.toString(), {
      "clientName": client.clientName,
      "clientSurname": client.clientSurname,
      "clientCity": client.clientCity,
      "clientMail": client.clientMail
    }).subscribe();
    window.location.reload();
  }

  createClient(client: IClientView){
    this.http.post(this.apiUrl, {
      "clientName": client.clientName,
      "clientSurname": client.clientSurname,
      "clientCity": client.clientCity,
      "clientMail": client.clientMail
    }).subscribe();
    window.location.reload();
  }

}
