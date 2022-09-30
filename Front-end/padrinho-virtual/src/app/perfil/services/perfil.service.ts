import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { UsersInterface } from './../../login/interface/users';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  private readonly pathUser: string = 'https://padrinhovirtual.azurewebsites.net/api/Usuario/'
  
  constructor(private http: HttpClient) { }

  getUserInformation(id:number){
    return this.http.get<UsersInterface[]>(this.pathUser+id)
  }

  patchUserName(id:number, newName:string){
    console.log('this.pathUser+id',this.pathUser+id);
    
    return this.http.patch<UsersInterface[]>(this.pathUser+id,[
      {
        "value": newName,
        "path": '/nome',
        "op": "replace"
      }
    ])
  }

  patchUserPassword(id:number, newPassword:string){
    return this.http.patch<UsersInterface[]>(this.pathUser+id,[
      {
        "value": newPassword,
        "path": '/senha',
        "op": "replace"
      }
    ])
  }

  patchUserEmail(id:number, newEmail:string){
    return this.http.patch<UsersInterface[]>(this.pathUser+id,[
      {
        "value": newEmail,
        "path": '/email',
        "op": "replace"
      }
    ])
  }

  deleteUser(id:number){
    return this.http.delete<UsersInterface[]>(this.pathUser+id)
  }



}

