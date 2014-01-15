using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AOE.WebUI
{
    public partial class EmployeeList : System.Web.UI.UserControl
    {
        [Category("Behavior")]
        [Browsable(true)]
        [UrlProperty("*.xml")]
        public string XmlConfigFile { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}