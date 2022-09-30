import { UntypedFormGroup, UntypedFormBuilder } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { UsersInterface } from './../login/interface/users';
import { HttpClient } from '@angular/common/http';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog'
import { HomeDialogComponent } from './home-dialog/home-dialog.component';
import { CasamentoService } from './../casamento/services/casamento.service';
import { HomeDialogDeleteComponent } from './home-dialog-delete/home-dialog-delete.component';
import { HomeService } from './services/home.service';
import { ConvidadosInterface } from '../convidados/interface/convidados';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  //Variáveis locais
  userId: string = '';
  rootPath: string = '/Casamento/';
  //rootPath: string = 'https://padrinhovirtual.azurewebsites.net/api/Casamento/';
  //userPath: string  = 'http://localhost:3000/user/'
  //userPath: string  = 'https://localhost:44388/api/Usuarios/'
  userPath: string  = 'https://padrinhovirtual.azurewebsites.net/api/Usuario/'
  //casamentoPath: string  = 'http://localhost:3000/casamento/'
  casamentoPath: string  = 'https://padrinhovirtual.azurewebsites.net/api/Casamento/'
  users: UsersInterface[] = [];
  hasProject: any = 0;
  formNewCasamento: UntypedFormGroup = new UntypedFormGroup({});
  frm: UntypedFormGroup = new UntypedFormGroup({});
  frmPatchCasamento: UntypedFormGroup = new UntypedFormGroup({});
  frmPatchUser: UntypedFormGroup = new UntypedFormGroup({});
  casamentoId: string = '';
  existingCasamentoId: string = '';
  convidados: ConvidadosInterface[] = [];
  isError: boolean = false;
  
  constructor(
    private route: ActivatedRoute
    ,private router: Router
    ,private http: HttpClient    
    , private formBuilder: UntypedFormBuilder
    , private CasamentoService: CasamentoService
    , public dialog: MatDialog  
    , public service: HomeService  
  ) { 
    //Busca o id do usuário no endereço da página
    this.userId = this.route.snapshot.params['userId'];
  }

  ngOnInit(): void {
    console.log(this.userId);
    this.http.get<any>(this.userPath+this.userId).subscribe(res => {
      this.hasProject = JSON.parse(res.temCasamento);
      console.log('this.hasProject', this.hasProject)
    })
    //console.log('this.hasProject', this.hasProject)
    console.log('this.userPath+this.userId', this.userPath+this.userId)

    this.http.get<any>(this.userPath+this.userId).subscribe(
      //res => {this.existingCasamentoId = res.idCasamento 
      res => {this.existingCasamentoId = res.casamentoId;
        console.log('this.existingCasamentoId',this.existingCasamentoId)}      
    )    
    
  }

  onClickEdit() {
    console.log('Entrando na rotina onClickEdit()')
    console.log('Valor da variável rootPath: ' + this.rootPath)        
    console.log('Valor da variável rootPath,this.existingCasamentoId: ' + this.rootPath+this.existingCasamentoId)
    this.router.navigate([this.rootPath+this.existingCasamentoId])
  }

  onClickNew() {
    this.formNewCasamento = this.formBuilder.group({
      //idUser: this.userId,
      noivo1: [null],
      noivo2: [null],
      data: [null],
      status: 1
    })

    /*this.CasamentoService.getCasamentoId('8').subscribe(
      res => {
        this.casamentoId = res.id;
        console.log('this.casamentoId: res.id', this.casamentoId);

        this.casamentoId = res.casamentoId;
        console.log('this.casamentoId: res.casamentoId', this.casamentoId)
      }
    )*/
    
    this.CasamentoService.addCasamento(this.formNewCasamento).subscribe(      
      res => {        
        this.casamentoId = res.casamentoId
        this.updateUser(this.casamentoId)    
        this.router.navigate([this.rootPath+this.casamentoId])
      }
    )
    
    console.log(this.casamentoId)
    
  }

  getuserId(): string {
    return this.userId = this.route.snapshot.params['userId'];        
  }

  updateUser(idCas:string){
    console.log('Entrou na rotina updateUser')
    
    /*this.frm = this.formBuilder.group({
      temCasamento: 1,
      idCasamento: idCas
    })*/
    
    this.CasamentoService.patchUserCasamentoStatus(this.userId, idCas).subscribe()
   
  }

  onClickeDelete(enterAnimationDuration: string, exitAnimationDuration: string): void {
    const dialogRef = this.dialog.open(HomeDialogDeleteComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
      if(result == false){        
        
        this.service.getConvidado().subscribe(
          cnv => {            
            this.convidados = cnv;
            this.convidados = this.convidados.filter( x => x.casamentoId === Number(this.existingCasamentoId));            

            if(!this.convidados.length){
              this.service.deleteCasamento(this.existingCasamentoId).subscribe();
              this.service.patchUserById(this.userId).subscribe();
              alert('Casamento deletado com sucesso') 
              window.location.reload();
            }else{
              alert('Necessário deletar os convidados antes.')
            }
          }
        )
      }
      
    });
  }
  
  onClickEnd(enterAnimationDuration: string, exitAnimationDuration: string): void {
    
    this.frmPatchUser = this.formBuilder.group({
      temCasamento: 0,
      idCasamento: 0
    })

    //this.dialog.open(HomeDialogComponent);
    const dialogRef = this.dialog.open(HomeDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
      if(result == false){
        this.service.patchUserById(this.userId).subscribe();
        alert('Casamento concluído com sucesso');
        window.location.reload();
      }      
    });    
  }

  onClickPerfil(){
    this.router.navigate(['/perfil/',this.userId])
  }

}