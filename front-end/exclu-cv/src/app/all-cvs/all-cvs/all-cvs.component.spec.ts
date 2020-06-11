import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllCvsComponent } from './all-cvs.component';

describe('AllCvsComponent', () => {
  let component: AllCvsComponent;
  let fixture: ComponentFixture<AllCvsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllCvsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllCvsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
