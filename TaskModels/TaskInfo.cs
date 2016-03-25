using System;
using CB.Model.Common;


namespace TaskModels
{
    public class TaskInfo: ObservableObject
    {
        #region Fields
        private DateTime _deadline;
        private string _description;
        private int? _id;
        private bool _isDone;
        #endregion


        #region  Properties & Indexers
        public DateTime Deadline
        {
            get { return _deadline; }
            set { SetProperty(ref _deadline, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public int? Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public bool IsDone
        {
            get { return _isDone; }
            set { SetProperty(ref _isDone, value); }
        }
        #endregion
    }
}