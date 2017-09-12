import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarreiraComponent } from './carreira.component';

describe('CarreiraComponent', () => {
  let component: CarreiraComponent;
  let fixture: ComponentFixture<CarreiraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarreiraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarreiraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
