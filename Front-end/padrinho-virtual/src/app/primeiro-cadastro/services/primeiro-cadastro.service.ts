import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { UsersInterface } from 'src/app/login/interface/users';

@Injectable({
  providedIn: 'root'
})
export class PrimeiroCadastroService {

  //private readonly path = 'http://localhost:3000/user';
  //private readonly path = 'https://localhost:44388/api/Usuarios';
  private readonly path = 'https://padrinhovirtual.azurewebsites.net/api/Usuario';

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get<UsersInterface[]>(this.path)    
  }

  verifyExistingUser(usr : UsersInterface[], usrName: string){
    //console.log('Entrando no método verifyExistingUser() (primeiro-cadastro/services)')    
    const user = usr.find(
      (x) => x.email === usrName      
    )

    /*if (user){
      alert('E-mail já cadastrado')
    } else {
      console.log ('')
    }*/
    return user
  }
}
