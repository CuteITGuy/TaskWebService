using System.Collections.Generic;
using System.Threading.Tasks;
using TaskModels;


namespace TaskDataAccess
{
    public interface ITaskDataAccess
    {
        #region Abstract
        TaskInfo AddTask(TaskInfo task);
        Task<TaskInfo> AddTaskAsync(TaskInfo task);
        void DeleteTask(int id);
        Task DeleteTaskAsync(int id);
        IEnumerable<TaskInfo> GetAllTasks();
        Task<IEnumerable<TaskInfo>> GetAllTasksAsync();
        TaskInfo GetTask(int id);
        Task<TaskInfo> GetTaskAsync(int id);
        TaskInfo UpdateTask(TaskInfo task);
        Task<TaskInfo> UpdateTaskAsync(TaskInfo task);
        #endregion
    }
}