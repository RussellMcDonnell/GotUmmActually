import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-when-did-they-die-component',
  templateUrl: './when-did-they-die.component.html'
})
export class WhenDidTheyDieComponent {
  public characters: Character[];
  public season1Characters: Character[];
  public season2Characters: Character[];
  public season3Characters: Character[];
  public season4Characters: Character[];
  public season5Characters: Character[];
  public season6Characters: Character[];
  public season7Characters: Character[];

  public gameResult: GameResult;
  private difficulty: number;
  private gameState: GameState;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.difficulty = 1;
    this.gameState = GameState.begining;
    this.season1Characters = [];
    this.season2Characters = [];
    this.season3Characters = [];
    this.season4Characters = [];
    this.season5Characters = [];
    this.season6Characters = [];
    this.season7Characters = [];
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.characters, event.previousIndex, event.currentIndex);
  }
  drop1(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.season1Characters, event.previousIndex, event.currentIndex);
  }
  drop2(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.season2Characters, event.previousIndex, event.currentIndex);
  }
  drop3(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.season3Characters, event.previousIndex, event.currentIndex);
  }

  public startGame(selectedDifficulty: number) {
    this.difficulty = selectedDifficulty;
    this.gameState = GameState.started;
    this.http.get<Character[]>('api/Characters/GetDeadCharactersShuffled/' + selectedDifficulty).subscribe(result => {
      if (this.difficulty > 1) {
        for (let character of result) {
          if (character.season === 1) {
            this.season1Characters.push(character);
          } else if (character.season === 2) {
            this.season2Characters.push(character);
          }else if (character.season === 3) {
            this.season3Characters.push(character);
          }else if (character.season === 4) {
            this.season4Characters.push(character);
          }else if (character.season === 5) {
            this.season5Characters.push(character);
          }else if (character.season === 6) {
            this.season6Characters.push(character);
          }else if (character.season === 7) {
            this.season7Characters.push(character);
          }
        }
      } else {
        this.characters = result;
      }
    }, error => console.error(error));
  }

  public endGame() {
    if (this.difficulty > 1) {
      this.characters = this.season1Characters.concat(this.season2Characters,this.season3Characters,this.season4Characters,this.season5Characters,this.season6Characters,this.season7Characters);
    }

    this.http.post<GameResult>('api/Characters/CheckAnswers/' + this.difficulty, this.characters).subscribe(result => {
      this.gameResult = result;
      this.gameState = GameState.gameOver;
    }, error => console.error(error));
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

interface GameResult {
  score: number;
  correctCharacterOrder: Character[];
}


enum GameState {
  begining = 0,
  started = 1,
  gameOver = 2
}
