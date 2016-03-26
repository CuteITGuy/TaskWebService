using System.Threading.Tasks;
using TaskModels;


namespace TaskDataAccess
{
    public interface ITaskDataAccessAsync
    {
        #region Abstract
        Task<TaskInfo> AddTaskAsync(TaskInfo task);
        Task DeleteTaskAsync(int id);
        Task<TaskInfo[]> GetAllTasksAsync();
        Task<TaskInfo> GetTaskAsync(int id);
        Task<TaskInfo> UpdateTaskAsync(TaskInfo task);
        #endregion
    }
}