import { Component } from '@angular/core';

@Component({
  selector: 'app-where-are-we-component',
  templateUrl: './where-are-we.component.html'
})
export class WhereAreWeComponent {
  public currentCount = 0;
  public images = [1, 2, 3].map(() => `https://picsum.photos/900/500?random&t=${Math.random()}`);

  constructor() {
    this.images[2] = "https://cdn.images.express.co.uk/img/dynamic/galleries/x701/273075.jpg";
  }

  public incrementCounter() {
    this.currentCount++;
  }
}
