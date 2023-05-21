import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MedicinesService } from '../services/medicines.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-medicine-add',
  templateUrl: './medicine-add.component.html',
  styleUrls: ['./medicine-add.component.css']
})
export class MedicineAddComponent {

  constructor(private _http : HttpClient , private medicineService : MedicinesService , private _router : Router){}

  addMedicineItem : any = {
    categoryname: "",
    name : "",
    image : "",
    price : 0,
    seller:"",
    details : "",
    quantity : 0,
    customerID : ""
  }

  addMedicine(){

    this.medicineService.addNewItem({
      "medicine_id" : this.addMedicineItem.customerID,
      "category_name":(this.addMedicineItem.categoryname).toLowerCase(),
      "medicine_name" : (this.addMedicineItem.name).toLowerCase(),
      "medicine_img" : this.addMedicineItem.image,
      "medicine_price" : this.addMedicineItem.price,
      "medicine_seller" : this.addMedicineItem.seller,
      "medicine_details" : this.addMedicineItem.details,
      "medicine_quantity" : this.addMedicineItem.quantity,
      "medicine_added" : false
    }).subscribe((result) => {
      console.log(result)
    })

    alert("New item Added")

    this._router.navigate(['/medicines'])
  }

}


