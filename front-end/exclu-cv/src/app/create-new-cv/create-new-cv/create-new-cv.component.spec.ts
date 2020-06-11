import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateNewCvComponent } from './create-new-cv.component';

describe('CreateNewCvComponent', () => {
  let component: CreateNewCvComponent;
  let fixture: ComponentFixture<CreateNewCvComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateNewCvComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateNewCvComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
