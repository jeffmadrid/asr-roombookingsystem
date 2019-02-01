import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FetchSlotComponent } from './fetch-slot.component';

describe('FetchSlotComponent', () => {
  let component: FetchSlotComponent;
  let fixture: ComponentFixture<FetchSlotComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FetchSlotComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FetchSlotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
