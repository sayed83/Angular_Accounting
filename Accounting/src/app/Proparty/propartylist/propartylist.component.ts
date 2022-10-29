import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-propartylist',
  templateUrl: './propartylist.component.html',
  styleUrls: ['./propartylist.component.css']
})
export class PropartylistComponent implements OnInit {
  Properties: any[] = [
    {
      Id:1,
      Name:"Hotel Niribili",
      Type: "House",
      Price:12000
    },
    {
      Id:1,
      Name:"Hotel Niribili1",
      Type: "House",
      Price:22000
    },
    {
      Id:1,
      Name:"Hotel Niribili1",
      Type: "House",
      Price:32000
    },
    {
      Id:1,
      Name:"Hotel Niribili1",
      Type: "House",
      Price:42000
    },

]
  constructor() { }

  ngOnInit() {
  }

}
