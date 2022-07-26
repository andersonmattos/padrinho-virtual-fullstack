import { Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { Component, OnInit } from '@angular/core';

import { LoginService } from './services/login.service';
import { UsersInterface } from './interface/users';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //Declaraçao de variáveis
  users: UsersInterface[] = [];
  formLogin: UntypedFormGroup = new UntypedFormGroup({});
  //path: string = "http://localhost:3000/user";
  //path: string = "https://localhost:44388/api/Usuarios"
  path: string = "https://padrinhovirtual.azurewebsites.net/api/Usuario"
  userId: string = '';
    
  constructor(
    private service: LoginService, 
    private formBuilder: UntypedFormBuilder,
    private http: HttpClient,
    private router: Router) {}

  ngOnInit(): void {
    this.formLogin = this.formBuilder.group({
      email: [null, [Validators.required]],
      senha: [null, [Validators.required]]
    });

    this.service.getUsers().subscribe(usuarios => this.users = usuarios);    
    
  }

  validateLogin(){    
    console.log(this.formLogin.value); 
    if(this.formLogin.valid)
    {this.http.get<any>(this.path)
    .subscribe(
      res => {        
        const user = res.find((a:any)=>{
          this.userId = a.loginId;
          console.log(a)                            
          return a.email === this.formLogin.value.email && a.senha === this.formLogin.value.senha          
        });
        if(user){
          this.formLogin.reset();                         
          this.router.navigate(['/home/',this.userId]
          //this.router.navigate(['/home/',1]
          );
        }else{
          alert("Login ou senha inválidos");
          this.formLogin.reset();
        }
      }
    )}
  }

  onClick(){
    //console.log('Aehoo')
    this.router.navigate(['/primeiro-cadastro']);
  }

}
