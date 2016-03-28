using System;
using System.Configuration;


namespace TaskDataAccess
{
    public class TaskDataAccessCreator
    {
        #region Methods
        public static ITaskDataAccess CreateFromSetting()
        {
            var taskDataAccessAsyncSetting = GetTaskDataAccess();
            switch (taskDataAccessAsyncSetting.ToLower())
            {
                case "test":
                    return new TaskTestDataAccess();
                case "entity":
                    return new TaskEntityDataAccess();
                case "client":
                    return new TaskClientDataAccess();
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion


        #region Implementation
        private static string GetTaskDataAccess() => ConfigurationManager.AppSettings["taskDataAccess"];
        #endregion
    }
}