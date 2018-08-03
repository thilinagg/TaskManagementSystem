using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    public class Tasks
    {
        public int id { get; set; }
        public string taskDetails { get; set; }
        public string taskAssignedDate { get; set; }
        public string taskEndDate { get; set; }
        public int responsibleUserId { get; set; }
        public string responsibleUser { get; set; }
        public string teamName { get; set; }
        public int status { get; set; }
    }
}
