import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from 'src/environments/environment';
import { Menu } from '../interfaces/menu';
import { Role } from '../interfaces/role';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  private apiUrl:string = Environment.endpoint + 'Menues';

  constructor(private http: HttpClient) { }

  getMenues(): Observable<Menu[]> {
    return this.http.get<Menu[]>(`${this.apiUrl}`);
  }

  getRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(`${this.apiUrl}/Roles`);
  }

  getMenuesForRole(id: string): Observable<Menu[]> {
    return this.http.get<Menu[]>(`${this.apiUrl}/Roles/${id}`);
  }
}
