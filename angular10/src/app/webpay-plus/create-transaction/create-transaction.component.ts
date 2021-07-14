import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-create-transaction',
  templateUrl: './create-transaction.component.html',
  styleUrls: ['./create-transaction.component.css']
})



export class CreateTransactionComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() url:string;

  ngOnInit(): void {

    
  }



}