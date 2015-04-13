using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoBarriersWebApp.Models;

namespace NoBarriersWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NoBarriersEntities db = new NoBarriersEntities();
            error_log log = new error_log();
            try
            {                
                var query = from usr in
                                db.users
                            select usr;
                gvUsers.DataSource = query.ToList();
                gvUsers.DataBind();
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