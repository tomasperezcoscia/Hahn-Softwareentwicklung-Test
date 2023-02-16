import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from 'src/environments/environment';
import { ResponseApi } from '../interfaces/response-api';
import { Login } from '../interfaces/login';
import { Worker } from '../interfaces/worker';

@Injectable({
  providedIn: 'root'
})
export class WorkerService {

  private apiUrl:string = Environment.endpoint + 'workers';

  constructor(private http: HttpClient) { }

  login(login: Login): Observable<Login> {
    return this.http.post<Login>(`${this.apiUrl}/login`, login);
  }

  logout(): Observable<ResponseApi> {
    return this.http.post<ResponseApi>(`${this.apiUrl}/logout`, {});
  }

  getWorkers(): Observable<Worker[]> {
    return this.http.get<Worker[]>(this.apiUrl);
  }

  getWorker(id: string): Observable<Worker> {
    return this.http.get<Worker>(`${this.apiUrl}/${id}`);
  }

  addWorker(worker: Worker): Observable<Worker> {
    return this.http.post<Worker>(this.apiUrl, worker);
  }

  updateWorker(id: string, worker: Worker): Observable<Worker> {
    return this.http.put<Worker>(`${this.apiUrl}/${id}`, worker);
  }

  deleteWorker(id: string): Observable<Worker> {
    return this.http.delete<Worker>(`${this.apiUrl}/${id}`);
  }
}