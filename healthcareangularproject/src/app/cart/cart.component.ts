import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {
  constructor(private _router : Router){}

  items : any;
  total : number = 0;

  ngOnInit(){
    this.items = [];
		let cart = JSON.parse(localStorage.getItem('cart') || '{}');
		for (var i = 0; i < cart.length; i++) {
			let item = JSON.parse(cart[i]);
			this.items.push({
        id : item.medicine_id,
        price : item.medicine_price,
        image : item.medicine_img,
        category:item.category_name,
				medicine: item.medicine_name,
				quantity: item.medicine_quantity
			});
			this.total += item.medicine_price * item.medicine_quantity;
		}
  }

  isCartEmpty() : boolean{
    if(this.items.length === 0){
      return true
    }else{
      return false
    }
  }

  removeItem(medicineID : any){

    let cart: any = JSON.parse(localStorage.getItem('cart') || '{}');

    cart.splice(medicineID , 1);

		localStorage.setItem("cart", JSON.stringify(cart));
    window.location.reload()
  }

  increment(medicineID : any){

    let cart: any = JSON.parse(localStorage.getItem('cart') || '{}');

    JSON.parse(cart[medicineID]).medicine_quantity += 1;

    localStorage.setItem("cart", JSON.stringify(cart));
    
  }

  decrement(medicineID : any){

    let cart: any = JSON.parse(localStorage.getItem('cart') || '{}');

    cart[medicineID].medicine_quantity -= 1;
    
    localStorage.setItem("cart", JSON.stringify(cart));
    window.location.reload()
  }
  
  checkout() {
    this._router.navigate(['/checkout']);
  }

}