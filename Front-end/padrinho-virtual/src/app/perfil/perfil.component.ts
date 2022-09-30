import { PerfilDialogDeleteComponent } from './perfil-dialog-delete/perfil-dialog-delete.component';
import { MatDialog } from '@angular/material/dialog';
import { UsersInterface } from './../login/interface/users';
import { PerfilService } from './services/perfil.service';
import { Router, RouterModule, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  userId: number = 0;
  frmUser: FormGroup = new FormGroup({});
  users: UsersInterface[] = [];
  nome: UsersInterface[] = [];
  email: UsersInterface[] = [];
  hasNameBeenUpdated: boolean = false;
  hasSenhaBeenUpdated: boolean = false;
  hasEmailBeenUpdated: boolean = false;
  passwordValidation: boolean = false;
  isValid: boolean = false;
  regex: string = '';

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private frmBuilder: FormBuilder,
    private perfilService: PerfilService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    //Busca o id do usuário no endereço da página
    this.userId = this.route.snapshot.params['userId'];

    this.regex = '[a-zA-z0-9]'

    this.frmUser = this.frmBuilder.group({
      nome: [null],
      email:[null],
      senha: [null]      
    })

    this.perfilService.getUserInformation(this.userId).subscribe(
      (usr:any) => {
        this.users = usr;
        this.nome = usr.nome;
        this.email = usr.email;
        console.log(this.users);        
      }
    )
  }

  onClickHome(){
    console.log('this.userId: ',this.userId);   
    this.router.navigate(['/home/',this.userId])
  }

  onClickUpdate(){
    console.log(this.frmUser.controls)
    this.hadChanges();
    //this.passwordValidation = this.passwordValild();
    

    if(this.hasNameBeenUpdated === true){
      this.perfilService.patchUserName(this.userId, this.frmUser.controls['nome'].value).subscribe();        
    }

    if(this.hasSenhaBeenUpdated === true){      
      this.perfilService.patchUserPassword(this.userId, this.frmUser.controls['senha'].value).subscribe();
    }

    if(this.hasEmailBeenUpdated === true){      
      this.perfilService.patchUserEmail(this.userId, this.frmUser.controls['email'].value).subscribe();
    }

    if(this.hasNameBeenUpdated === true || this.hasSenhaBeenUpdated === true || this.hasEmailBeenUpdated === true){
      alert('Dados atualizados com sucesso')
    }else{
      alert('Não foram localizadas alterações')
    }

    window.location.reload();
  }

  onClickDelete(enterAnimationDuration: string, exitAnimationDuration: string){
    console.log('Entrando na rotina onClickDelete');
    const dialogRef = this.dialog.open(PerfilDialogDeleteComponent)

    dialogRef.afterClosed().subscribe(result =>{
      console.log(`Dialog result: ${result}`);
      if(result == false){
        this.perfilService.deleteUser(this.userId).subscribe();
        alert('Perfil excluído com sucesso!')
        this.router.navigate(['']);
      }
    })    
  }

  hadChanges(){
    if(this.frmUser.controls['nome'].pristine === false && this.frmUser.controls['nome'].touched === true){
      this.hasNameBeenUpdated = true
    }
    if(this.frmUser.controls['senha'].pristine === false && this.frmUser.controls['senha'].touched === true){
      this.hasSenhaBeenUpdated = true
    }
    if(this.frmUser.controls['email'].pristine === false && this.frmUser.controls['email'].touched === true){
      this.hasEmailBeenUpdated = true
    }
  }

  passwordValild():boolean{
    
    console.log('passwordValild')
    console.log(this.frmUser.controls['senha'])
    
    if(this.frmUser.controls['senha'].status === 'VALID'){
      this.isValid = true
      return this.isValid
    }else{
      this.isValid = false
      return this.isValid
    }
  }

}
