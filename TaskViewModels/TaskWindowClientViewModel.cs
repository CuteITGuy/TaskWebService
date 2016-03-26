using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CB.Model.Common;
using TaskDataAccess;
using TaskModels;


namespace TaskViewModels
{
    public class TaskWindowClientViewModel: ViewModelBase
    {
        #region Fields
        private bool _canLoad;

        private ICommand _loadAsyncCommand;
        private readonly ITaskDataAccess _taskDataAccess = new TaskEntityDataAccess();
        private IEnumerable<TaskInfo> _tasks;
        #endregion


        #region  Properties & Indexers
        public bool CanLoad
        {
            get { return _canLoad; }
            private set { SetProperty(ref _canLoad, value); }
        }

        public ICommand LoadAsyncCommand
            => GetCommand(ref _loadAsyncCommand, async _ => await LoadAsync(), _ => CanLoad);

        public IEnumerable<TaskInfo> Tasks
        {
            get { return _tasks; }
            set { SetProperty(ref _tasks, value); }
        }
        #endregion


        #region Methods
        public async Task LoadAsync()
        {
            CanLoad = false;
            Tasks = await _taskDataAccess.GetAllTasksAsync();
            CanLoad = true;
        }
        #endregion
    }
}