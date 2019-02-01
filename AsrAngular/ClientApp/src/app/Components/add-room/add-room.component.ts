import { Component, OnInit } from "@angular/core";
import { Http } from "@angular/http";
import { Router } from "@angular/router";

@Component({
  selector: 'app-add-room',
  templateUrl: './add-room.component.html',
  styleUrls: ['./add-room.component.css']
})
export class AddRoomComponent implements OnInit {

  constructor(public http: Http, private _router: Router) {

  }

  ngOnInit() {
  }

}

interface Room {
  roomId: string;
}
