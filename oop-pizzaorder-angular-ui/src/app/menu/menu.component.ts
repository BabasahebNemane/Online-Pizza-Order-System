import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonData } from '../models/commonData';
import { PizzaToAddCart } from '../models/pizzaToAddCart';
import { PizzaTypeForOrder } from '../models/pizzaTypeForOrder';
import { SizeForOrder } from '../models/sizeForOrder';
import { CustomService } from '../custom/custom.service';
import { SharedService } from '../shared/shared.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(
    private orderService: CustomService,
    private formBuilder: FormBuilder,
    private router: Router,
    private sharedService: SharedService
  ) { }


  sizeId: FormControl = new FormControl('', [Validators.required]);
  pizzaTypeId = new FormControl('', Validators.required);
  numberOfPizza = new FormControl('', Validators.required);
  sizesForOrder: SizeForOrder[] = [];
  pizzaTypesForOrder: PizzaTypeForOrder[] = [];
  selectedToppings: CommonData[] = [];
  pizzaToAddCart: PizzaToAddCart = new PizzaToAddCart();
  selected:number=2;

  ngOnInit() {
    this.selectedToppings = [];
    this.getAllSizesFromService();
    this.getAllPizzaTypsFromService();
  }

  getAllSizesFromService() {
    this.orderService.getAllSizes().subscribe(res => {
      this.sizesForOrder = res;
    });
  }

  getAllPizzaTypsFromService() {
    this.orderService.getAllPizzaTypes().subscribe(res => {
      this.pizzaTypesForOrder = res;
      this.pizzaTypesForOrder.map(r=>{
        r.assignedValue=r.price})

    });
  }

  onChangeSize(sizeId, pizzaId){

    const size= this.sizesForOrder.find(r=>r.id==sizeId);
    if(size.name==="Small"){
      this.pizzaTypesForOrder.filter(r=>r.id==pizzaId).map(r=>{
        r.assignedValue=r.price * size.multiplier});
    }
    if(size.name==="Medium"){
      this.pizzaTypesForOrder.filter(r=>r.id==pizzaId).map(r=>{
        r.assignedValue=r.price * size.multiplier});
    }
    if(size.name==="Large"){
      this.pizzaTypesForOrder.filter(r=>r.id==pizzaId).map(r=>{
        r.assignedValue=r.price * size.multiplier});
    }

  }

  addPizzaToCart(pizzaId){
    const data= this.pizzaTypesForOrder.find(r=>r.id==pizzaId);
    const size= this.pizzaTypesForOrder.find(r=>r.id==pizzaId);
    this.pizzaToAddCart.pizzaTypeId = pizzaId;
    this.pizzaToAddCart.toppings = [];
    this.pizzaToAddCart.sizeId = size.id;
    this.pizzaToAddCart.numberOfPizza = 1;
    this.sendPizzasToService();
  }


  sendPizzasToService() {
    this.orderService.submitPizza(this.pizzaToAddCart).subscribe(res => {
     // this.sendTotalNumbersToNavbar(res);
     console.log("Final result "+JSON.stringify(res));
    });
  }

  onCustomizeClick(pizzaId){

this.router.navigate(['/','custom', pizzaId]);

  }

}
