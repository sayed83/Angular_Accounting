import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { InspactionApiService } from 'src/app/services/inspaction-api.service';

@Component({
  selector: 'app-show-inspaction',
  templateUrl: './show-inspaction.component.html',
  styleUrls: ['./show-inspaction.component.css']
})
export class ShowInspactionComponent implements OnInit {

  inspactionList$!:Observable<any[]>;
  inspactionTypeList$!:Observable<any[]>;
  inspactionTypeList: any = [];

  // Map foreign key data
  inspactionTypesMap:Map<number,string> = new Map();

  constructor(private service:InspactionApiService) { }

  ngOnInit(): void {
    this.inspactionList$ = this.service.getInspactionList();
    this.inspactionTypeList$ = this.service.getInspactionTypeList();
    this.refreshInspectionTypeMap();
  }

  //Variables (properties)
  modalTitle:string = '';
  activatedAddEditInspectionComponent:boolean = false;
  inspaction:any;

  modalAdd(){
    this.inspaction = {
      inspactionId:0,
      status:null,
      comments:null,
      inspactionTypeId:null
    }
    this.modalTitle = "Add Inspection";
    this.activatedAddEditInspectionComponent = true;
  }

  modalEdit(item:any){
    this.inspaction = item;
    this.modalTitle = "Edit Inspaction"
    this.activatedAddEditInspectionComponent = true;
  }

  delete(item:any){
    if(confirm(`Are you sure you want to delete inspection ${item.inspactionId}`)){
      this.service.deleteInspaction(item.inspactionId).subscribe(res => {
        var closeModelBtn = document.getElementById('add-edit-modal-close');
        if(closeModelBtn){
          closeModelBtn.click();
        }

        var showDeleteSuccess = document.getElementById('delete-success-alert');
        if(showDeleteSuccess){
          showDeleteSuccess.style.display = 'block';
        }
        setTimeout(function(){
          if(showDeleteSuccess){
            showDeleteSuccess.style.display = 'none';
          }
        },4000);
        this.inspactionList$ = this.service.getInspactionList();
      })
    }
  }

  modalClose(){
    this.activatedAddEditInspectionComponent =false;
    this.inspactionList$ = this.service.getInspactionList();
  }
  refreshInspectionTypeMap(){
    this.service.getInspactionTypeList().subscribe(data =>{
      this.inspactionTypeList = data;

      for(let i = 0; i <data.length; i++){
        this.inspactionTypesMap.set(this.inspactionTypeList[i].inspactionTypeId,this.inspactionTypeList[i].inspactionName)
      }
    })
  }
}
