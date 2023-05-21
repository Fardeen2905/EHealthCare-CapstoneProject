import { Component } from '@angular/core';
import { IMedicines } from '../models/medicines';
import { MedicinesService } from '../services/medicines.service';

@Component({
  selector: 'app-medicines',
  templateUrl: './medicines.component.html',
  styleUrls: ['./medicines.component.css']
})
export class MedicinesComponent {

  constructor(private _medicineService : MedicinesService){}

  medicines : IMedicines[] = [];

  ngOnInit(){
    this._medicineService.getMedicinesFromDb().subscribe((result) => {
      this.medicines = result;
      console.log(this.medicines)
    })
   console.log(this.medicines)
  }

  viewDetails(medicine : IMedicines){
      alert(JSON.stringify(medicine))
  }

  isAdmin() : boolean{
    if(sessionStorage.getItem("user") === "admin"){
      return true;
    }else{
      return false;
    }
  }

  addToCart(medicine : IMedicines){

    let itemToAdd ={
        medicine_id: medicine.medicine_id,
        category_name: medicine.category_name,
        medicine_name: medicine.medicine_name,
        medicine_img: medicine.medicine_img,
        medicine_seller:medicine.medicine_seller,
        medicine_price: medicine.medicine_price,
        medicine_details: medicine.medicine_details,
        medicine_quantity: 1
    }

    this.medicines.map((med) => {
      if(med.medicine_id === medicine.medicine_id){
        med.medicine_quantity -= 1;
        med.medicine_added = true
      }
    })

    if (localStorage.getItem('cart') == null) {
      let cart: any = [];
      cart.push(JSON.stringify(itemToAdd));
      localStorage.setItem('cart', JSON.stringify(cart));
    }else {
      let cart: any = JSON.parse(localStorage.getItem('cart') || '{}');
      let index: number = -1;
      for (var i = 0; i < cart.length; i++) {
        let cartitem = JSON.parse(cart[i]);
        if (cartitem.medicine_id == itemToAdd.medicine_id) {
          index = i;
          break;
        }
      }
      if (index == -1) {
        cart.push(JSON.stringify(itemToAdd));
        localStorage.setItem('cart', JSON.stringify(cart));
      } else {
        let item = JSON.parse(cart[index]);
        item.medicine_quantity += 1;
        cart[index] = JSON.stringify(item);
        localStorage.setItem("cart", JSON.stringify(cart));
      }
    }

    alert("Added to the Cart")

  }



}

