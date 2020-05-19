import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExchangeslistComponent } from './exchangeslist.component';

describe('ExchangeslistComponent', () => {
  let component: ExchangeslistComponent;
  let fixture: ComponentFixture<ExchangeslistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExchangeslistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExchangeslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
