/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CardlistComponent } from './cardlist.component';

describe('CardlistComponent', () => {
  let component: CardlistComponent;
  let fixture: ComponentFixture<CardlistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardlistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
