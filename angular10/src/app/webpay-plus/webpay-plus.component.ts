import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-webpay-plus',
  templateUrl: './webpay-plus.component.html',
  styleUrls: ['./webpay-plus.component.css']
})
export class WebpayPlusComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() trans:any;
  Amount:number;
  ClientCode:string;
  BuyOrder:string;
  Url:string;

  ModalTitle:string;
  ActivateAddEditTransComp:boolean=false;

  /*
  DepartmentIdFilter:string="";
  DepartmentNameFilter:string="";
  DepartmentListWithoutFilter:any=[];*/

  ngOnInit(): void {
    this.Amount=this.trans.Amount;
    this.ClientCode=this.trans.ClientCode;
    this.BuyOrder=this.trans.BuyOrder;
    //this.createTrans();
  }

  addClick(){
    this.trans={
      Amount:1000,
      ClientCode:"",
      BuyOrder:""
    }
    this.ModalTitle="Carrito de compras";
    this.ActivateAddEditTransComp=true;

  }


  closeClick(){
    this.ActivateAddEditTransComp=false;
    //this.refreshDepList();
  }


  createTrans(){
    var val = {Amount:this.Amount,
               ClientCode:this.ClientCode,
               BuyOrder:this.BuyOrder};

    this.service.createTransaction(val).subscribe(res=>{
      //alert(`Liga de pago = ${res.toString()}`);
      this.Url = res.toString();
    });
    
    this.ModalTitle="";
    this.ActivateAddEditTransComp=true;
  }

}