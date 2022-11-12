import { Injectable } from '@angular/core';
import { ReimbursementData } from '../models/reimbursement-data.model'
import { Signup } from '../models/signup.model';
import {HttpClient} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class ReimbursementService {

  constructor(private http:HttpClient) { }

  signupData:Signup = new Signup();
  reimbursementData:ReimbursementData = new ReimbursementData();
  readonly baseSignupURL='http://localhost:10253/api/Signup';
  readonly baseReimbursementDataURL= 'http://localhost:10253/api/ReimbursementData';
  postSignup()
  {
    return this.http.post(this.baseSignupURL,this.signupData)
  }
  postReimbursementData()
  {
    return this.http.post(this.baseReimbursementDataURL,this.reimbursementData)
  }
  getSignup()
  {
    return this.http.get(this.baseSignupURL);
  }
  getReimbursement()
  {
    return this.http.get(this.baseReimbursementDataURL);
  }
  getReimbursementData(id: any)
  {
    return this.http.get(`${this.baseReimbursementDataURL}/${id}`);
  }
  updateReimbursement(id: any,data: any)
  {
    return this.http.put(`${this.baseReimbursementDataURL}/${id}`,data)
  }
  deleteReimbursement(id: any)
  {
    return this.http.delete(`${this.baseReimbursementDataURL}/${id}`);
  }
}
