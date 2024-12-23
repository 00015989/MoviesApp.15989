import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieUpdateComponent } from './movie-update.component';

describe('MovieUpdateComponent', () => {
  let component: MovieUpdateComponent;
  let fixture: ComponentFixture<MovieUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MovieUpdateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovieUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
