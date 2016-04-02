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
        private ICommand _addNewTaskAsyncCommand;
        private bool _canAddNewTask = true;
        private bool _canLoad = true;
        private ICommand _deleteTaskAsyncCommand;
        private int _getTaskId;
        private TaskInfo _gottenTask;
        private ICommand _loadAsyncCommand;
        private TaskInfo _newTask = new TaskInfo();
        private ICommand _saveTaskAsyncCommand;

        private readonly ITaskDataAccess _taskDataAccess =
            TaskDataAccessCreator.CreateFromSetting();

        private IEnumerable<TaskInfo> _tasks;
        private TaskInfo _taskSavingOrDeleting;
        #endregion


        #region  Properties & Indexers
        public ICommand AddNewTaskAsyncCommand
            => GetCommand(ref _addNewTaskAsyncCommand, async _ => await AddNewTaskAsync(), _ => CanAddNewTask);

        public bool CanAddNewTask
        {
            get { return _canAddNewTask; }
            private set { SetProperty(ref _canAddNewTask, value); }
        }

        public bool CanLoad
        {
            get { return _canLoad; }
            private set { SetProperty(ref _canLoad, value); }
        }

        public ICommand DeleteTaskAsyncCommand
            =>
                GetCommand(ref _deleteTaskAsyncCommand, async task => await DeleteTaskAsync(task as TaskInfo),
                    CanSaveOrDelete);

        public int GetTaskId
        {
            get { return _getTaskId; }
            set { SetProperty(ref _getTaskId, value); }
        }

        public TaskInfo GottenTask
        {
            get { return _gottenTask; }
            private set { SetProperty(ref _gottenTask, value); }
        }

        public ICommand LoadAsyncCommand
            => GetCommand(ref _loadAsyncCommand, async _ => await LoadAsync(), _ => CanLoad);

        public TaskInfo NewTask
        {
            get { return _newTask; }
            private set { SetProperty(ref _newTask, value); }
        }

        public ICommand SaveTaskAsyncCommand
            => GetCommand(ref _saveTaskAsyncCommand, async task => await SaveTaskAsync(task as TaskInfo));

        public IEnumerable<TaskInfo> Tasks
        {
            get { return _tasks; }
            set { SetProperty(ref _tasks, value); }
        }
        #endregion


        #region Methods
        public async Task AddNewTaskAsync()
        {
            SetEnabitity(false);
            await _taskDataAccess.AddTaskAsync(NewTask);
            await LoadAsync();
            NewTask = new TaskInfo();
            SetEnabitity(true);
        }

        public async Task DeleteTaskAsync(TaskInfo task)
        {
            if (task?.Id != null)
            {
                _taskSavingOrDeleting = task;
                await _taskDataAccess.DeleteTaskAsync(task.Id.Value);
                await LoadAsync();
                _taskSavingOrDeleting = null;
            }
        }

        public async Task GetTaskAsync()
        {
            SetEnabitity(false);
            GottenTask = await _taskDataAccess.GetTaskAsync(GetTaskId);
            SetEnabitity(true);
        }

        public async Task LoadAsync()
        {
            SetEnabitity(false);
            Tasks = await _taskDataAccess.GetAllTasksAsync();
            SetEnabitity(true);
        }

        public async Task SaveTaskAsync(TaskInfo task)
        {
            if (task?.Id != null)
            {
                _taskSavingOrDeleting = task;
                await _taskDataAccess.UpdateTaskAsync(task);
                _taskSavingOrDeleting = null;
            }
        }
        #endregion


        #region Implementation
        private bool CanSaveOrDelete(object taskObj)
        {
            var task = taskObj as TaskInfo;
            return task != null && task != _taskSavingOrDeleting;
        }

        private void SetEnabitity(bool value)
        {
            CanLoad = CanAddNewTask = value;
        }
        #endregion
    }
}