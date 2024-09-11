import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DetailComponent } from './detail/detail.component';
import { AddShoeComponent } from "./add-shoe/add-shoe.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DetailComponent, AddShoeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'StudentsApp';
}
