import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-slot',
  templateUrl: './fetch-slot.component.html',
  styleUrls: ['./fetch-slot.component.css']
})
export class FetchSlotComponent implements OnInit {

    public slots: Slot;


    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      
    }

  ngOnInit() {
  }

}


interface Slot {
    roomID: string;
    startTime: Date;
    staffID: string;
    studentID: string;
}
