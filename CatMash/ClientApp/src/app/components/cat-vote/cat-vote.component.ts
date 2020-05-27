import { Component, OnInit } from '@angular/core';
import { CatsService } from 'src/app/services/cats.service';
import {plainToClass} from 'class-transformer';
import { Cat } from '../../models/Cat';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cat-vote',
  templateUrl: './cat-vote.component.html',
  styleUrls: ['./cat-vote.component.css']
})
export class CatVoteComponent implements OnInit {

  constructor(private catsService: CatsService,
              private router: Router) {
  }

  firstCat: Cat;
  secondCat: Cat;

  ngOnInit(): void {
    this.loadCats();
  }

  loadCats(): void {
    this.catsService.get().subscribe((data: Cat[]) => {
      let cats = plainToClass(Cat, data);
      this.SelectTwoCats(cats);
    }, error => {
      console.log('Error in load cats ! ');
    });
  }

  SelectTwoCats(cats: Cat[]) {
    let firstIndice = this.getRandomInt(cats.length);
    this.firstCat = cats[firstIndice];
    cats.splice(firstIndice, 1);
    let secondIndice = this.getRandomInt(cats.length);
    this.secondCat = cats[secondIndice];
  }

  getRandomInt(max): number {
    return Math.floor(Math.random() * Math.floor(max));
  }

  Vote(id) {
    this.catsService.post(id).subscribe(data => {
      console.log('Vote added ! ');
      this.router.navigateByUrl('/cats');
    });
  }
}
