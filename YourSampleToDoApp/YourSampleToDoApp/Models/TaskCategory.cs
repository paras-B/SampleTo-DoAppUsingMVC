using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourSampleToDoApp.Models
{
    public class TaskCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TaskName { get; set; }
        [Required]
        [DisplayName("Task Status")]
        public string TaskStatus { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public DateTime CompletedDateTime { get; set; }
    }
}
