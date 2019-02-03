import { Component, OnInit } from '@angular/core';
import { Http } from "@angular/http";
import { Router } from "@angular/router";
import { SlotService } from "../../Services/slot.service";

@Component({
  selector: 'app-fetch-slot',
  templateUrl: './fetch-slot.component.html',
  styleUrls: ['./fetch-slot.component.css']
})

export class FetchSlotComponent implements OnInit {
  title = "Fetch Slot and Delete Slot";
  slotList: Slot[];
  inputStudentId: string;

  constructor(public http: Http, private _router: Router, private _slotService: SlotService) {
    this.getSlots();
  }

  getSlots() {
    this._slotService.getAllSlots().subscribe(data => this.slotList = data);
  }

  getSlotsOf(id) {
    this._slotService.getSlotsOf(id).subscribe(data => this.slotList = data);
  }

  delete(roomId, startTime) {
    const ans = confirm("Do you want to delete this slot?");
    if (ans) {
      this._slotService.deleteSlot(roomId, startTime)
        .subscribe(data => this.getSlots(), error => console.error(error)); 

    }
  }

  ngOnInit() {
  }

}

export interface Slot {
  roomId: string;
  startTime: string;
  staffId: string;
  studentId: string;
}
