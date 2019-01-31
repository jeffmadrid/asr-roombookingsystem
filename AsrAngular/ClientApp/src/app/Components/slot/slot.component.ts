import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-slot',
  templateUrl: './slot.component.html',
  styleUrls: ['./slot.component.css']
})
export class SlotComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}

interface Slot {
    roomID: string;
    startTime: Date;
    staffID: string;
    studentID: string;
}