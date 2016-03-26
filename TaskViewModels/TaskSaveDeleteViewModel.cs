using System.Threading.Tasks;
using CB.Model.Common;
using CB.Web.WebServices;
using TaskDataAccess;
using TaskModels;


namespace TaskViewModels
{
    public class TaskSaveDeleteViewModel: ViewModelBase
    {
        private readonly ITaskDataAccessAsync _taskDataAccess = TaskDataAccessCreator.CreateFromSetting() as ITaskDataAccessAsync;
        private TaskInfo _task;

        public TaskInfo Task
        {
            get { return _task; }
            set { SetProperty(ref _task, value); }
        }

        public async Task SaveAsync()
        {
            await _taskDataAccess.UpdateTaskAsync(Task);
        }
    }
}