using System.ComponentModel.DataAnnotations;

namespace TaskManager.Data.Entities
{
	public class MyTask : EntityBase
	{

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = null!;

        public DateTime Date { get; set; }

        public bool IsCompleted { get; set; }
    }
}

