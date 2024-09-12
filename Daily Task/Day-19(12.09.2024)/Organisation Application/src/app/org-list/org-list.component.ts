import { Component } from '@angular/core';
import { APIService } from '../api.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-org-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './org-list.component.html',
  styleUrl: './org-list.component.css'
})
export class OrgListComponent {
 data :any
 constructor(private apiser: APIService) 
 {

 }
 ngOnInit():void {
  this.apiser.get().subscribe((response)=> {
    this.data = response
  });
 }
}
