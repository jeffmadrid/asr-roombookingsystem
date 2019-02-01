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
  title = "Fetch Slot";
  slotList: Slot[];

  constructor(public http: Http, private _router: Router, private _slotService: SlotService) {
    this.getSlots();
  }

  getSlots() {
    this._slotService.getAllSlots().subscribe(data => this.slotList = data);
  }


  ngOnInit() {
  }

}

interface Slot {
  roomId: string;
  startTime: Date;
  staffId: string;
  studentId: string;
}
