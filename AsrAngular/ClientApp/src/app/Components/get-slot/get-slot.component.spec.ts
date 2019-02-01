import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetSlotComponent } from './get-slot.component';

describe('GetSlotComponent', () => {
  let component: GetSlotComponent;
  let fixture: ComponentFixture<GetSlotComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetSlotComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetSlotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
