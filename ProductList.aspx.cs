using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
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

        try
        {
            var lucknowRequest = new RestRequest("http://122.187.28.26:1144/localapi/api/items/cfaStock", Method.Get);
            var lucknowResponse = client.Execute(lucknowRequest);
            string lucknowJson = lucknowResponse.Content;

            List<LucknowProduct> lucknowProducts = JsonConvert.DeserializeObject<List<LucknowProduct>>(lucknowJson);

            if(lucknowProducts != null && lucknowProducts.Count > 0)
            {
                foreach(var product in lucknowProducts)
                {
                    if (!string.IsNullOrEmpty(product.ItemId))
                    {
                        blogs.UpdateProductStock(product.ItemId, product.Quantity);
                    }
                }
            }
        }
        catch(Exception ex)
        {
            addcart.Result = "2";
        }

    }

    public void UpdateLucknowProductQty()
    {
        try
        {
            var client = new RestClient();
            var request = new RestRequest("http://122.187.28.26:1144/localapi/api/items/cfaStock", Method.Get);
            var response = client.Execute(request);
            string itemJson = response.Content;

            List<LucknowProduct> productList = JsonConvert.DeserializeObject<List<LucknowProduct>>(itemJson);

            if (productList?.Count > 0)
            {
                BulkUpdateLucknowQuantities(productList);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating product quantities: " + ex.Message);
        }
    }

    private void BulkUpdateLucknowQuantities(List<LucknowProduct> products)
    {
        var connStr = ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString();

        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();

            // Build the UPDATE query using CASE WHEN
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("UPDATE productlist SET lucknowQty = CASE ItemCode ");

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            int i = 0;

            foreach (var item in products)
            {
                string paramCode = "@code" + i;
                string paramQty = "@qty" + i;

                queryBuilder.Append($"WHEN {paramCode} THEN {paramQty} ");

                parameters.Add(new MySqlParameter(paramCode, item.ItemId));
                parameters.Add(new MySqlParameter(paramQty, Convert.ToInt32(item.Quantity)));

                i++;
            }

            queryBuilder.Append("END WHERE ItemCode IN (");

            for (int j = 0; j < i; j++)
            {
                queryBuilder.Append("@code" + j);
                if (j < i - 1) queryBuilder.Append(", ");
            }

            queryBuilder.Append(");");

            using (MySqlCommand cmd = new MySqlCommand(queryBuilder.ToString(), conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                cmd.ExecuteNonQuery();
            }
        }
    }


    public class LucknowProduct
    {
        public string StoreId { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
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