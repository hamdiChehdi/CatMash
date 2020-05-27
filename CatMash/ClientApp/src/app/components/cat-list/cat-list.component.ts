import { Component, OnInit } from '@angular/core';
import { CatsService } from 'src/app/services/cats.service';
import {plainToClass} from 'class-transformer';
import { Cat } from '../../models/Cat';

@Component({
  selector: 'app-cat-list',
  templateUrl: './cat-list.component.html',
  styleUrls: ['./cat-list.component.css']
})
export class CatListComponent implements OnInit {

  constructor(private catsService: CatsService) {
  }

  cats: Cat[];

  ngOnInit(): void {
    this.loadCats();
  }

  loadCats(): void {
    this.catsService.get().subscribe((data: Cat[]) => {
      this.cats = plainToClass(Cat, data);
    }, error => {
      console.log('Error in load cats ! ');
    });
  }

}
