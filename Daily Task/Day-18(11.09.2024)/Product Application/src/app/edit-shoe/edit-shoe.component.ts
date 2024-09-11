import { Component,  Input } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { DetailComponent } from '../detail/detail.component'; 
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-edit-shoe',
  standalone: true,
  imports: [DetailComponent,FormsModule,CommonModule],
  templateUrl: './edit-shoe.component.html',
  styleUrl: './edit-shoe.component.css'
})
export class EditShoeComponent {
}