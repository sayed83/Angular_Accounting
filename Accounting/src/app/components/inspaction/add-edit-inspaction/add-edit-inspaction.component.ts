import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { InspactionApiService } from 'src/app/services/inspaction-api.service';

@Component({
  selector: 'app-add-edit-inspaction',
  templateUrl: './add-edit-inspaction.component.html',
  styleUrls: ['./add-edit-inspaction.component.css']
})
export class AddEditInspactionComponent implements OnInit {

  inspactionList$!: Observable<any[]>;
  statusList$!: Observable<any[]>;
  inspactionTypesList$!: Observable<any[]>;

  constructor(private service:InspactionApiService) { }

  @Input() inspaction:any;
  inspactionId: number = 0;
  status: string = "";
  comments: string = "";
  inspactionTypeId!: number;

  ngOnInit(): void {
    this.inspactionId = this.inspaction.inspactionId;
    this.status = this.inspaction.status;
    this.comments = this.inspaction.comments;
    this.inspactionTypeId = this.inspaction.inspactionTypeId;
    this.inspactionList$ = this.service.getInspactionList();
    this.statusList$ = this.service.getStatusList();
    this.inspactionTypesList$ = this.service.getInspactionTypeList();
  }

  addInspaction(){
    var inspaction = {
      status:this.status,
      comments:this.comments,
      inspactionTypeId:this.inspactionTypeId
    }

    this.service.addInspaction(inspaction).subscribe(res => {
      var closeModelBtn = document.getElementById('add-edit-modal-close');
      if(closeModelBtn){
        closeModelBtn.click();
      }

      var showAddSuccess = document.getElementById('add-success-alert');
      if(showAddSuccess){
        showAddSuccess.style.display = 'block';
      }

      setTimeout(function(){
        if(showAddSuccess){
          showAddSuccess.style.display = 'none';
        }
      },4000);

    })
  }
  updateInspaction(){
    var inspaction = {
      inspactionId:this.inspactionId,
      status:this.status,
      comments:this.comments,
      inspactionTypeId:this.inspactionTypeId
    }
    var id:number = this.inspactionId;
    this.service.updateInspaction(id,inspaction).subscribe(res => {
      debugger;
      var closeModelBtn = document.getElementById('add-edit-modal-close');
      if(closeModelBtn){
        closeModelBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-success-alert');
      if(showUpdateSuccess){
        showUpdateSuccess.style.display = 'block';
      }

      setTimeout(function(){
        if(showUpdateSuccess){
          showUpdateSuccess.style.display = 'none';
        }
      },4000);

    })
  }
}
