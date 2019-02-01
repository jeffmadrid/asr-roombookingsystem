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

import { SlotService } from "./Services/slot.service";
import { AddRoomComponent } from './Components/add-room/add-room.component';
import { FetchSlotComponent } from './Components/fetch-slot/fetch-slot.component';
import { FetchRoomComponent } from './Components/fetch-room/fetch-room.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AddRoomComponent,
    FetchSlotComponent,
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
      { path: "add-room", component: AddRoomComponent },
      { path: "fetch-slot", component: FetchSlotComponent },
      { path: "fetch-room", component: FetchRoomComponent }

    ])
  ],
  providers: [SlotService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
