import { Component } from '@angular/core';
import { Company } from './models/company';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Accounting';
  company: Company[] = [];
  companyToEdit?:Company;
  constructor() {};

  ngOnInit() : void {
    //this.company = this.companyService.getCompay1();
    //this.companyService.getCompany().subscribe((result: Company[]) => (this.company = result));
    //console.log(this.company);
  }
}
