import { Component } from '@angular/core';
import { MyTask } from './models/my-task';
import { MyTaskService } from './services/my-task.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [MyTaskService]
})
export class AppComponent {
  tasks: MyTask[] = [];
  task: MyTask = new MyTask();

  constructor( private myTaskService: MyTaskService) { }
  ngOnInit(): void {
    this.loadTasks();
  }
  loadTasks() {
    this.myTaskService.getTasks()
      .subscribe((data: MyTask[]) => this.tasks = data);
  }
  createTask() {
    this.myTaskService.createTask(this.task)
      .subscribe((data: MyTask) => this.tasks.push(data));
  }
  complete(task: MyTask) {
    this.myTaskService.updateTask(task)
      .subscribe(data => this.loadTasks());
  }
  archive(task: MyTask) {
    task.archived = true;
    this.myTaskService.updateTask(task)
      .subscribe(data => this.loadTasks());
  }
  
  save() {
    this.myTaskService.createTask(this.task)
      .subscribe((data: MyTask) => this.tasks.push(data));
    this.clear();
  }
  clear() {
    this.task = new MyTask();
  }
}
