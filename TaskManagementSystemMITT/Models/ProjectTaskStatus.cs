using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskManagementSystemMITT.Models
{
    public class ProjectTaskStatus
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}