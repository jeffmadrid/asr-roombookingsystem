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
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";

import { EmployeeService } from "./services/employee.service";
import { AddEmployeeComponent } from "./components/add-employee/add-employee.component";
import { FetchEmployeeComponent } from "./components/fetch-employee/fetch-employee.component";

import { SlotService } from "./Services/slot.service";
import { AddRoomComponent } from './Components/add-room/add-room.component';
import { FetchSlotComponent } from './Components/fetch-slot/fetch-slot.component';
import { GetSlotComponent } from './Components/get-slot/get-slot.component';
import { FetchRoomComponent } from './Components/fetch-room/fetch-room.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AddEmployeeComponent,
    FetchEmployeeComponent,
    AddRoomComponent,
    FetchSlotComponent,
    GetSlotComponent,
    FetchRoomComponent
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
      { path: "counter", component: CounterComponent },
      { path: "fetch-data", component: FetchDataComponent },
      { path: "fetch-employee", component: FetchEmployeeComponent },
      { path: "add-employee", component: AddEmployeeComponent },
      { path: "employee/edit/:id", component: AddEmployeeComponent },
      { path: "add-room", component: AddRoomComponent },
      { path: "fetch-slot", component: FetchSlotComponent },
      { path: "get-slot", component: GetSlotComponent }

    ])
  ],
  providers: [EmployeeService, SlotService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
