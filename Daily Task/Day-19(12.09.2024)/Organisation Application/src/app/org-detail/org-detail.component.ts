import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { APIService } from '../api.service';
import { Company } from '../company';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-org-detail',
  standalone: true,
  imports: [CommonModule ],
  templateUrl: './org-detail.component.html',
  styleUrl: './org-detail.component.css'
})
export class OrgDetailComponent {
  company:  Company | undefined;
  constructor(private api:APIService, private route: ActivatedRoute) {}

  ngOnInit():void{
    const id = +this.route.snapshot.params['id'];
    this.api.getById(id).subscribe((data) => { this.company =  data;
      console.log(this.company)
     });

  }
}
