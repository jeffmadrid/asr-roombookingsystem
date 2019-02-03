import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { RoomService } from "../../Services/room.service";
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-add-room',
  templateUrl: './add-room.component.html',
  styleUrls: ['./add-room.component.css']
})
export class AddRoomComponent implements OnInit {
  title = "Add Room";
  errorMessage: any;
  roomForm: FormGroup;

  constructor(private _fb: FormBuilder, private _router: Router, private _roomService: RoomService) {
    this.roomForm = this._fb.group({
      roomId: new FormControl('')
    });
  }

  ngOnInit() {
  }

  save() {
    //var inputRoomId = (<HTMLInputElement>document.getElementById("roomId")).value;
    this._roomService.saveRoom(this.roomForm.value).subscribe((data) => {
      this._router.navigate(["/fetch-room"])
        },
      error => this.errorMessage = error);
  }

  cancel() {
    this._router.navigate(["/fetch-room"]);
  }

}
