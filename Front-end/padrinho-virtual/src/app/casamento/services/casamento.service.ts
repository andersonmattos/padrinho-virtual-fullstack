import { UntypedFormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CasamentoService {

  //private readonly path ='http://localhost:3000/casamento/';
  private readonly path ='https://padrinhovirtual.azurewebsites.net/api/Casamento/';
  //private readonly inviteePath ='http://localhost:3000/convidados?idCasamento=';
  //private readonly inviteePath ='https://padrinhovirtual.azurewebsites.net/api/Convidado?idCasamento=';
  private readonly inviteePath ='https://padrinhovirtual.azurewebsites.net/api/Convidado/casamentoId/';
  
  //private readonly userPath ='http://localhost:3000/user/';
  //private readonly userPath = 'https://localhost:44388/api/Usuarios/';
  private readonly userPath = 'https://padrinhovirtual.azurewebsites.net/api/Usuario/';
  private readonly userPathWithCasamentoId = 'https://padrinhovirtual.azurewebsites.net/api/Usuario/casamentoId/';


  constructor(private http: HttpClient) { }

  getPartnerName(id:string){
    console.log('getPartnerName - CasamentoService');
    console.log('id:', id)
    console.log(this.path+id);
    return this.http.get<any>(this.path+id);
  }

  updatePartnerName(casamentoId:string, casamentoForm:UntypedFormGroup){
    console.log('Usando método updatePartnerName do service Casamento');
    console.log(casamentoForm.value);
    console.log(this.path+casamentoId);    
    
    console.log('Executando patch');
    return this.http.patch<any>(this.path+casamentoId,casamentoForm.value).subscribe(
      res => {
                       
      }
    )
  }

  getInviteesByCasamentoId(casamentoId:string) {    
    console.log('this.inviteePath+casamentoId',this.inviteePath+casamentoId)
    return this.http.get<any>(this.inviteePath+casamentoId)
  }

  getCasamentoId(userId:string){
    console.log('Método getCasamentoId')
    //return this.http.get<any>(this.userPath+userId)
    return this.http.get<any>(this.path+userId)
  }

  getUserId(userId:string){
    console.log('id',userId)   
    return this.http.get<any>(this.userPath+userId)
  }

  getUser(id:string){
    return this.http.get<any>(this.userPathWithCasamentoId+id)
  }

  addInviteeByCasamento(idCasamento:string){
    console.log('Usando método addInvitee do service Casamento');   
  }

  addCasamento(formNewCasamento: UntypedFormGroup){    
    return this.http.post<any>(this.path, formNewCasamento.value)
  }

  patchUserCasamentoStatus(userId: string, idCasamento: string){
    
    return this.http.patch<any>(this.userPath+userId, [
      {
        value: idCasamento,
        path: "/casamentoId",
        op: "replace"
      },
      {
        value: 1,
        path: "/temCasamento",
        op: "replace"
      },
    ])
  }
  
  getCasamentoByUserId(casamentoId:string){
    console.log('getCasamentoByUserId')
    this.http.get<any>(this.path+casamentoId).subscribe(
      (res:any)=>{
        const id = res.idUser
        console.log(id)        
      }
    )
  }

  getUserIdByCasamentoId(casamentoId:string){
    //this.http.get<any>('http://localhost:3000/casamento/'+casamentoId)    
    console.log('getUserIdByCasamentoId')
    console.log('casamentoId: ', casamentoId)
    return this.http.get<any>(this.userPath)
  }

}
