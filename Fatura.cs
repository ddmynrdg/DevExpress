using BusErac;
using EntErac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERacReis.Sozlesme
{
    public partial class FaturaAl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string KiralamaNo = QSifreleCoz.Decrypt(HttpUtility.UrlDecode(Convert.ToString(Request.QueryString["KNo"])));

            if (KiralamaNo != null)
            {
                string[] KNoList = KiralamaNo.Split(',');

                for (int i = 0; i < KNoList.Length - 1; i++)
                {
                    string KiraNo = KNoList[i].ToString().Trim();
                    try
                    {
                        if (KiraNo != null)
                        {
                            XtraFaturaAl FaturaAl = new XtraFaturaAl();
                            DevExpress.XtraReports.Parameters.Parameter ParamKiraNo = new DevExpress.XtraReports.Parameters.Parameter();
                            ParamKiraNo.Name = "KiralamaNo";
                            ParamKiraNo.Value = KiralamaNo;
                            ParamKiraNo.Type = typeof(System.String);
                            ParamKiraNo.Visible = false;

                            DevExpress.XtraReports.Parameters.Parameter ParamSeriNo = new DevExpress.XtraReports.Parameters.Parameter();
                            ParamSeriNo.Name = "FaturaSeriNo";
                            ParamSeriNo.Value = "";
                            ParamSeriNo.Type = typeof(System.String);
                            ParamSeriNo.Visible = true;

                            FaturaAl.Parameters.Add(ParamKiraNo);
                            FaturaAl.Parameters.Add(ParamSeriNo);
                            FaturaGoster.Report = FaturaAl;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                } 
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }
    }
}
