import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ReimbursementService } from 'src/app/shared/reimbursement.service';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-emp-add-data',
  templateUrl: './emp-add-data.component.html',
  styleUrls: ['./emp-add-data.component.css']
})
export class EmpAddDataComponent implements OnInit {

  @ViewChild('form') dataForm:NgForm;

  // add = new FormGroup({
  //   requestedBy: new FormControl(''),
  //   date: new FormControl(''),
  //   reimbursementType: new FormControl(''),
  //   requestedValue: new FormControl(''),
  //   currency: new FormControl(''),
  //   receiptImageLink:new FormControl(''),
  //   //
  //   reimbursementID:new FormControl(''),
  //   approvedValue:new FormControl(''),
  //   approvedBy:new FormControl(''),
  //   receiptAttached:new FormControl(''),
  //   requestedPhase:new FormControl(''),
  //   internalNotes:new FormControl('')
  // })
  constructor(public router:ActivatedRoute,public route:Router,public service:ReimbursementService) { }
  emailParams=this.router.snapshot.params['email'];
  file!: File;
   fileType: boolean = false;
   fileUploaded: boolean = false;
  ngOnInit(): void {
  }

  // onload()
  // {
  //   console.log("Form is:",this.dataForm);
  //   this.dataForm.form.patchValue({
  //     requestedBy:this.emailParams
  //   })
  // }

  onSubmit(myform:NgForm)
  {
    // console.log("Form again is:",this.dataForm);
    requestedBy: new FormControl(this.emailParams);
    
    myform.form.patchValue({
      requestedBy:this.emailParams
    })
    var Val=myform.form.get('receiptImageLink')?.value;
    console.warn(Val);
    this.fileSelected(Val);
    if(Val== null || Val =='')
    {
      myform.form.patchValue({
        receiptAttached:"No"
      })
    }
    else{
      myform.form.patchValue({
        receiptAttached:"Yes"
      })
    }
    console.warn("receipt attached :  ",myform.form.get('receiptAttached')?.value);
    this.service.postReimbursementData().subscribe(
      res=>{
        console.warn(res);
        alert("Added successfully!!");
        setTimeout(()=>
        {
          this.route.navigate(['empdash',this.emailParams]);
        },2000);
      }
    )
  }
  fileSelected(file:any) {
    if (file != null) {
      this.file = file;
      if (this.file.type != "image/jpeg" && this.file.type != "image/pdf" && this.file.type != "image/png") {
        this.fileType = false;
      }
      else {
        this.fileUploaded = true;
        this.fileType = true;
      }
      console.log(this.file.type);
    }
  }


  // addReimbursement()
  // {
  //   console.warn(this.add.value);
  //   this.service.setStudent(this.add.value).subscribe((record:any)=>
  //   {
  //     console.warn('record is here',record);
  //     this.add.reset({})
  //     setTimeout(()=>
  //     {
  //       this.route.navigate(['empdash',this.emailParams]);
  //     },2000);
  //   })
    
  // }

}
