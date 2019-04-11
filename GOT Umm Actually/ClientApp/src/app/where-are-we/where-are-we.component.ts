import { Component } from '@angular/core';

@Component({
  selector: 'app-where-are-we-component',
  templateUrl: './where-are-we.component.html'
})
export class WhereAreWeComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
