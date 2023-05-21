import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MedicinesService } from '../services/medicines.service';
import { IMedicines } from '../models/medicines';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  medicines : any[] = []
  searchItem : any = "";
  searchResult : any[] = []
  noneMessage : any = "";

  constructor(private _router : Router , private _medicineService : MedicinesService){}

  ngOnInit(){

    this._medicineService.getMedicinesFromDb().subscribe((result) => {
      this.medicines = result
    })
  }

  handleSearch(){
    this.noneMessage = ""
    this.searchResult = []
    if(this.searchItem != ""){
      
      this.medicines.map((item) => {
        if(item.medicine_name.includes(this.searchItem)){
          this.searchResult.push(item)
        } 
      })
    }else{
      this.noneMessage = "Please enter the medicine name"
      return
    }

    if(this.searchResult.length === 0){
      this.noneMessage = "Sorry , Your Search is Unavailable"
    }
  }

  logout(){
    alert("Are you sure you want to logout?")
    sessionStorage.removeItem("user");
    this._router.navigate(['/landingage'])
    
  }

  deleteAccount(){
    alert("Are you sure you want to delete the Account?")
    sessionStorage.removeItem("user");

    localStorage.removeItem("user");
    localStorage.removeItem("password")

    this._router.navigate(['/landingpage'])
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

    this.searchResult.map((med) => {
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
