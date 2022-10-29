import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Company } from 'src/app/models/company';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {
  @Input() company?: Company;
  @Output() companyUpdated = new EventEmitter<Company[]>()
  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
  }

  updateCompany(company:Company){
    this.companyService.updateCompany(company).subscribe((companies:Company[]) => this.companyUpdated.emit(companies));
  }

  createCompany(company: Company){
    this.companyService.createCompany(company).subscribe((companies:Company[]) => this.companyUpdated.emit(companies));
  }

  deleteCompany(company: Company){
    this.companyService.deleteCompany(company).subscribe((companies:Company[]) => this.companyUpdated.emit(companies));
  }

}
