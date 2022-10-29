import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccHeadComponent } from './acc-head/acc-head.component';
import { CompanylistComponent } from './components/companylist/companylist.component';
import { CompanyComponent } from './components/company/company.component';
import { FormsModule , ReactiveFormsModule} from '@angular/forms';
import { InspactionComponent } from './components/inspaction/inspaction.component';
import { ShowInspactionComponent } from './components/inspaction/show-inspaction/show-inspaction.component';
import { AddEditInspactionComponent } from './components/inspaction/add-edit-inspaction/add-edit-inspaction.component';
import { InspactionApiService } from './services/inspaction-api.service';
import { AddEditCardComponent } from './components/cards/add-edit-card/add-edit-card.component';
import { CardlistComponent } from './components/cards/cardlist/cardlist.component';
import { CompanyService } from './services/company.service';
import { CardsService } from './services/cards.service';
import { PropartyCardComponent } from './Proparty/proparty-card/proparty-card.component';
import { PropartylistComponent } from './Proparty/propartylist/propartylist.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    AccHeadComponent,
    CompanylistComponent,
    CompanyComponent,
    InspactionComponent,
    ShowInspactionComponent,
    AddEditInspactionComponent,
    AddEditCardComponent,
    CardlistComponent,
    PropartyCardComponent,
    PropartylistComponent,
      NavBarComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule ,
    ReactiveFormsModule,

  ],
  providers: [InspactionApiService,CompanyService,CardsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
