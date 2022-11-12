import { Component, OnInit } from '@angular/core';
import { ReimbursementService } from 'src/app/shared/reimbursement.service';
import {NgModel,NgForm,NgControl,NgModelGroup} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-emp-signup',
  templateUrl: './emp-signup.component.html',
  styleUrls: ['./emp-signup.component.css']
})
export class EmpSignupComponent implements OnInit {
  EmailAvailable=true;
  constructor(public route:Router ,public service:ReimbursementService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm)
  {
    const em=form.controls['email'].value;
    console.warn("This is the email",em);
    this.service.getSignup().subscribe((record: any)=>
    {
      this.EmailAvailable=true;
      const obj=record.find((a: any)=>
      {
        if(a.email == em)
        {
          console.warn("Email is not available")
          this.EmailAvailable=false;
        }
      })
      console.warn("Email Available: ",this.EmailAvailable)
      if(this.EmailAvailable)
      {
        this.service.postSignup().subscribe(
          res=>{
            console.warn(res);
            alert("signup successful!!");
            setTimeout(()=>
            {
              this.route.navigate(['login']);
            },2000);
          }
        )
      }
    })
  }

}
