import { Component, Input, EventEmitter, Output, ChangeDetectionStrategy } from '@angular/core';
import { Cat } from '../../models/Cat';

@Component({
  selector: 'app-cat',
  templateUrl: './cat.component.html',
  styleUrls: ['./cat.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CatComponent {

  constructor() { }

  @Input() catData: Cat;

  @Input() activateVote: boolean;

  @Output() catLiked = new EventEmitter();

  ClickOnLike() {
    this.catLiked.emit(this.catData.id);
  }
}
