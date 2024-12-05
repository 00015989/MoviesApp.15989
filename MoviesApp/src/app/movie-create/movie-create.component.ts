import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-movie-create',
  templateUrl: './movie-create.component.html',
  styleUrls: ['./movie-create.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule],
})
export class MovieCreateComponent {
  movie = {
    title: '',
    genre: '',
    releaseDate: '',
    director: '',
    rating: '',
    description: '',
  };

  createMovie() {
    console.log('Movie Created:', this.movie);
  }
}
