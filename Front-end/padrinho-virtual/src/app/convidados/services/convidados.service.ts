import { FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { ConvidadosInterface } from './../interface/convidados';

@Injectable({
  providedIn: 'root'
})
export class ConvidadosService {

  //private readonly inviteePath:string = 'http://localhost:3000/convidados/'
  private readonly inviteePath:string = 'https://padrinhovirtual.azurewebsites.net/api/Convidado/'

  constructor(private http:HttpClient) { }

  patchConvidadoNomeById(convidadoId:string, nome: string){    
    //return this.http.patch<any>(this.inviteePath+convidadoId,form.value)
    return this.http.patch<any>(this.inviteePath+convidadoId,[
      {
      value: nome,
      path: "/nome",
      op: "replace"
      }
    ])
  }

  patchConvidadoQuantidadeById(convidadoId:string, convidados: number){    
    //return this.http.patch<any>(this.inviteePath+convidadoId,form.value)
    return this.http.patch<any>(this.inviteePath+convidadoId,[
      {
      value: convidados,
      path: "/quantidadeConvidado",
      op: "replace"
      }
    ])
  }

  deleteConvidadoById(convidadoId:string){
    return this.http.delete<any>(this.inviteePath+convidadoId)
  }

}
