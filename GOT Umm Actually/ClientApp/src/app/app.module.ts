import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { WhereAreWeComponent } from './where-are-we/where-are-we.component';
import { WhenDidTheyDieComponent } from './when-did-they-die/when-did-they-die.component';
import { CharacterListComponent } from './when-did-they-die/character-list-component';

import { MatButtonModule } from '@angular/material';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTabsModule } from '@angular/material/tabs';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    WhereAreWeComponent,
    WhenDidTheyDieComponent,
    CharacterListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MatButtonModule,
    DragDropModule,
    MatCardModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatTabsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'where-are-we', component: WhereAreWeComponent },
      { path: 'when-did-they-die', component: WhenDidTheyDieComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
