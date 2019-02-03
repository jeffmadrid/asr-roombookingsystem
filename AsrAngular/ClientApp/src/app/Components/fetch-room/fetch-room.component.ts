import { Component, OnInit } from '@angular/core';
import { Http } from "@angular/http";
import { Router } from "@angular/router";
import { RoomService } from "../../Services/room.service";

@Component({
  selector: 'app-fetch-room',
  templateUrl: './fetch-room.component.html',
  styleUrls: ['./fetch-room.component.css']
})
export class FetchRoomComponent implements OnInit {
  title = "Room Venues";
  roomList: Room[];

  constructor(public http: Http, private _router: Router, private _roomService: RoomService) {
    this.getRooms();
  }

  getRooms() {
    this._roomService.getAll().subscribe(data => this.roomList = data);
  }

  ngOnInit() {
  }

  delete(roomId) {
    const ans = confirm("Do you want to delete this room?");
    if (ans) {
      this._roomService.deleteRoom(roomId)
        .subscribe(data => this.getRooms(),
          error => console.error(error));
    }
  }
}

interface Room {
  roomId: string;
}
