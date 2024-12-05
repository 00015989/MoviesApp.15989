import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movie } from '../app/movie.models'; // Make sure this matches the updated model

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  private apiUrl = 'https://localhost:7192/api/Movies'; // My backend API

  constructor(private http: HttpClient) {}

  // Get all movies
  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(this.apiUrl);
  }

  // Get a specific movie by ID
  getMovie(id: number): Observable<Movie> {
    return this.http.get<Movie>(`${this.apiUrl}/${id}`);
  }

  // Create a new movie
  createMovie(movie: Movie): Observable<Movie> {
    return this.http.post<Movie>(this.apiUrl, movie);
  }

  // Update an existing movie
  updateMovie(id: number, movie: Movie): Observable<Movie> {
    return this.http.put<Movie>(`${this.apiUrl}/${id}`, movie);
  }

  // Delete a movie
  deleteMovie(movieID: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${movieID}`);
  }
}
