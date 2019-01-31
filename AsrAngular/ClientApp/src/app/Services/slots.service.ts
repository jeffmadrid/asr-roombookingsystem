import { Injectable, Inject } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/observable/throw";

@Injectable()
export class SlotsService {
  myAppUrl: string = "";

  constructor(private _http: Http, @Inject("BASE_URL") baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getBookedSlot(id: string) {
    return this._http.get(this.myAppUrl + "api/Slots/GetBookedSlot").map(res => res.json()).catch(this.errorHandler);
  }

  getAllSlots() {
    return this._http.get(this.myAppUrl + "api/Slots").map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  updateStudentId(slot) {
    return this._http.put(this.myAppUrl + "api/Slots/UpdateStudent", slot).map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  deleteSlot(id) {
    return this._http.delete(this.myAppUrl + "api/Slots/DeleteSlot" + id).map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}
