using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskManagementSystemMITT.Models
{
    public class ProjectTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string Content { get; set; }

        public TimeSpan Duration { get; set; }

        public virtual Project Project { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ProjectTaskStatus Status { get; set; }
    }
}
