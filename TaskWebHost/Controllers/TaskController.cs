using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TaskDataAccess;
using TaskModels;


namespace TaskWebHost.Controllers
{
    public class TaskController: ApiController
    {
        #region Fields
        private readonly ITaskDataAccess _taskDataAccess = TaskDataAccessCreator.CreateFromSetting();
        #endregion


        #region Methods

        [HttpPost]
        public async Task<TaskInfo> AddTaskAsync(TaskInfo task)
        {
            return await _taskDataAccess.AddTaskAsync(task);
        }

        [HttpDelete]
        public async Task DeleteTaskAsync(int id)
        {
            await _taskDataAccess.DeleteTaskAsync(id);
        }

        [HttpGet]
        public async Task<TaskInfo> GetTaskAsync(int id)
        {
            return await _taskDataAccess.GetTaskAsync(id);
        }

        [HttpGet]
        public async Task<TaskInfo[]> GetTasksAsync()
        {
            return await _taskDataAccess.GetAllTasksAsync();
        }

        [HttpPut]
        public async Task<TaskInfo> UpdateTaskAsync(TaskInfo task)
        {
            return await _taskDataAccess.UpdateTaskAsync(task);
        }
        #endregion
    }
}