using DoYourTasks.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    public class viewsController
    {
        //id,view
        public Dictionary<string, ProjectView> Projectviews;
        public Dictionary<string, TaskView> Taskviews;
        public Dictionary<string, SubTaskView> SubTaskviews;
        Utils utils;

        public viewsController()
        {
            Projectviews = new Dictionary<string, ProjectView>();
            Taskviews = new Dictionary<string, TaskView>();
            SubTaskviews = new Dictionary<string, SubTaskView>();
            utils = new Utils();
        }

        #region ProjectViews

        #region ProjectViewsSetters
        public ProjectView CreateNewProjectView(string projectID)
        {
            ProjectView pv = new ProjectView(projectID);
            Projectviews.Add(projectID, pv);
            return pv;
        }

        #endregion

        #region ProjectViewsGetters
        #endregion

        #region ProjectViewsModifiers
        #endregion

        #endregion

        #region Taskviews

        #region TaskviewsSetters
        #endregion
        #region TaskviewsGetters
        #endregion
        #region TaskviewsModifiers
        #endregion

        #endregion

        #region SubTaskView

        #region SubTaskViewSetters
        #endregion
        #region SubTaskViewGetters
        #endregion
        #region SubTaskViewModifiers
        #endregion

        #endregion


    }
}
