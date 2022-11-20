"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.MyTaskService = void 0;
var MyTaskService = /** @class */ (function () {
    function MyTaskService(http) {
        this.http = http;
        this.baseUrl = "";
        this.urlGet = "/get";
        this.urlCreate = "/create";
        this.urlCompleate = "/complete";
        this.urlArchive = "/archive";
        this.baseUrl = document.getElementsByTagName('base')[0].href;
    }
    MyTaskService.prototype.getTasks = function () {
        return this.http.get(this.baseUrl + this.urlGet);
    };
    MyTaskService.prototype.createTask = function (task) {
        return this.http.post(this.urlCreate, task);
    };
    MyTaskService.prototype.compleateTask = function (task) {
        return this.http.put(this.urlCompleate, task);
    };
    MyTaskService.prototype.archiveTask = function (task) {
        return this.http.put(this.urlArchive, task);
    };
    return MyTaskService;
}());
exports.MyTaskService = MyTaskService;
//# sourceMappingURL=my-task.service.js.map