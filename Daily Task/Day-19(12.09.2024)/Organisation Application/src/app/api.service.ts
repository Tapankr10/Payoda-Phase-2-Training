import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from './company';

@Injectable({
  providedIn: 'root'
})
export class APIService {

  private apiurl ="https://localhost:7004/api/Company"
  constructor(private http:HttpClient) { }
  get():Observable<any>
  {
    return this.http.get(this.apiurl)
  }
  getById(id:number):Observable<any>{
    return this.http.get(`${this.apiurl}/ ${id}`);

    
  }
  post(company: Company, p: { responseType: string; }):Observable<any>
  {
    return this.http.post(this.apiurl, company)
  }
  
  update(id: number, company: Company): Observable<Company> {
    return this.http.put<Company>(`${this.apiurl}/${id}`, company);
  }
  
}
