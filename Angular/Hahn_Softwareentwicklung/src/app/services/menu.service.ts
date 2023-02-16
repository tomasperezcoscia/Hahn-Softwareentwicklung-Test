import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from 'src/environments/environment';
import { ResponseApi } from '../interfaces/response-api';
import { Menu } from '../interfaces/menu';
import { Role } from '../interfaces/role';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  private apiUrl:string = Environment.endpoint + 'menues';

  constructor(private http: HttpClient) { }

  getMenues(): Observable<Menu[]> {
    return this.http.get<Menu[]>(`${Environment.endpoint}`);
  }

  getRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(`${Environment.endpoint}`);
  }

  getMenuesForRole(id: string): Observable<Menu[]> {
    return this.http.get<Menu[]>(`${Environment.endpoint}/${id}`);
  }
}
