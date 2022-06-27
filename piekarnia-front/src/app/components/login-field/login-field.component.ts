import { Component, OnInit } from '@angular/core';
import { ClientView, IClientView } from 'src/app/ClientView';
import { ClientService } from 'src/app/services/client.service';

@Component({
  selector: 'app-login-field',
  templateUrl: './login-field.component.html',
  styleUrls: ['./login-field.component.css']
})
export class LoginFieldComponent implements OnInit {
  loggedClient: IClientView;
  logFormVisible: boolean = false;

  constructor(private clientService: ClientService) {
    let clientId = sessionStorage.getItem('loggedClientId');
    if(clientId !== null){
        this.clientService.getClient(+clientId).subscribe( (c) => {this.loggedClient = c});
    }

    console.log(clientId+" ");
  }

  ngOnInit(): void {
    
  }

  logOut(){
    sessionStorage.removeItem('loggedClientId')
    this.loggedClient = new ClientView(-1, "", "", "", "")
  }

  logIn(){
    var cname: string = (<HTMLInputElement>document.getElementById("cname")).value;
    var csurname: string = (<HTMLInputElement>document.getElementById("csurname")).value;
    var cpassword: string = (<HTMLInputElement>document.getElementById("cpassword")).value;

    // this.clientService.getClientByNameAndSurname(cname, csurname).subscribe( (client) =>{
    //   console.log(client)
    //   if(client !== undefined && client !== null && client.clientId !== -1){ //client exists
    //     let clientId = client.clientId;
    //     if(client.clientPassword == cpassword){
    //       sessionStorage.setItem('loggedClientId', clientId.toString())
    //       this.clientService.getClient(+clientId).subscribe( (c) => {this.loggedClient = c});
    //     }
    //   }
    // });
    
  }

  showLogForm(){
    this.logFormVisible = !this.logFormVisible
  }

}
