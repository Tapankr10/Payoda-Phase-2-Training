import { CommonModule } from '@angular/common';
import { Comment } from '@angular/compiler';
import { Component } from '@angular/core';


@Component({
  selector: 'app-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './detail.component.html',
  styleUrl: './detail.component.css'
})
export class DetailComponent {
shoeDetail : Detail[] = [
  {
    ShoeId: 1,
    ShoeName: 'Football Shoes',
    ShoePrice: 120,
    ShoeBrand: 'Nike',
    ShoeProfile: 'football.jpg',
    ShoeStock:6
  },
  {
    ShoeId: 2,
    ShoeName: 'Spikes Shoes',
    ShoePrice: 180,
    ShoeBrand: 'Adidas',
    ShoeProfile: 'gu.png',
    ShoeStock:3
    
  },
  {
    ShoeId: 3,
    ShoeName: 'Jogging Shoes',
    ShoePrice: 900,
    ShoeBrand: 'Reebok',
    ShoeProfile: 'don.jfif',
    ShoeStock:1
  },
  {
    ShoeId: 4,
    ShoeName: 'Trekking Shoes',
    ShoePrice: 6000,
    ShoeBrand: 'Converse',
    ShoeProfile: 'spike.jfif',
    ShoeStock:3
  },
  {
    ShoeId: 5,
    ShoeName: 'Casual',
    ShoePrice: 130,
    ShoeBrand: 'Nike',
    ShoeProfile: 'p.jfif',
    ShoeStock:2
  }
]
addToCart(shoeName: string | undefined) {
  const name = shoeName ?? 'Unknown Shoe'; 
  alert(`${name} has been added to your cart!`);
}
message: string = '';


  onBuyNow() {
    alert('Thank you for your purchase!');
  }

}

class Detail
{
  ShoeId?:number
  ShoeName?:string
  ShoePrice?: Number
  ShoeBrand?:string
  ShoeProfile?:string
  ShoeStock:number =0
}
