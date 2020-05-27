import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Cat } from '../models/Cat';
import { plainToClass } from 'class-transformer';

const API_URL = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class CatsService {
  constructor(private http: HttpClient) {
  }

  get() {
    return this.http.get(API_URL + '/cats');
  }

  post(id) {
    return this.http.post(API_URL + '/cats', id)
  }

}
