
using TaskManager.Data.Entities;

namespace TaskManager.Repository.Specifications
{
	public class MyTaskById: BasicSpecification<MyTask>
	{
		public MyTaskById(int id) : base(myTask => myTask.Id == id)
		{
		}
	}
}

