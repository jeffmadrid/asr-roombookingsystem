import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from "@angular/router";
import { RoomService } from "../../services/room.service";
import { Http } from "@angular/http";
@Component({
  selector: 'app-add-room',
  templateUrl: './add-room.component.html',
  styleUrls: ['./add-room.component.css']
})
export class AddRoomComponent implements OnInit {
  roomForm: FormGroup;
  title: string = "Add";
  roomId: string;
  errorMessage: any;
  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute, private _RoomService: RoomService,
   private _router: Router)
  {
    if (this._avRoute.snapshot.params["id"]) {
      this.roomId = this._avRoute.snapshot.params["id"];
    }
    this.roomForm = this._fb.group({
      
       roomId: ["", [Validators.required]]
     
    });
  }

  ngOnInit()
  {
    if (this.roomId != null) {
      this.title = "Edit";
      this._RoomService.getRoomById(this.roomId).subscribe(resp => this.roomForm.setValue(resp),
        error => this.errorMessage = error);
    }
  }

  save() {
    if (!this.roomForm.valid) {
      return;
    }
    if (this.title === "Add") {
      this._RoomService.saveRoom(this.roomForm.value).subscribe((data) => {
        this._router.navigate(["/fetch-room"]);
      }, error => this.errorMessage = error);
    }
    else if (this.title === "Edit") {
      this._RoomService.updateRoom(this.roomForm.value).subscribe((data) => {
        this._router.navigate(["/fetch-room"]);
      }, error => this.errorMessage = error);
    }
  }

  cancel() {
    this._router.navigate(["/fetch-room"]);
  }

  //get roomId() {
  //  return this.roomForm.get("roomId");
  //}

}

interface Room {
  roomId: string;
}
