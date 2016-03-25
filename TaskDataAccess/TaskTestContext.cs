using System;
using System.Collections.Generic;
using System.Linq;
using TaskModels;


namespace TaskDataAccess
{
    public class TaskTestContext: ITaskDataAccess
    {
        #region Fields
        private static readonly List<TaskInfo> _tasks =
            new[]
            {
                new TaskInfo { Id = 1, Description = "Complete Project #1", Deadline = DateTime.Parse("03/31/2016") },
                new TaskInfo { Id = 2, Description = "Hangout with friends", Deadline = DateTime.Parse("04/01/2016") },
                new TaskInfo { Id = 3, Description = "Buy a Surface Pro", Deadline = DateTime.Parse("06/01/2016") }
            }.ToList();
        #endregion


        #region Methods
        public TaskInfo AddTask(TaskInfo task)
        {
            // ReSharper disable once PossibleInvalidOperationException
            var id = _tasks.Max(t => t.Id.Value) + 1;
            task.Id = id;
            _tasks.Add(task);
            return task;
        }

        public void DeleteTask(int id)
        {
            var task = GetTask(id);
            if (task != null) _tasks.Remove(task);
        }

        public IEnumerable<TaskInfo> GetAllTask()
        {
            return _tasks;
        }

        public TaskInfo GetTask(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public TaskInfo UpdateTask(TaskInfo task)
        {
            if (task.Id != null)
            {
                var t = GetTask(task.Id.Value);
                if (t != null)
                {
                    t.Description = task.Description;
                    t.Deadline = task.Deadline;
                    t.IsDone = task.IsDone;
                }
                return t;
            }
            return null;
        }
        #endregion
    }
}