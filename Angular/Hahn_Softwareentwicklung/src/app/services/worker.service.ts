import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WorkerModel } from '../models/worker.model';
import { Environment } from 'src/environments/environment';
import { ResponseApi } from '../interfaces/response-api';
import { Login } from '../interfaces/login';
import { Workers } from '../interfaces/worker';

@Injectable({
  providedIn: 'root'
})
export class WorkerService {

  private apiUrl = 'http://localhost:7129/api/workers';

  constructor(private http: HttpClient) { }

  getWorkers(): Observable<WorkerModel[]> {
    return this.http.get<WorkerModel[]>(this.apiUrl);
  }

  getWorker(id: string): Observable<WorkerModel> {
    return this.http.get<WorkerModel>(`${this.apiUrl}/${id}`);
  }

  addWorker(worker: WorkerModel): Observable<WorkerModel> {
    return this.http.post<WorkerModel>(this.apiUrl, worker);
  }

  updateWorker(id: string, worker: WorkerModel): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, worker);
  }

  deleteWorker(id: string): Observable<WorkerModel> {
    return this.http.delete<WorkerModel>(`${this.apiUrl}/${id}`);
  }
}