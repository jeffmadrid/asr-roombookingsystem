import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { SlotService } from "./Services/slot.service";
import { AddRoomComponent } from './Components/add-room/add-room.component';
import { FetchSlotComponent } from './Components/fetch-slot/fetch-slot.component';
import { FetchRoomComponent } from './Components/fetch-room/fetch-room.component';
import { RoomService } from "./Services/room.service";
import { EditStudentComponent } from './Components/edit-student/edit-student.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AddRoomComponent,
    FetchSlotComponent,
    FetchRoomComponent,
    EditStudentComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    CommonModule,
    HttpClientModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "add-room", component: AddRoomComponent },
      { path: "fetch-slot", component: FetchSlotComponent },
      { path: "fetch-room", component: FetchRoomComponent },
      { path: "edit-student", component: EditStudentComponent },
      { path: "slot/edit/:roomId/:startTime/:staffId", component: EditStudentComponent }
    ])
  ],
  providers: [SlotService, RoomService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
