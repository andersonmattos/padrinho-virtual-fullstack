import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UsersInterface } from 'src/app/login/interface/users';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  //private readonly path ='http://localhost:3000/user/';
  //private readonly path = 'https://localhost:44388/api/Usuarios/';
  private readonly path = 'https://padrinhovirtual.azurewebsites.net/api/Usuario/';
  private readonly casamentoPath = 'https://padrinhovirtual.azurewebsites.net/api/Casamento/'
  private readonly convidadoWithCasamentoIdPath = 'https://padrinhovirtual.azurewebsites.net/api/Convidado/casamentoId/'
  //private readonly convidadoPath = 'https://padrinhovirtual.azurewebsites.net/api/Convidado?idCasamento='
  private readonly convidadoPath = 'https://padrinhovirtual.azurewebsites.net/api/Convidado'
  constructor(private http: HttpClient) { }

  getUserById(id:string){
    console.log('Usando método getUserById do service Home');
    console.log('Valor do path: '+this.path+id);
    return this.http.get<UsersInterface[]>(this.path+id);
  }

  patchUserById(id:string){
    console.log('Usando método patchUserById do service Home');
    return this.http.patch<any>(this.path+id, [
      {value:0, path: "/temCasamento", op: "replace"}, 
      {value:0, path: "/casamentoId", op: "replace"}
    ])
  }

  deleteCasamento(id:string){
    console.log('Usando método deleteCasamento do service Home');
    this.deleteConvidado(id)
    return this.http.delete<any>(this.casamentoPath+id)
  }

  deleteConvidado(ids:string){
    console.log('ids: ', ids)
    console.log('this.convidadoWithCasamentoIdPath+ids: ', this.convidadoWithCasamentoIdPath+ids)
    return this.http.delete<any>(this.convidadoWithCasamentoIdPath+ids)
  }

  getConvidadoByCasamentoId(id:string){
    return this.http.get<any>(this.convidadoWithCasamentoIdPath+id)            
  }

  getConvidado(){
    return this.http.get<any>(this.convidadoPath)
  }

}
