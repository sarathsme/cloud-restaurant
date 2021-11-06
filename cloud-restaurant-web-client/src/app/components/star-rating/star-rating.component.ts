import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-star-rating',
  templateUrl: './star-rating.component.html',
  styleUrls: ['./star-rating.component.css']
})
export class StarRatingComponent implements OnInit {

  @Input() rating: number;
  toLoop: any[];
  
  constructor() { }

  ngOnInit() {
    this.rating = Math.round(this.rating);
    this.toLoop = [...Array(this.rating)];
  }

}
