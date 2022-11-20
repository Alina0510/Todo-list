import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MyTask } from '../models/my-task';

@Injectable()
export class MyTaskService {
  private baseUrl = "";
  private controller = "tasks";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    }
  public getTasks(){
    return this.http.get<MyTask[]>(this.baseUrl + this.controller);
  }
  public createTask(task: MyTask) {
    return this.http.post(this.baseUrl + this.controller, task);
  }
  public updateTask(task: MyTask) {
    return this.http.put(this.baseUrl + this.controller, task);
  }
}
