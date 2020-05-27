import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';
import { CatListComponent } from './components/cat-list/cat-list.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CatComponent } from './components/cat/cat.component';
import { CatVoteComponent } from './components/cat-vote/cat-vote.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { RouterModule } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    CatComponent,
    CatListComponent,
    NavMenuComponent,
    CatVoteComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    RouterModule.forRoot([
      { path: '', component: CatListComponent, pathMatch: 'full' },
      { path: 'cats', component: CatListComponent },
      { path: 'vots', component: CatVoteComponent },
    ])
  ],
  providers: [{ provide: APP_BASE_HREF, useValue: '/' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
