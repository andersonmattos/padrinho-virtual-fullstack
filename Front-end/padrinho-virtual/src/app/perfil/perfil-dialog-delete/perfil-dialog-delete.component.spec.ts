import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PerfilDialogDeleteComponent } from './perfil-dialog-delete.component';

describe('PerfilDialogDeleteComponent', () => {
  let component: PerfilDialogDeleteComponent;
  let fixture: ComponentFixture<PerfilDialogDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PerfilDialogDeleteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PerfilDialogDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
