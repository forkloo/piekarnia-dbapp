
import { Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { ClientService } from 'src/app/services/client.service';

import {IClientView} from '../../ClientView'

@Component({
  selector: 'app-client-item',
  templateUrl: './client-item.component.html',
  styleUrls: ['./client-item.component.css']
  
})
export class ClientItemComponent implements OnInit {
  @Input() client: IClientView;

  constructor(private clientService: ClientService) { }

  ngOnInit(): void {

  }

  selectClient(){
    this.clientService.displayClientInfo.emit(this.client);
  }
}

