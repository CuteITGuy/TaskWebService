using TaskModels;


namespace TaskDataAccess
{
    public interface ITaskDataAccessSync
    {
        #region Abstract
        TaskInfo AddTask(TaskInfo task);
        void DeleteTask(int id);
        TaskInfo[] GetAllTasks();
        TaskInfo GetTask(int id);
        TaskInfo UpdateTask(TaskInfo task);
        #endregion
    }
}