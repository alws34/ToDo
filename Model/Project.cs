using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    public class Project
    {
        int projectID;
        string projectName;
        DateTime dateCreated;
        List<ProjectTask> tasks;

        public int ProjectID { get => projectID; set => projectID = value; }
        public string ProjectName { get => projectName; set => projectName = value; }
        public DateTime DateCreated { get => dateCreated; }
        public List<ProjectTask> Tasks { get => tasks; set => tasks = value; }

        public Project(int projectID, string projectName)
        {
            ProjectID = projectID;
            ProjectName = projectName;
            dateCreated = DateTime.Now;
        }
        public Project( string projectName)
        {
            ProjectName = projectName;
            dateCreated = DateTime.Now;
        }

        public void AddTask(string taskName) {
            ProjectTask task = new ProjectTask(taskName);
            Tasks.Add(task);

        }

    }
}
