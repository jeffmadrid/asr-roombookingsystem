import { Component, OnInit } from "@angular/core";
import { Http } from "@angular/http";
import { Router } from "@angular/router";
import { FormGroup } from "@angular/forms";

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

  save() {

  }

  cancel() {
    this._router.navigate(["/fetch-room"]);
  }
}

interface Room {
  roomId: string;
}
