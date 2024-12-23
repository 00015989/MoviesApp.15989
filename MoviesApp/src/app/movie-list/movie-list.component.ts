import { Component, OnInit } from '@angular/core';
import { MovieService } from '../movie.service';
import { Movie } from '../movie.models';
import { CommonModule } from '@angular/common';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css'],
  imports: [CommonModule],
  providers: [DatePipe],
})
export class MovieListComponent implements OnInit {
  movies: Movie[] = [];

  constructor(private movieService: MovieService, private datePipe: DatePipe) {}

  ngOnInit(): void {
    this.movieService.getMovies().subscribe({
      next: (data) => {
        this.movies = data;
      },
      error: (err) => {
        console.error('Error fetching movies:', err);
      },
    });
  }

  deleteMovie(movieID: number): void {
    if (!movieID) {
      console.error('Invalid movie ID:', movieID);
      return;
    }

    this.movieService.deleteMovie(movieID).subscribe({
      next: () => {
        this.movies = this.movies.filter((movie) => movie.movieID !== movieID);
        console.log(`Movie with ID ${movieID} deleted successfully.`);
      },
      error: (err) => {
        console.error('Error deleting movie:', err);
      },
    });
  }
}
