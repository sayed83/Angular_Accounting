import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditInspactionComponent } from './add-edit-inspaction.component';

describe('AddEditInspactionComponent', () => {
  let component: AddEditInspactionComponent;
  let fixture: ComponentFixture<AddEditInspactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditInspactionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditInspactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
