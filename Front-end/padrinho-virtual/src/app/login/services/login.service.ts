import { UsersInterface } from '../interface/users';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  //private readonly path = 'http://localhost:3000/user';
  private readonly path = 'https://localhost:44362/api/Usuarios';
  
  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get<UsersInterface[]>(this.path)      
  }

}
