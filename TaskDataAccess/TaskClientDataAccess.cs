using System;
using System.Configuration;
using System.Threading.Tasks;
using CB.Web.WebServices;
using TaskModels;


namespace TaskDataAccess
{
    public class TaskClientDataAccess: ITaskDataAccess
    {
        #region Fields
        private readonly string _sourceUrl = GetSourceUrlSetting();
        #endregion


        #region Methods
        public TaskInfo AddTask(TaskInfo task)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskInfo> AddTaskAsync(TaskInfo task)
        {
            return await Http.PostAsync<TaskInfo, TaskInfo>(_sourceUrl, task);
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTaskAsync(int id)
        {
            await Http.DeleteAsync<object>(_sourceUrl, id);
        }

        public TaskInfo[] GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public async Task<TaskInfo[]> GetAllTasksAsync()
        {
            return await Http.GetAsync<TaskInfo[]>(_sourceUrl);
        }

        public TaskInfo GetTask(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskInfo> GetTaskAsync(int id)
        {
            return await Http.GetAsync<TaskInfo>(_sourceUrl, id);
        }

        public TaskInfo UpdateTask(TaskInfo task)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskInfo> UpdateTaskAsync(TaskInfo task)
        {
            return await Http.PutAsync<TaskInfo, TaskInfo>(_sourceUrl, task);
        }
        #endregion


        #region Implementation
        private static string GetSourceUrlSetting()
        {
            return ConfigurationManager.AppSettings["sourceUrl"];
        }
        #endregion
    }
}