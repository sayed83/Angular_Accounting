import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-proparty-card',
  templateUrl: './proparty-card.component.html',
  styleUrls: ['./proparty-card.component.css']
})
export class PropartyCardComponent implements OnInit {
  @Input() Property : any;
  // Property: any = {
  //   Id:1,
  //     Name:"Hotel Niribili",
  //     Type: "House",
  //     Price:12000
  // }
  constructor() { }

  ngOnInit() {
  }

}
