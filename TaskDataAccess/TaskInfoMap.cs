using System.Data.Entity.ModelConfiguration;
using TaskModels;


namespace TaskDataAccess
{
    public class TaskInfoMap: EntityTypeConfiguration<TaskInfo>
    {
        public TaskInfoMap()
        {
            ToTable("TaskInfo");
            Property(t => t.Id).HasColumnOrder(100);
            Property(t => t.Description).HasColumnOrder(120).HasMaxLength(2048).IsRequired();
            Property(t => t.Deadline).HasColumnOrder(140);
            Property(t => t.IsDone).HasColumnOrder(160);
        }
    }
}