import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { UsersInterface } from 'src/app/login/interface/users';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  //private readonly path ='http://localhost:3000/user/';
  //private readonly path = 'https://localhost:44362/api/Usuarios/';
  private readonly path = 'https://padrinhovirtual.azurewebsites.net/api/Usuarios/';

  constructor(private http: HttpClient) { }

  getUserById(id:string){
    console.log('Usando método getUserById do service Home');
    console.log('Valor do path: '+this.path+id);
    return this.http.get<UsersInterface[]>(this.path+id);
  }

}
