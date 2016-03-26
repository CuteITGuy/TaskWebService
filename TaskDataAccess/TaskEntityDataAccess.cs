using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TaskModels;


namespace TaskDataAccess
{
    public class TaskEntityDataAccess: ITaskDataAccess, IDisposable
    {
        #region Fields
        private readonly TaskDataContext _context = new TaskDataContext();
        #endregion


        #region Methods
        public TaskInfo AddTask(TaskInfo task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public async Task<TaskInfo> AddTaskAsync(TaskInfo task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public TaskInfo[] GetAllTasks()
        {
            return _context.Tasks.ToArray();
        }

        public async Task<TaskInfo[]> GetAllTasksAsync()
        {
            return await _context.Tasks.ToArrayAsync();
        }

        public TaskInfo GetTask(int id)
        {
            return _context.Tasks.Find(id);
        }

        public async Task<TaskInfo> GetTaskAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public TaskInfo UpdateTask(TaskInfo task)
        {
            var t = _context.Tasks.Find(task.Id);
            t?.CopyFrom(task, false);
            _context.SaveChanges();
            return t;
        }

        public async Task<TaskInfo> UpdateTaskAsync(TaskInfo task)
        {
            var t = await _context.Tasks.FindAsync(task.Id);
            t?.CopyFrom(task, false);
            await _context.SaveChangesAsync();
            return t;
        }
        #endregion
    }
}