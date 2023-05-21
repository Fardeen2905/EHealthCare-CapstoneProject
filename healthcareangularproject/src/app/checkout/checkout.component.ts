import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {
  checkoutForm: FormGroup;
  submitted: boolean = false;

  constructor(private _http : HttpClient, private _router: Router, private _formBuilder: FormBuilder) {
    this.checkoutForm = this._formBuilder.group({
      name: ['', Validators.required],
      email: ['', Validators.required, Validators.email],
      address: ['', Validators.required],
      card: ['', Validators.required],
    });
  }

  get f() {
    return this.checkoutForm.controls;
  }

  items: any;
  total: number = 0;

  userPurchase: any = {
    name: '',
    email: '',
    address: '',
    items: [],
    total: 0,
  };

  ngOnInit() {
    this.items = [];
    let cart = JSON.parse(localStorage.getItem('cart') || '{}');
    for (var i = 0; i < cart.length; i++) {
      let item = JSON.parse(cart[i]);
      this.items.push({
        // id : item.product_id,
        price: item.medicine_price,
        // image : item.product_img,
        medicine: item.medicine_name,
        quantity: item.medicine_quantity,
      });
      this.total += item.medicine_price * item.medicine_quantity;
    }
    this.userPurchase.name = localStorage.getItem('firstname');
    console.log(this.userPurchase.name);
    this.userPurchase.email = localStorage.getItem('email');
    localStorage.setItem('address', this.userPurchase.address);
  }

  makePurchase() {
    this.submitted = true;
    if (this.checkoutForm.invalid) {
      return;
    }

    this.items.map((item: any) => {
      this.userPurchase.items.push(item);
    });

    this.userPurchase.total = this.total;

    this._http.post("http://localhost:3001/purchase" , this.userPurchase).subscribe((result) => {
      console.log(result)
    })

    localStorage.removeItem("cart")

    this._router.navigate(['/success'])

    
  }
}
