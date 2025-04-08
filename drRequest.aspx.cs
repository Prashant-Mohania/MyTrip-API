using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class drRequest : System.Web.UI.Page
{
    APILogic blog = new APILogic();
    Property objProp = new Property();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            objProp.IpAddress = Request.UserHostAddress.ToString();
            LogWrite("Get A Hit From IP : " + objProp.IpAddress, "_ZL_Log");
            /**************************(Read Post Converted Byte CODE)*************************/
            objProp.PostData = Request.BinaryRead(Request.ContentLength);
            var nvc = Request.Form.Count > 0 ? Request.Form : HttpContext.Current.Request.Form;
            // objLogic.LogWrite("Get A Hit From IP : " + objProp.PostData.Length, "_DMT_REQUEST");
            if (objProp.PostData.Length > 10)
            {

                if (nvc.Count > 0)
                    objProp.GetUrlValues = Encoding.UTF8.GetString(objProp.PostData);
                //else
                //    objProp.GetUrlValues = nvc.AllKeys[0].ToString();

                LogWrite(objProp.GetUrlValues?.ToString(), "_ZL_Log");
                objProp.GetUrlValues = HttpUtility.UrlDecode(objProp.GetUrlValues);
                LogWrite(objProp.IpAddress + " / " + objProp.GetUrlValues, "_ZL_Log");
                objProp.SplitValueEncode = objProp.GetUrlValues != null ? objProp.GetUrlValues.Split('&') : new string[] { };
                objProp.Function = objProp.SplitValueEncode.Length > 0 ? objProp.SplitValueEncode[0].ToString().Replace("zeeTech=", "").Trim() : "";
                objProp.Count = objProp.SplitValueEncode.Length;
                object json = string.Empty;

                if(objProp.Function == "DownloadReport")
                {
                    Stream stream = blog.DownloadReport(objProp);
                    if (stream != null)
                    {
                        Response.Clear();
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("Content-Disposition", $"attachment; filename=orders_{DateTime.Now.Millisecond}.xlsx");
                        
                        // Return stream to client
                        stream.CopyTo(Response.OutputStream);
                        Response.Flush();
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                    return;
                }
                json = blog.getmethod(objProp);
                // LogWrite("Request : " + objProp.GetUrlValues + "|\r\Response : " + json.ToString(), "_ZL_Log");
                if (IsResponseValid(objProp))
                {
                    Response.Write(json);
                }
                else
                {
                    Response.Write("Rcode:" + HttpStatusCode.InternalServerError + "|Error from Server");
                }
            }
            else
            {
                LogWrite("Invalid Fetch Hit 1", "_ZL_Log");
                Response.Write("Invalid Fetch Hit 1" + objProp.GetUrlValues);
            }
        }
        catch (Exception ex)
        {
            LogWrite(ex.ToString(), "_ZL_Log");
            Response.Write("Invalid Fetch Hit 2" + ex.ToString());
        }
    }


    public void LogWrite(string query, string infile)
    {
        Property objProp = new Property();
        System.IO.StreamWriter file = null;
        try
        {
            objProp.FileName = "C:\\ZeeLog\\ZeeLab_" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "_LOG_" + infile.ToUpper() + ".txt";
            file = new System.IO.StreamWriter(objProp.FileName, true);
            file.WriteLine(".................................." + System.DateTime.Now.ToString() + " IP " + objProp.GetIpAddress + "..........................>\r\n" + query);
            file.Close();
        }
        catch (Exception ex)
        { }
    }

    public Boolean IsResponseValid(Property objProp)
    {
        if (objProp.Result != "1" && objProp.Result != "2" && objProp.Result != "3" && objProp.Result != "4" && objProp.Result != "5")
        {
            return true;
        }
        else
            return false;
    }

}