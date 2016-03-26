using System.Collections.Generic;
using System.Threading.Tasks;
using CB.Model.Common;
using TaskDataAccess;
using TaskModels;


namespace TaskViewModels
{
    public class TaskWindowClientViewModel: ViewModelBase
    {
        #region Fields
        private readonly ITaskDataAccess _taskDataAccess = new TaskEntityDataAccess();
        private IEnumerable<TaskInfo> _tasks;
        #endregion


        #region  Properties & Indexers
        public IEnumerable<TaskInfo> Tasks
        {
            get { return _tasks; }
            set { SetProperty(ref _tasks, value); }
        }
        #endregion


        #region Methods
        public async Task LoadAsync()
        {
            Tasks = await _taskDataAccess.GetAllTasksAsync();
        }
        #endregion
    }
}