import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup } from '@angular/forms';
import { query } from '@angular/animations';

@Component({
  selector: 'app-convidados',
  templateUrl: './convidados.component.html',
  styleUrls: ['./convidados.component.css']
})
export class ConvidadosComponent implements OnInit {

  //Declaração de variáveis
  formConvidadosNome:FormGroup = new FormGroup({})
  formConvidadosQuantidade:FormGroup = new FormGroup({})
  formConvidadosNew:FormGroup = new FormGroup({})
  hadChangeNome: boolean = false;
  hadChangeQuantidade: boolean = false;
  convidadoId: string ='';
  casamentoId: string ='';
  //inviteeAddPath: string = 'http://localhost:3000/convidados'
  inviteeAddPath: string = 'https://padrinhovirtual.azurewebsites.net/api/Convidado/'

  constructor(
    private formBuilder: FormBuilder
    , private route: Router
    , private router: ActivatedRoute
    , private http: HttpClient
    ) {
    this.convidadoId = this.router.snapshot.queryParams['idCasamento']    
   }

  ngOnInit(): void {
    console.log('this.convidadoId')    
    console.log(this.convidadoId)

    this.formConvidadosNome = this.formBuilder.group({      
      nome: [null]      
    });

    this.formConvidadosQuantidade = this.formBuilder.group({      
      quantidade: [null]      
    });    

    this.router.queryParams.subscribe(
      (queryParams:any) => {        
        this.casamentoId = queryParams['idCasamento'];
      }      
    );
  }

  onSubmit() {
    console.log(this.formConvidadosNome.value)
    console.log(this.formConvidadosQuantidade.value)

    //Condição para atualizar
    if(this.hadChangeNome != false || this.hadChangeQuantidade != false){      
      if(this.hadChangeNome != false){
        console.log("Houve alteração no nome")
        //this.http.post<any>(this.inviteeAddPath,this.formConvidadosNome.value).subscribe()
      }

      if(this.hadChangeQuantidade != false){
        console.log("Houve alteração na quantidade")
        //this.http.post<any>(this.inviteeAddPath,this.formConvidadosQuantidade.value).subscribe()
      }
      //alert("Atualizado com sucesso!"); 
    }

    //Condição para inserir
    if(this.hadChangeNome != false && this.hadChangeQuantidade != false){
      this.formConvidadosNew = this.formBuilder.group({
        idCasamento: this.casamentoId,
        nome: this.formConvidadosNome.get('nome'),
        quantidadeConvidado: this.formConvidadosQuantidade.get('quantidade')
      })

      console.log(this.formConvidadosNew.value)    
      this.http.post<any>(this.inviteeAddPath,
        {
          nome: this.formConvidadosNew.controls['nome'].value,
          quantidadeConvidado: this.formConvidadosNew.controls['quantidadeConvidado'].value,
          casamentoId: this.formConvidadosNew.controls['idCasamento'].value
        }
      ).subscribe(
        res => {
          this.route.navigate(['Casamento/' + this.casamentoId])
          this.formConvidadosNew.reset
        }
      )

    }

  }

  onChangeNome() {
    this.hadChangeNome = true;
  }

  onChangeQuantidade() {
    this.hadChangeQuantidade = true;
  }

  onClickCancelButton() {    
    this.route.navigate(['Casamento/'+ this.casamentoId])
  }

}
