using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static APILogic;

public partial class ProductList : System.Web.UI.Page
{
    APILogic blog = new APILogic();
    Property objProp = new Property();
    BusinessLogic blogs = new BusinessLogic();
    protected void Page_Load(object sender, EventArgs e)
    {
        Property objProp = new Property();
        AddToCarts addcart = new AddToCarts();



        var client = new RestClient();
        var request = new RestRequest("http://122.187.28.27:81/api/ItemDetailsGetApi", Method.Get);
        var response = client.Execute(request);
        string itemJson = response.Content;
        try
        {
            ArrayList testarray = JsonConvert.DeserializeObject<ArrayList>(itemJson);
            for (int i = 0; i < testarray.Count; i++)
            {
                string item = testarray[i].ToString();
                ProductListRoot ObjRoot = JsonConvert.DeserializeObject<ProductListRoot>(item);
                objProp.ItemCode = ObjRoot.ItemCode;
                objProp.ItemName = ObjRoot.ItemName;
                objProp.FrgnName = ObjRoot.FrgnName;
                objProp.OnHand = ObjRoot.OnHand;
                objProp.Available = ObjRoot.Available;
                objProp.MRP = ObjRoot.MRP;
                objProp.F1 = ObjRoot.F_1;
                objProp.F2 = ObjRoot.F_2;
                objProp.F3 = ObjRoot.F_3;
                objProp.F4 = ObjRoot.F_4;
                objProp.F5 = ObjRoot.F_5;
                if (objProp.ItemCode != "" && objProp.ItemName != "" && objProp.FrgnName != "" && objProp.OnHand != "")
                {
                    objProp.DataSet = blogs.ProductList(new List<ProductListRoot> { ObjRoot });
                    if (objProp.DataSet.Tables[0].Rows.Count > 0)
                    {
                        if (objProp.DataSet.Tables[0].Rows[0]["id"].ToString() == "Y")
                        {
                            addcart.Status = "Success";
                            addcart.Result = objProp.DataSet.Tables[0].Rows[0]["desc"].ToString();
                        }
                        else
                        {
                            addcart.Status = "Fail";
                            addcart.Result = objProp.DataSet.Tables[0].Rows[0]["desc"].ToString();
                        }
                    }
                }

                else { addcart.Result = "5"; }
            }

        }
        catch (Exception ex)
        { addcart.Result = "2"; }

    }

    public class Root
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string FrgnName { get; set; }
        public string OnHand { get; set; }
        public string Available { get; set; }
        public string MRP { get; set; }
        public string F_1 { get; set; }
        public string F_2 { get; set; }
        public string F_3 { get; set; }
        public string F_4 { get; set; }
        public string F_5 { get; set; }
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