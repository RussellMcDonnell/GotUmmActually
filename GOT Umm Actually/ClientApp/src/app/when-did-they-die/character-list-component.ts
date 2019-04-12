import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

@Component({
  selector: 'character-list-component',
  templateUrl: './character-list-component.html'
})
export class CharacterListComponent {
  @Input() characters: Character[];
  @Input() showAdditionalInfo: boolean;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.characters, event.previousIndex, event.currentIndex);
  }
}

interface Character {
  order: number;
  name: string;
  season: number;
  episode: string;
  deathDescription: string;
  imageUrl: string;
}
