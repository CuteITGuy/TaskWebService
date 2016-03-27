/// <reference path="jquery-2.2.1.js" />
/// <reference path="http.jquery.js" />
/// <reference path="knockout-3.4.0.debug.js" />
var setDefaultNewTask = function(task) {
    task.description("New Task");
    task.deadline(new Date().toJSON());
    task.isDone(false);
};

var model = {
    url: "http://localhost:4975/api/task",
    tasks: ko.observableArray([]),
    newTask: {
        description: ko.observable(""),
        deadline: ko.observable(""),
        isDone: ko.observable(false)
    },
    view: ko.observable("")
};

var viewLoadTasks = function() {
    model.view("loadTasks");
};

var viewAddNewTask = function() {
    model.view("addNewTask");
};

var httpError = function(jqXhr, textStatus, errorThrown) {
    alert(textStatus + ": " + errorThrown);
};

var loadTasks = function() {
    $http.get(model.url, null,
        function(data) {
            model.tasks.removeAll();
            for (var i = 0; i < data.length; i++) {
                model.tasks.push(data[i]);
            }
            viewLoadTasks();
        },
        httpError);
};

var addNewTask = function() {
    $http.post(model.url, model.newTask,
        function() {
            loadTasks();
            setDefaultNewTask(model.newTask);
        },
        httpError);
};

var saveTask = function(task) {
    $http.put(model.url, task,
        function() {
            loadTasks();
        },
        httpError);
};

var deleteTask = function (task) {
    if (!window.confirm("Are you sure you want to delete the task '" + task.Description + "'?")) return;

    $http.delete(model.url, task.Id,
        function() {
            loadTasks();
        },
        httpError);
};

$(function() {
    setDefaultNewTask(model.newTask);
    ko.applyBindings();
    loadTasks();
});