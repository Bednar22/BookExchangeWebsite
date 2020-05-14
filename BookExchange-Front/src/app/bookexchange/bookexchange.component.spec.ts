import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookexchangeComponent } from './bookexchange.component';

describe('BookexchangeComponent', () => {
  let component: BookexchangeComponent;
  let fixture: ComponentFixture<BookexchangeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookexchangeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookexchangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
