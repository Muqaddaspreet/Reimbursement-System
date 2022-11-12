import { Component, OnInit } from '@angular/core';
import {FormGroup,FormControl, Validators} from '@angular/forms'
import { Router } from '@angular/router';
import { ReimbursementService } from 'src/app/shared/reimbursement.service';

@Component({
  selector: 'app-emp-login',
  templateUrl: './emp-login.component.html',
  styleUrls: ['./emp-login.component.css']
})
export class EmpLoginComponent implements OnInit {

  loginData = new FormGroup({
    email: new FormControl('',[Validators.required]),
    password: new FormControl('',[Validators.required])
  })
  get email()
  {
    return this.loginData.get('email');
  }
  get password()
  {
    return this.loginData.get('password');
  }


  constructor(public route:Router,public service:ReimbursementService) { }

  ngOnInit(): void {
  }

  Login()
  {
    this.service.getSignup().subscribe((record: any)=>
    {
      var user=false;
      var adminFlag=0;
      const objID = record.find((a: any)=>
      {
        if(a.email === this.loginData.value.email && a.password === this.loginData.value.password)
        {
          user=true;
          adminFlag=a.isApprover;
          return a.signUpID;
        }
      })
      if(user)
      {
        // alert("Login successful!!");
        this.loginData.reset();
        console.warn("ID is: ",objID.signUpID);
        console.warn("IsAppprover: ",adminFlag);

        if(adminFlag==1)
        {
          setTimeout(()=>
        {
          this.route.navigate(['admindash']);
        },2000);
        }
        else
        {
          setTimeout(()=>
        {
          this.route.navigate(['empdash',objID.email]);
        },2000);
        }
        
      }
      else
      {
        alert("User not found!!");
      }
    })

  }

}
