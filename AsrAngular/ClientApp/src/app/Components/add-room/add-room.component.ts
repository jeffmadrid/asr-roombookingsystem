import { Component, OnInit } from "@angular/core";
import { Http } from "@angular/http";
import { Router } from "@angular/router";
import { FormGroup } from "@angular/forms";
import { RoomService } from "../../services/room.service";

@Component({
  selector: 'app-add-room',
  templateUrl: './add-room.component.html',
  styleUrls: ['./add-room.component.css']
})
export class AddRoomComponent implements OnInit {
  title = "Add Room"
  roomForm = FormGroup;

  constructor(public http: Http, private _router: Router) {

  }

  ngOnInit() {
  }

  //save() {
  //  this._roomService.saveRoom(this.roomForm.value)
  //    .subscribe((data) =>
  //      this._router.navigate(["/fetch-room"]),
  //      error => this.errorMessage = error);
  //}

  //cancel() {
  //  this._router.navigate(["/fetch-room"]);
  //}
}

interface Room {
  roomId: string;
}
