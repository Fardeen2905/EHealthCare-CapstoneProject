import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingpageComponent } from './landingpage/landingpage.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthguardService } from './services/authguard.service';
import { MedicinesComponent } from './medicines/medicines.component';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { SuccessComponent } from './success/success.component';
import { ProfileComponent } from './profile/profile.component';
import { MedicineAddComponent } from './medicine-add/medicine-add.component';
import { MedicineListComponent } from './medicine-list/medicine-list.component';
import { MedicineDetailsComponent } from './medicine-details/medicine-details.component';

const routes: Routes = [
  {path: "", component:LandingpageComponent },
  {path:"home",component:HomeComponent,canActivate : [AuthguardService]},
  {path:"landingpage",component:LandingpageComponent, canActivate : [AuthguardService]},
  {path:"medicines",component:MedicinesComponent, canActivate : [AuthguardService]},
  {path:"cart",component:CartComponent, canActivate : [AuthguardService]},
  {path:"checkout",component:CheckoutComponent},
  {path:"success",component:SuccessComponent},
  {path:"profile",component:ProfileComponent},
  {path:"medicine-add",component:MedicineAddComponent},
  { path: "medicine-list", component: MedicineListComponent },
  {path:'medicine-details',component: MedicineDetailsComponent},
  {path:'medicine-details/:medicine_id',component: MedicineDetailsComponent },
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent}





];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
