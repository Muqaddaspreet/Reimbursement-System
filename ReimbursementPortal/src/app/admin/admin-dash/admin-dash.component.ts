import { Component, OnInit } from '@angular/core';
import { ReimbursementService } from 'src/app/shared/reimbursement.service';

@Component({
  selector: 'app-admin-dash',
  templateUrl: './admin-dash.component.html',
  styleUrls: ['./admin-dash.component.css']
})
export class AdminDashComponent implements OnInit {

  constructor(public service:ReimbursementService) { }
  collection: any=[];
  heading='';
  key=0;
  requestedBy='';

  ngOnInit(): void {
    this.service.getReimbursement().subscribe((res:any)=>
    {
      this.heading='Pending Requests';
      this.key=0;
      // console.log(res);
      const result = res.filter((element: { requestedPhase: any; }) => element.requestedPhase === 'To be processed');
      // console.log(result);
      this.collection=result;
      // console.log(this.collection);
      
    })
  }

  pending()
  {
    this.heading='Pending Requests';
    this.service.getReimbursement().subscribe((res:any)=>
    {
      this.heading='Pending Requests';
      this.key=0;
      // console.log(res);
      const result = res.filter((element: { requestedPhase: any; }) => element.requestedPhase === 'To be processed');
      // console.log(result);
      this.collection=result;
      // console.log(this.collection);
      
    })
  }

  decline()
  {
    this.heading='Declined Requests';
    this.key=1;
    this.service.getReimbursement().subscribe((res:any)=>
    {
      // console.log(res);
      const result = res.filter((element: { requestedPhase: string; approvedValue: number; }) => element.requestedPhase === 'Processed' && element.approvedValue === 0);
      // console.log(result);
      this.collection=result;
      // console.log(this.collection);
      
    })
  }

  approve()
  {
    this.heading='Approved Requests';
    this.key=2;
    this.service.getReimbursement().subscribe((res:any)=>
    {
      console.log(res);
      const result = res.filter((element: { requestedPhase: string; approvedValue: number; }) => element.requestedPhase === 'Processed' && element.approvedValue !== 0);
      console.log(result);
      this.collection=result;
      console.log(this.collection);
      
    })
  }

  declineRequest(ID:any)
  {
    this.service.getReimbursement().subscribe((res:any)=>
    {
      const result = res.filter((element: { reimbursementID: any; })=> element.reimbursementID === ID);
      const obj=result[0];
      console.log(obj);
      obj.requestedPhase='Processed';
      this.service.updateReimbursement(ID, obj).subscribe((record:any)=>
      {
        console.warn('record is here',record)
        alert("Request Declined");
      })
    })
    window.location.reload();
  }

  dropdown(dropValue:any)
  {
    console.warn(dropValue);
      const result = this.collection.filter((element: { reimbursementType: any; })=>element.reimbursementType===dropValue);
      console.log("Result after filter",result);
      this.collection=result;
  }

  SearchRequestedBy(email:string)
  {
    const result = this.collection.filter((element: { requestedBy: string; })=>element.requestedBy===email);
      console.log("search after filter",result);
      this.collection=result;
  }

}
