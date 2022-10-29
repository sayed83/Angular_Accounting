/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PropartylistComponent } from './propartylist.component';

describe('PropartylistComponent', () => {
  let component: PropartylistComponent;
  let fixture: ComponentFixture<PropartylistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PropartylistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PropartylistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
