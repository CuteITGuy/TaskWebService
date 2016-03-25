using System.Collections.Generic;
using TaskModels;


namespace TaskDataAccess
{
    public interface ITaskDataAccess
    {
        #region Abstract
        TaskInfo AddTask(TaskInfo task);
        void DeleteTask(int id);
        IEnumerable<TaskInfo> GetAllTask();
        TaskInfo GetTask(int id);
        TaskInfo UpdateTask(TaskInfo task);
        #endregion
    }
}