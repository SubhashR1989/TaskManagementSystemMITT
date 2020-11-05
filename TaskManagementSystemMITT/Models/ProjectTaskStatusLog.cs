using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskManagementSystemMITT.Models
{
    public class ProjectTaskStatusLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public virtual ProjectTask ProjectTask { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ProjectTaskStatus Status { get; set; }

        public DateTime LogDate { get; set; }
    }
}
