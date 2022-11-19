import { Injectable } from '@angular/core';
import { MyTask } from '../models/my-task';
@Injectable({
  providedIn: 'root'
})
export class MyTaskService {
  constructor() { }
  public getTasks(): MyTask[] {
    let task = new MyTask();
    task.id = 1;
    task.body = "Task1";
    task.completed = true;
    task.archived = false;
    let task2 = new MyTask();
    task2.id = 2;
    task2.body = "Task2";
    task2.completed = false;
    task2.archived = false;
    let task3 = new MyTask();
    task3.id = 3;
    task3.body = "Task3";
    task3.completed = false;
    task3.archived = true;
    let res : MyTask[] = [];
    res.push(task)
    res.push(task2)
    res.push(task3)
    return res;
  }
}
