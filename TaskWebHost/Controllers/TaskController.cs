using System.Collections.Generic;
using System.Web.Http;
using TaskDataAccess;
using TaskModels;


namespace TaskWebHost.Controllers
{
    public class TaskController: ApiController
    {
        #region Fields
        private readonly ITaskDataAccess _taskDataAccess = new TaskEntityDataAccess();
        #endregion


        #region Methods
        [HttpPost]
        public TaskInfo AddTask(TaskInfo task)
        {
            return _taskDataAccess.AddTask(task);
        }

        [HttpDelete]
        public void DeleteTask(int id)
        {
            _taskDataAccess.DeleteTask(id);
        }

        [HttpGet]
        public TaskInfo GetTask(int id)
        {
            return _taskDataAccess.GetTask(id);
        }

        [HttpGet]
        public IEnumerable<TaskInfo> GetTasks()
        {
            return _taskDataAccess.GetAllTask();
        }

        [HttpPut]
        public TaskInfo UpdateTask(TaskInfo task)
        {
            return _taskDataAccess.UpdateTask(task);
        }
        #endregion
    }
}