import { Component, OnInit } from '@angular/core';
import { Http } from "@angular/http";
import { Router, ActivatedRoute } from "@angular/router";
import { SlotService } from "../../Services/slot.service";
import { Slot } from '../fetch-slot/fetch-slot.component';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit {
  title = "Edit to Book or Cancel Booking for Students";
  slotForm: FormGroup;

  roomId: string;
  startTime: string;
  staffId: string;
  studentId: string;

  constructor(public http: Http, private _router: Router, private _slotService: SlotService,
    private _fb: FormBuilder, private _avRoute: ActivatedRoute) {

    if (this._avRoute.snapshot.params["roomId"]) {
      this.roomId = this._avRoute.snapshot.params["roomId"];
      this.startTime = this._avRoute.snapshot.params["startTime"];
      this.staffId = _avRoute.snapshot.params["staffId"];
      //alert(this.startTime);
    }

    this.slotForm = this._fb.group({
      roomId: new FormControl(''),
      startTime: new FormControl(''),
      staffId: new FormControl(''),
      studentId: new FormControl('')
    })
  }

  ngOnInit() {
    //this._slotService.getStudentId(this.roomId, this.startTime).subscri


  }

  save() {



    //this._slotService.updateBookedStudent(roomId, startTime, studentId)
    //  .subscribe(data => this.getSlots(), error => console.error(error));
  }

  cancel() {
    this._router.navigate(["/fetch-slot"]);
  }

  

}
