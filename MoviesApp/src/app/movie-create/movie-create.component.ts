import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MovieService } from '../movie.service';
import { Movie } from '../movie.models';

@Component({
  selector: 'app-movie-create',
  templateUrl: './movie-create.component.html',
  styleUrls: ['./movie-create.component.css'],
})
export class MovieCreateComponent {
  newMovie: Movie = { title: '', description: '', releaseDate: '', rating: 0 };

  constructor(private movieService: MovieService, private router: Router) {}

  createMovie(): void {
    this.movieService.createMovie(this.newMovie).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
