import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { MainComponent } from './main/main.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { LandingpageComponent } from './landingpage/landingpage.component';
import { PasswordMatchDirective } from './_validators';
import { MedicinesComponent } from './medicines/medicines.component';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { MedicineAddComponent } from './medicine-add/medicine-add.component';
import { ProfileComponent } from './profile/profile.component';
import { SuccessComponent } from './success/success.component';
import { MedicineListComponent } from './medicine-list/medicine-list.component';
import { MedicineUpdateComponent } from './medicine-update/medicine-update.component';
import { MedicineDetailsComponent } from './medicine-details/medicine-details.component'

@NgModule({
  declarations: [
   
    MainComponent,
        RegisterComponent,
        LoginComponent,
        HomeComponent,
        LandingpageComponent,
        PasswordMatchDirective,
        MedicinesComponent,
        CartComponent,
        CheckoutComponent,
        MedicineAddComponent,
        ProfileComponent,
        SuccessComponent,
        MedicineListComponent,
        MedicineUpdateComponent,
        MedicineDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [MainComponent]
})
export class AppModule { }
