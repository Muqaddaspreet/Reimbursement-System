import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ReimbursementService } from 'src/app/shared/reimbursement.service';

@Component({
  selector: 'app-emp-dashboard',
  templateUrl: './emp-dashboard.component.html',
  styleUrls: ['./emp-dashboard.component.css']
})
export class EmpDashboardComponent implements OnInit {

  constructor(public route:ActivatedRoute, public service:ReimbursementService) { }
  collection: any=[];
  emailParams=this.route.snapshot.params['email'];
  ngOnInit(): void {
    this.emailParams=this.route.snapshot.params['email'];
    console.warn(this.emailParams);
    this.service.getReimbursement().subscribe((res:any)=>
    {
      console.log(res);
      const result = res.filter((element: { requestedBy: any; }) => element.requestedBy === this.emailParams);
      console.log(result);
      
      function sortByDate(a:any, b:any) {
        if (a.date < b.date) {
            return 1;
        }
        if (a.date > b.date) {
            return -1;
        }
        return 0;
      }
      const newResult = result.sort(sortByDate);
      console.log("updated",newResult);
      this.collection=newResult;
      console.log(this.collection);
      // const objID = res.find((a: any)=>
      // {
      //   if(a.requestedBy === emailParams)
      //   {
      //     console.warn(res);
      //     this.collection=res;
      //     return a.reimbursementId;
      //   }
      // })
      
    })
  }

  deleteData(ID:any)
  {
    console.warn("ID is: ",ID);
    //this.collection.splice(item-1,1)
    this.service.deleteReimbursement(ID).subscribe((res:any)=>
    {
      console.log("result",res);
      window.location.reload();
    })
  }

}
