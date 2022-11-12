import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ReimbursementService } from 'src/app/shared/reimbursement.service';
import {FormGroup, FormControl,Validators} from '@angular/forms';

@Component({
  selector: 'app-emp-update-data',
  templateUrl: './emp-update-data.component.html',
  styleUrls: ['./emp-update-data.component.css']
})
export class EmpUpdateDataComponent implements OnInit {
  edit = new FormGroup({
    requestedBy: new FormControl(''),
    date: new FormControl('',[Validators.required]),
    reimbursementType: new FormControl('',[Validators.required]),
    requestedValue: new FormControl('',[Validators.required]),
    currency: new FormControl('',[Validators.required]),
    //
    reimbursementID:new FormControl(''),
    approvedValue:new FormControl(''),
    approvedBy:new FormControl(''),
    receiptAttached:new FormControl(''),
    receiptImageLink:new FormControl(''),
    requestedPhase:new FormControl(''),
    internalNotes:new FormControl('')


  })
  emailParams='';

  constructor(public route:Router, public router:ActivatedRoute, public service:ReimbursementService) { }

  ngOnInit(): void {
    console.warn(this.router.snapshot.params['id'])
    this.service.getReimbursementData(this.router.snapshot.params['id']).subscribe((record: any)=>
    {
      this.emailParams=record['requestedBy'];
      var dateGet=Date.parse(record['date']);
      console.warn("result", record)
      this.edit = new FormGroup({
        requestedBy: new FormControl(record['requestedBy']),
        date: new FormControl(record['date'].split('T')[0]),
        reimbursementType: new FormControl(record['reimbursementType']),
        requestedValue: new FormControl(record['requestedValue']),
        currency: new FormControl(record['currency']),

        reimbursementID:new FormControl(record['reimbursementID']),
        approvedValue:new FormControl(record['approvedValue']),
        approvedBy:new FormControl(record['approvedBy']),
        receiptAttached:new FormControl(record['receiptAttached']),
        receiptImageLink:new FormControl(record['receiptImageLink']),
        requestedPhase:new FormControl(record['requestedPhase']),
        internalNotes:new FormControl(record['internalNotes']),
      })
    })
    console.log("This is edit",this.edit.value);
  }

  updateCollection()
  {
    // console.warn(this.edit.value);
    this.service.updateReimbursement(this.router.snapshot.params['id'], this.edit.value).subscribe((record:any)=>
    {
      console.warn('record is here',record)
      alert("Update successful!!");
      //this.editstudent.reset({})
    })
    setTimeout(()=>
        {
          this.route.navigate(['empdash',this.edit.value.requestedBy],);
        },2000);
  }

  get date()
  {
    return this.edit.get('date');
  }
  get reimbursementType()
  {
    return this.edit.get('reimbursementType');
  }
  get requestedValue()
  {
    return this.edit.get('requestedValue');
  }
  get currency()
  {
    return this.edit.get('currency');
  }

}
