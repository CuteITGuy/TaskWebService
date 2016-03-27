using System;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using CB.Web.WebServices;
using TaskModels;


namespace TaskDataAccess
{
    public class TaskClientDataAccess: ITaskDataAccessAsync
    {
        #region Fields
        private readonly string _sourceUrl = GetSourceUrlSetting();
        #endregion


        #region Methods
        public async Task<TaskInfo> AddTaskAsync(TaskInfo task)
        {
            return await Http.PostAsync<TaskInfo, TaskInfo>(_sourceUrl, task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await Http.DeleteAsync<object>(_sourceUrl, id);
        }

        public async Task<TaskInfo[]> GetAllTasksAsync()
        {
            return await Http.GetAsync<TaskInfo[]>(_sourceUrl);
        }

        public async Task<TaskInfo> GetTaskAsync(int id)
        {
            return await Http.GetAsync<TaskInfo>(_sourceUrl, id);
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