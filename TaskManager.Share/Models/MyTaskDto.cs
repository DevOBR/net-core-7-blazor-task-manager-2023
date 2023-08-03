using System.ComponentModel.DataAnnotations;

namespace TaskManager.Share.Models
{
	public class MyTaskDto
	{
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = null!;

        public DateTime Date { get; set; }

        public bool IsCompleted { get; set; }
    }
}

