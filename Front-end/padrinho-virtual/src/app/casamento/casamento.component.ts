import { UsersInterface } from './../login/interface/users';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { HttpClient } from '@angular/common/http';
import { ConvidadosService } from './../convidados/services/convidados.service';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { DateAdapter,MAT_DATE_FORMATS } from '@angular/material/core';
import { MomentDateAdapter, MAT_MOMENT_DATE_FORMATS,MAT_MOMENT_DATE_ADAPTER_OPTIONS, MatMomentDateModule } from '@angular/material-moment-adapter';


import { LoginComponent } from './../login/login.component';
import { ActivatedRoute, Router } from '@angular/router';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import { InviteeInterface } from './interface/invitee';
import { CasamentoInterface } from './interface/casamento';
import { CasamentoService } from './services/casamento.service';
import 'moment/locale/pt';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';



@Component({
  selector: 'app-casamento',
  templateUrl: './casamento.component.html',
  styleUrls: ['./casamento.component.css'],
  providers: [
    {provide: MAT_DATE_LOCALE, useValue: 'ja-JP'},
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS],
    },
    {provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS},
  ]
})
export class CasamentoComponent implements OnInit {

  //Determina as colunas a serem mostradas
  //displayedColumns: string[] = ['position','name', 'invitees', 'edit', 'delete',];
  displayedColumns: string[] = COLUMNS_SCHEMA.map((col)=>col.key);;
  columnsSchema: any = COLUMNS_SCHEMA;

  //Origem dos dados
  //dataSource = new MatTableDataSource<Invitees>(ELEMENT_DATA);
  //dataSource = ELEMENT_DATA;

  //Variáveis locais
  userId: string = '';  
  userIdNumber: number = 0;  
  casamentoId: string = '';  
  rootPath: string = '/home/';
  inviteePath: string = 'http://localhost:3000/convidados/';
  formPartner1: UntypedFormGroup = new UntypedFormGroup({});
  formPartner2: UntypedFormGroup = new UntypedFormGroup({});
  formCasamento: UntypedFormGroup = new UntypedFormGroup({});
  formPatchInvitees: UntypedFormGroup = new UntypedFormGroup({});
  noivo1: CasamentoInterface[] = [];
  noivo2: CasamentoInterface[] = [];
  data: CasamentoInterface[] = [];
  tabIndex: any = [];
  hadChange1: boolean = false;
  hadChange2: boolean = false;
  hadChange3: boolean = false;
  dataSource: InviteeInterface[] = [];
  userDataSource: UsersInterface[] = [];
  casamento: string = '';
  errorMessage: string = '';
  datePickerEvents: string[] = [];
  selectedDate: string = '';


  constructor (
    private loggedUser: LoginComponent
    , private router: ActivatedRoute
    , private route: Router
    , private formBuilder: UntypedFormBuilder
    , private service: CasamentoService
    , private InviteeService: ConvidadosService
    , private http:HttpClient
    , private _adapter: DateAdapter<any>
    , @Inject(MAT_DATE_LOCALE) private _locale: string,
    ) {
      //this.userId = this.router.snapshot.params['userId'];      
      this.casamentoId = this.router.snapshot.params['userId'];      
    }

  ngOnInit() {    
    console.log('ngOnInit - Casamento Component');
    console.log('this.casamentoId',this.casamentoId);

    this.formPartner1 = this.formBuilder.group({
      noivo1: [null]      
    });

    this.formPartner2 = this.formBuilder.group({
      noivo2: [null]      
    });

    this.formCasamento = this.formBuilder.group({
      data: '',
      status: 1  
    });

    this.service.getUserIdByCasamentoId(this.casamentoId).subscribe(
      (res:any) => {
        this.userId = res.usuario;
        console.log('this.userId',this.userId)
      }
    )

    //this.service.getUserId(this.userId).subscribe(
      //res => {     
        this.service.getPartnerName(this.casamentoId).subscribe(
            (a:any) => {this.noivo1 = a.nomeParceiroA; this.noivo2 = a.nomeParceiroB; this.data = a.data}
         )
       // }
    //)    

    this.service.getInviteesByCasamentoId(this.casamentoId).subscribe(
      (invitee => {
        this.dataSource = invitee; 
        console.log('this.dataSource', this.dataSource);
        /*let array = [];
        array.push(this.dataSource);
        console.log('array: ', array)
        invitee = array;
        this.dataSource = invitee;*/
      }))
    
    /*this.service.getUser(this.casamentoId).subscribe(
      (usr => {this.userDataSource = usr})
    )*/

    this._locale='pt';
    this._adapter.setLocale(this._locale);

  }

  addRow() {
    this.route.navigate(['/convidado'],{queryParams: {idCasamento:this.casamentoId}})
    /*const newRow = {"id":0,"idCasamento":0,"nome":"","quantidade":0, isEdit: true}
    this.dataSource = [newRow, ...this.dataSource];    */
  }

