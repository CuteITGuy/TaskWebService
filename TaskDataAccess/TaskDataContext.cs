using System.Data.Entity;
using TaskModels;


namespace TaskDataAccess
{
    public class TaskDataContext: DbContext
    {
        #region  Constructors & Destructor
        public TaskDataContext(): base("taskDataContext") { }
        #endregion


        #region  Properties & Indexers
        public DbSet<TaskInfo> Tasks { get; set; }
        #endregion


        #region Override
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TaskInfoMap());
        }
        #endregion
    }
}