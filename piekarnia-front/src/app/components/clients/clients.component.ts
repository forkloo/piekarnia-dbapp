import { Component, OnInit } from '@angular/core';
import { IClientView } from 'src/app/ClientView';
import { ClientService } from 'src/app/services/client.service';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {
  clients: IClientView[] = [];

  constructor(private clientService: ClientService) { }

  ngOnInit(): void {
    this.clientService.getClientList().subscribe(clients => {this.clients = clients})
  }
}