  removeRow(id: number) {
    //debugger
    this.InviteeService.deleteConvidadoById(id.toString()).subscribe();
    alert('Deletado com sucesso');    
    this.dataSource = this.dataSource.filter((u:any) => u.convidadoId !== id);    
  }

  //Método para identificar quando a aba Convidados está selecionada
  tabChanged(tabChangeEvent: MatTabChangeEvent): void {
    //console.log('tabChangeEvent => ', tabChangeEvent);
    //console.log('index => ', tabChangeEvent.index);
    this.tabIndex = tabChangeEvent.index;
    
  }

  saveChanges(){
    console.log('Iniciando saveChanges() on casamento.component.ts')
    console.log(this.formPartner1.value)
    console.log(this.formPartner2.value)
    console.log(this.formCasamento.value)
    
    console.log('this.hadChange1',this.hadChange1)    
    console.log('this.hadChange2',this.hadChange2)    
    console.log('this.hadChange3',this.hadChange3)
    
    this.selectedDate = this.formCasamento.controls['data'].value;

    //debugger

    if(this.hadChange1 != false || this.hadChange2 != false || this.hadChange3 != false){      
      if(this.hadChange1 != false){        
        this.service.updatePartner1Name(this.casamentoId,this.formPartner1).subscribe();       
      }

      if(this.hadChange2 != false){
        this.service.updatePartner2Name(this.casamentoId,this.formPartner2).subscribe();       
      }

      if(this.hadChange3 != false){
        this.service.updateDate(this.casamentoId,this.selectedDate).subscribe()
      }
      alert("Atualizado com sucesso!"); 
    }else{
      alert("Não foram detectadas alterações"); 
    }

  }

  onClickHome() {
    console.log('onClickHome - Casamento Component');
    console.log(this.casamentoId);
    //this.casamentoId = this.router.snapshot.params['userId']; 
    /*this.service.getPartnerName(this.casamentoId).subscribe(
      res => {this.userId = JSON.parse(res.idUser)}
    ) */
    //this.service.getCasamentoByUserId(this.casamentoId)      
    console.log(this.rootPath+this.userId)
    console.log(this.userDataSource)
    //this.route.navigate([this.rootPath,this.userId])
    /*this.service.getUser(this.casamentoId).subscribe(
      usr => {
        this.userId = usr.LoginId;
        console.log('usr.LoginId: ', usr.LoginId);
        this.userDataSource = usr;        
        console.log('this.userDataSource: ', this.userDataSource);       
      }
    )*/
    
    //this.http.get<any>('https://padrinhovirtual.azurewebsites.net/api/Usuario/casamentoId/'+this.casamentoId).subscribe(
    this.service.getUser(this.casamentoId).subscribe(
      usr => {
        this.userId = usr.loginId;
        console.log('usr.LoginId: ', this.userId);
        this.route.navigate([this.rootPath+this.userId])
      }
    )    
  }

  onChangePartner1() {
    this.hadChange1 = true;
  }

  onChangePartner2() {
    this.hadChange2 = true;
  }

  onChangeDate(){        
    this.hadChange3 = true;    
  }

  addEvent(event: MatDatepickerInputEvent<Date>){
    this.datePickerEvents.push(`${event.value}`)
    this.hadChange3 = true; 
    console.log(this.datePickerEvents);
    
  }

  onEditConvidado(id: number, nome: string, quantidade: number) {
    
    console.log("id", id)
    console.log("nome", nome)
    console.log("quantidade", quantidade)

    this.formPatchInvitees = this.formBuilder.group({      
      nome: nome,
      quantidadeConvidado: quantidade
    })
    
    this.InviteeService.patchConvidadoNomeById(id.toString(), this.formPatchInvitees.controls['nome'].value).subscribe()
    this.InviteeService.patchConvidadoQuantidadeById(id.toString(), this.formPatchInvitees.controls['quantidadeConvidado'].value).subscribe()
    
    alert('Atualizado com sucesso')

  }

  navigate(userId:string){
    console.log('navigate - CasamentoComponent')
    console.log('userId')
    console.log(userId)
    this.route.navigate([this.rootPath+userId])
  }

}

export interface Invitees {
  name: string;
  position: number;
  invitees: number;  
}

const ELEMENT_DATA: Invitees[] = [
  {name: 'Convidado 1', position: 1, invitees: 1},
  {name: 'Convidado 2', position: 2, invitees: 1},
  {name: 'Convidado 3', position: 3, invitees: 1},
  {name: 'Convidado 4', position: 4, invitees: 1},
  {name: 'Convidado 5', position: 5, invitees: 1},
  {name: 'Convidado 6', position: 6, invitees: 1},
  {name: 'Convidado 7', position: 7, invitees: 1}
];

const COLUMNS_SCHEMA = [
  {
    key: "convidadoId",
    type: "number",
    label: "Id"
  },    
  {
    key: "nome",
    type: "string",
    label: "Nome convidado"
  },
  {
    key: "quantidadeConvidado",
    type: "number",
    label: "Quantidade convidados"
  },
  {
    key: "isEdit",
    type: "isEdit",
    label: ""
  }
]


