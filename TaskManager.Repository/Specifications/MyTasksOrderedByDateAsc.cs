using TaskManager.Data.Entities;

namespace TaskManager.Repository.Specifications
{
    public class MyTasksOrderedByDateAsc: BasicSpecification<MyTask>
    {
		public MyTasksOrderedByDateAsc() : base()
		{
			AddOrderBy(myTask => myTask.Date);
		}
	}
}

