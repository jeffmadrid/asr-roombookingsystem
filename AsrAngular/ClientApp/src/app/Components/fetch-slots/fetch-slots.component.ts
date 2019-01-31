import { Component } from "@angular/core";
import { Http } from "@angular/http";
import { Router } from "@angular/router";
import { SlotsService } from "../../services/slots.service";

@Component({
  selector: "app-fetch-slots",
  templateUrl: "./fetch-slots.component.html",
  styleUrls: ["./fetch-slots.component.css"]
})
export class FetchSlotComponent {
  slotList: SlotData[];

  constructor(public http: Http, private _router: Router, private _slotService: SlotsService) {
    this.getSlots();
  }

  getSlots() {
    this._slotService.getAllSlots().subscribe(data => this.slotList = data);
  }

  delete(staffID) {
    const ans = confirm("Do you want to delete Slot with Id: " + staffID);
    if (ans) {
      this._slotService.deleteSlot(staffID).subscribe((data) => {
        this.getSlots();
      },
        error => console.error(error));
    }
  }
}

interface SlotData {
  employeeId: number;
  name: string;
  gender: string;
  city: string;
  department: string;
}
