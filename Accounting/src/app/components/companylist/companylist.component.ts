import { Component, OnInit } from '@angular/core';
import { Company } from 'src/app/models/company';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-companylist',
  templateUrl: './companylist.component.html',
  styleUrls: ['./companylist.component.css']
})
export class CompanylistComponent implements OnInit {
  companies: Company[] = [];
  companyToEdit?: Company;

  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    this.companyService.getCompany().subscribe((result: Company[]) => (this.companies = result));
    console.log(this.companies);
  }

  initNewCompany(){
    debugger
    this.companyToEdit = new Company();
  }

  editCompany(com: Company){
    
    this.companyToEdit = com;
  }
}
