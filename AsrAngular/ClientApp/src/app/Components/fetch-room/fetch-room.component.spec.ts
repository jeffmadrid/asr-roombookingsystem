import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FetchRoomComponent } from './fetch-room.component';

describe('FetchRoomComponent', () => {
  let component: FetchRoomComponent;
  let fixture: ComponentFixture<FetchRoomComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FetchRoomComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FetchRoomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
