import { SharedService } from '../shared/shared.service';
import { PizzaToAddCart } from '../models/pizzaToAddCart';
import { PizzaTypeForOrder } from '../models/pizzaTypeForOrder';
import { SizeForOrder } from '../models/sizeForOrder';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { CustomService } from './custom.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonData } from '../models/commonData';

@Component({
  selector: 'app-custom',
  templateUrl: './custom.component.html',
  styleUrls: ['./custom.component.css']
})
export class CustomComponent implements OnInit {
  constructor(
    private orderService: CustomService,
    private formBuilder: FormBuilder,
    private router: ActivatedRoute,
    private sharedService: SharedService
  ) {
    this.router.params.subscribe((param)=>{
      this.pizzaId=  param['id'];
    });
  }

  submitted = false;
 finalPrice:number;
  submitForm: FormGroup;
  pizzaId:number;
  pizzaObj:PizzaTypeForOrder;
  sizeId: FormControl = new FormControl('', [Validators.required]);
  pizzaTypeId = new FormControl('', Validators.required);
  numberOfPizza = new FormControl('', Validators.required);
  addExtraCheese = new FormControl('1');
  sizesForOrder: SizeForOrder[] = [];
  pizzaTypesForOrder: PizzaTypeForOrder[] = [];
  toppingsForOrder: CommonData[] = [];
  selectedToppings: CommonData[] = [];
  pizzaToAddCart: PizzaToAddCart = new PizzaToAddCart();

  edgeTypeId = new FormControl('0');

  ngOnInit() {


    this.selectedToppings = [];
    this.getAllSizesFromService();
    this.getAllPizzaTypsFromService();
    this.getAllToppings();
    this.createValidation();
    this.addExtraCheese.setValue(false);
  }

  createValidation() {
    this.submitForm = this.formBuilder.group({
      sizeId: this.sizeId,
      pizzaTypeId: this.pizzaTypeId,
      numberOfPizza: this.numberOfPizza,
      edgeTypeId: this.edgeTypeId
    });
  }

  get f() {
    return this.submitForm.controls;
  }

  getAllSizesFromService() {

    this.orderService.getAllSizes().subscribe(res => {
      this.sizesForOrder = res;
    });
  }

  getAllPizzaTypsFromService() {
    this.orderService.getAllPizzaTypes().subscribe(res => {
      this.pizzaTypesForOrder = res;
      if(this.pizzaId){
        this.pizzaObj=this.pizzaTypesForOrder.find(r=>r.id==this.pizzaId);
        this.finalPrice=this.pizzaObj.price;
      }
    });
  }

  getAllToppings() {
    this.toppingsForOrder = [];
    this.orderService.getToppings().subscribe(res => {
      this.toppingsForOrder = res;
    });
  }

  // Cahnge event of checkboxesd
  onChange(event) {
    if (event.checked) {
      const toppingPrice=this.toppingsForOrder.find(r=>r.id==event.source.value);
      this.selectedToppings.push(toppingPrice);

      this.finalPrice +=toppingPrice.price;
    } else {
      const i = this.selectedToppings.findIndex(x => x === event.source.value);
      this.selectedToppings.splice(i, 1);
      const toppingPrice=this.toppingsForOrder.find(r=>r.id==event.source.value);
      this.finalPrice -=toppingPrice.price;
    }
  }
  onChangeExtraCheese(event) {
    if (event.checked) {
      this.finalPrice +=50;
    } else {
      this.finalPrice -=50;
    }
  }

  onSubmit() {


    const x = this.selectedToppings;
    console.log("inside the onSubmit form "+JSON.stringify(this.selectedToppings));
    this.submitted = true;
    this.pizzaToAddCart = this.submitForm.value;
    this.pizzaToAddCart.pizzaTypeId=this.pizzaObj.id;
    this.pizzaToAddCart.toppings = this.selectedToppings.map(r=>r.id);
    this.pizzaToAddCart.edgeTypeId = this.edgeTypeId.value;
    this.pizzaToAddCart.extraCheese = this.addExtraCheese.value;
    console.log('final object for submit '+JSON.stringify(this.pizzaToAddCart));

    this.sendPizzasToService();
  }


  sendPizzasToService() {
    this.orderService.submitPizza(this.pizzaToAddCart).subscribe(res => {
      this.sendTotalNumbersToNavbar(res);
    });
  }

  sendTotalNumbersToNavbar(total: number) {
    this.sharedService.sendTotalNumber(total);
  }

  onChangeSize(sizeId){

    const size= this.sizesForOrder.find(r=>r.id==sizeId);
    if(size.name==="Small"){
      this.finalPrice=this.pizzaObj.price* size.multiplier;
    }
    if(size.name==="Medium"){
      this.finalPrice=this.pizzaObj.price* size.multiplier;
    }
    if(size.name==="Large"){
      this.finalPrice=this.pizzaObj.price* size.multiplier;
    }
  }
}
