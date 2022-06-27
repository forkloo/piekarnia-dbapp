import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable, of } from 'rxjs';
import {ClientView} from '../ClientView'
import {TASKS} from '../mock-tasks';



@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = 'http://localhost:5000/tasks'

  constructor(private http:HttpClient) { }


  getTasks(): Observable<ClientView[]>{
    return this.http.get<ClientView[]>(this.apiUrl)
  }
}
