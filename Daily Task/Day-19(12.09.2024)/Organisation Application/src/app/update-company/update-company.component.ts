import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService } from '../api.service';
import { Company } from '../company';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-update-company',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,FormsModule],
  templateUrl: './update-company.component.html',
  styleUrl: './update-company.component.css'
})
export class UpdateCompanyComponent implements OnInit {

  company: Company = { id: 0, name: '' };

  constructor(
    private apiService: APIService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit():void{
    const id = +this.route.snapshot.params['id'];
    this.apiService.getById(id).subscribe(
      (response) => {
        this.company = response
      }
    )
  }

  onSubmit() : void{
    this.apiService.update(this.company.id,this.company).subscribe(
      (response)=>{
        console.log('Updated!',response);
        this.router.navigate(['/']);
      }
    )
 }
 
}
  
