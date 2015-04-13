using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoBarriersWebApp.Models;

namespace NoBarriersWebApp
{
    public partial class TaskList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NoBarriersEntities db = new NoBarriersEntities();
            error_log log = new error_log();
            try
            {
                var query = from tsk in
                                db.tasks
                            select tsk;
                gvTasks.DataSource = query.ToList();
                gvTasks.DataBind();
            }
            catch (Exception ex)
            {

                log.error_date = DateTime.Now;
                log.error_desc = ex.Message;
                db.error_log.Add(log);
                db.SaveChanges();
            }
        }
    }
}