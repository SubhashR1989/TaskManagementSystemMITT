using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystemMITT.Models
{
    public class ProjectHelper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProjectManagerId { get; set; }
        public ApplicationUser ProjectManager { get; set; }
        //public ICollection<Task> Tasks { get; set; }
        //public ProjectHelper()
        //{
        //    Tasks = new HashSet<Task>();
        //}
    }
}