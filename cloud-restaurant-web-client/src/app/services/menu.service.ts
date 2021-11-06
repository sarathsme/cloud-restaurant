import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import Menu from '../models/menu/menu';


@Injectable({
  providedIn: 'root'
})
export class MenuService {

  constructor(private httpClient: HttpClient ) { }

  public GetAllMenus(): Observable<Menu[]> {
    return this.httpClient.get<Menu[]>(`${environment.apiRootUrl}/v1/menu`);
  }
}
