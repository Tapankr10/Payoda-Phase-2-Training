import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import {  EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-add-shoe',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './add-shoe.component.html',
  styleUrl: './add-shoe.component.css'
})
export class AddShoeComponent {
  @Output() shoeAdded = new EventEmitter<any>();

  successMessage: string = '';
  errorMessage: string = '';

  onSubmit(form: NgForm) {
    this.successMessage = '';
    this.errorMessage = '';

    if (form.valid) {
      const newShoe = {
        ShoeId: Math.floor(Math.random() * 1000),  // Generate a random ID (Consider using a proper ID generation method)
        ShoeName: form.value['shoeName'],
        ShoePrice: form.value['price'],
        ShoeBrand: form.value['brand'],
        ShoeProfile: form.value['profile'],
        ShoeStock: form.value['stock']
      };

      this.shoeAdded.emit(newShoe);  // Emit the new shoe object to the parent component

      this.successMessage = 'Product added successfully!';
      form.resetForm();  // Reset the form after successful submission
      setTimeout(() => {
        this.successMessage = '';
      }, 10000);
    } else {
      this.errorMessage = 'Please ensure all required fields are filled correctly.';
    }
  }
}