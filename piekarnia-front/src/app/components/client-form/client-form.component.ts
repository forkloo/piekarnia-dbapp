import { Component, OnInit } from '@angular/core';
import { ClientService } from 'src/app/services/client.service';
import { ClientView, IClientView } from 'src/app/ClientView';

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {
  client: IClientView;
  editMode: boolean = false;

  constructor(private clientService: ClientService) { 
  }

  ngOnInit(): void {
    this.clientService.displayClientInfo.subscribe( (_client) => {
      this.client = _client;
      this.editMode = false;
    });
  }

  editClient(){
    this.editMode = !this.editMode;
  }

  saveChanges(){
    var cname: string = (<HTMLInputElement>document.getElementById("cname")).value;
    var csurname: string = (<HTMLInputElement>document.getElementById("csurname")).value;
    var ccity: string = (<HTMLInputElement>document.getElementById("ccity")).value;
    var cmail: string = (<HTMLInputElement>document.getElementById("cmail")).value;
    
    if(cname.length > 0 && csurname.length > 0 && ccity.length > 0 && cmail.length > 0){
      this.editMode = false;
      if(this.client.clientId === -1){
        this.clientService.createClient(new ClientView(this.client.clientId, cname, csurname, ccity, cmail));
      }
      else{
        this.clientService.updateClient(new ClientView(this.client.clientId, cname, csurname, ccity, cmail));
      }
    }
  }

  deleteClient(){
    this.editMode = false;
    this.clientService.deleteClient(this.client.clientId);
  }

  toggleClientCreation(){
    this.editMode = true;
    this.client = new ClientView(-1, "", "", "", "");
  }
}
