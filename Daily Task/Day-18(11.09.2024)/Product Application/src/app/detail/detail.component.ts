import { CommonModule } from '@angular/common';
import { Comment } from '@angular/compiler';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AddShoeComponent } from '../add-shoe/add-shoe.component';

@Component({
  selector: 'app-detail',
  standalone: true,
  imports: [CommonModule,FormsModule,AddShoeComponent],
  templateUrl: './detail.component.html',
  styleUrl: './detail.component.css'
})
export class DetailComponent {
  selectedBrand: string = 'All';  // Default selection for brand


  addShoe(newShoe: Detail) {
    this.shoeDetail.push(newShoe);
  }

  shoeDetail: Detail[] = [
    { ShoeId: 1, ShoeName: 'Football Shoes', ShoePrice: 120, ShoeBrand: 'Nike', ShoeProfile: 'football.jpg', ShoeStock: 6 },
    { ShoeId: 2, ShoeName: 'Spikes Shoes', ShoePrice: 180, ShoeBrand: 'Adidas', ShoeProfile: 'gu.png', ShoeStock: 3 },
    { ShoeId: 3, ShoeName: 'Jogging Shoes', ShoePrice: 900, ShoeBrand: 'Reebok', ShoeProfile: 'don.jfif', ShoeStock: 0 },
    { ShoeId: 4, ShoeName: 'Trekking Shoes', ShoePrice: 6000, ShoeBrand: 'Converse', ShoeProfile: 'spike.jfif', ShoeStock: 3 },
    { ShoeId: 5, ShoeName: 'Casual', ShoePrice: 130, ShoeBrand: 'Nike', ShoeProfile: 'p.jfif', ShoeStock: 2 }
  ];
 
  // Get unique brands from shoeDetail array
  getUniqueBrands(): string[] {
    const brands = this.shoeDetail
      .map(shoes => shoes.ShoeBrand)
      .filter((brand): brand is string => brand !== undefined); // Filter out undefined brands
    return Array.from(new Set(brands));
  }
  
  
  getFilteredShoes(): Detail[] {
    if (this.selectedBrand === 'All') {
      return this.shoeDetail;
    }
    return this.shoeDetail.filter(shoes => shoes.ShoeBrand === this.selectedBrand);
  }

 
  onBuyNow() {
    alert('Thank you for your purchase!');
  }
  cart: any[] = [];


  addToCart(shoe: any) {
  
    const shoeInCart = this.cart.find(item => item.ShoeId === shoe.ShoeId);
    
    if (!shoeInCart) {
      this.cart.push({ ...shoe });
      alert(`${shoe.ShoeName} has been added to your cart!`);
    } else {
      alert(`${shoe.ShoeName} is already in the cart!`);
    }
  }


  removeFromCart(shoeId: number) {
    this.cart = this.cart.filter(shoe => shoe.ShoeId !== shoeId);
  }

 
 
}

class Detail
{
  ShoeId?:number
  ShoeName?:string
  ShoePrice?: number
  ShoeBrand?:string
  ShoeProfile?:string
  ShoeStock:number =0
}
