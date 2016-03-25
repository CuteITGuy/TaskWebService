using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public IEnumerable<TaskInfo> GetAllTask()
        {
            return _context.Tasks.AsEnumerable();
        }

        public TaskInfo GetTask(int id)
        {
            return _context.Tasks.Find(id);
        }

        public TaskInfo UpdateTask(TaskInfo task)
        {
            var t = _context.Tasks.Find(task.Id);
            if (t != null)
            {
                t.Description = task.Description;
                t.Deadline = task.Deadline;
                t.IsDone = task.IsDone;
            }
            _context.SaveChanges();
            return t;
        }
        #endregion


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}