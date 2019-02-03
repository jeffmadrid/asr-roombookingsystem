import { Injectable, Inject } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/observable/throw";

@Injectable()
export class RoomService {
  myAppUrl: string = "";

  constructor(private _http: Http, @Inject("BASE_URL") baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getAll() {
    return this._http.get(this.myAppUrl + "api/Room/Index").map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  saveRoom(roomId) {
    return this._http.post(this.myAppUrl + "api/Room/CreateRoom", roomId).map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  deleteRoom(id) {
    return this._http.delete(this.myAppUrl + "api/Room/DeleteRoom/" + id).map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}
