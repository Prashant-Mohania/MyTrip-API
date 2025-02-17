using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using static APILogic;


/// <summary>
/// Summary description for BusinessLogic
/// </summary>
public class BusinessLogic
{
    public DataSet GetOrderList(Property objProp)
    {
        try
        {
            objProp.Query = "sp_zlOrderList";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_orderId", objProp.orderId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            if (objProp.DataSet.Tables[0].Rows.Count > 0)
            {
                objProp.DataTable = objProp.DataSet.Tables[0];
            }
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }

    public DataSet GetOrders(Property objProp)
    {
        try
        {
            objProp.Query = "sp_OrderList";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_userid", objProp.UserId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }

    public DataSet GetCartList(Property objProp)
    {
        try
        {
            objProp.Query = "sp_ViewCart";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_userid", objProp.UserId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }

    public DataSet ChangePassword(Property objProp)
    {
        try
        {
            objProp.Query = "sp_changePass";
            MySqlParameter[] para = new MySqlParameter[3];
            para[0] = new MySqlParameter("_userid", objProp.UserId);
            para[1] = new MySqlParameter("_currentpass", objProp.CustomerId);
            para[2] = new MySqlParameter("_newpass", objProp.Password);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }

    public DataSet DeleteFromcart(Property objProp)
    {
        try
        {
            objProp.Query = "sp_DeleteCart";
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("_prodid", objProp.ProductID);
            para[1] = new MySqlParameter("_userid", objProp.UserId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }

    public DataSet getProductList(Property objProp)
    {
        try
        {
            objProp.Query = "sp_Productlist";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("IsProductVisible", objProp.IsProductVisible);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet getOfferList(Property objProp)
    {
        try
        {
            objProp.Query = "sp_OfferList";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("p_status", objProp.Status);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet GetOrderPlace(string userId, string orderId, string mode)
    {
            string query = "sp_zlOrderPlace";
            MySqlParameter[] para = new MySqlParameter[3];
            para[0] = new MySqlParameter("_userid", userId);
            para[1] = new MySqlParameter("_order_Id", orderId);
            para[2] = new MySqlParameter("_mode", mode);
            return DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, query, para);
    }

    public DataTable Agentlogin(Property objProp)
    {
        try
        {

            objProp.Query = "sp_zlLogin_User";
            MySqlParameter[] para = new MySqlParameter[3];
            para[0] = new MySqlParameter("_userid", objProp.emailID);
            para[1] = new MySqlParameter("_password", objProp.Password);
            para[2] = new MySqlParameter("_usertype", objProp.UserType);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            if (objProp.DataSet.Tables[0].Rows.Count > 0)
            {
                objProp.DataTable = objProp.DataSet.Tables[0];
            }
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataTable;
    }

    public DataSet AddToCartLogic(Property objProp)
    {
        try
        {

            objProp.Query = "sp_zladdtoCart";
            MySqlParameter[] para = new MySqlParameter[8];
            para[0] = new MySqlParameter("_userid", objProp.UserId);
            para[1] = new MySqlParameter("_productName", objProp.ProductName);
            para[2] = new MySqlParameter("_count", objProp.Count);
            para[3] = new MySqlParameter("_mrp", objProp.mrp);
            para[4] = new MySqlParameter("_proid", objProp.ProductID);
            para[5] = new MySqlParameter("_ptr", objProp.PTR);
            para[6] = new MySqlParameter("_gst", 0);
            para[7] = new MySqlParameter("_offer_qty", 0);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet AddProfile(Property objProp)
    {
        try
        {
            objProp.Query = "sp_createUser";
            MySqlParameter[] para = new MySqlParameter[18];
            para[0] = new MySqlParameter("_userName", objProp.Username);
            para[1] = new MySqlParameter("_usermobile", objProp.Mobile);
            para[2] = new MySqlParameter("_useremail", objProp.emailID);
            para[3] = new MySqlParameter("_password", objProp.Password);
            para[4] = new MySqlParameter("_address", objProp.Address);
            para[5] = new MySqlParameter("_pincode", objProp.Pincode);
            para[6] = new MySqlParameter("_firstName", objProp.FirstName);
            para[7] = new MySqlParameter("_lastName", objProp.LastName);
            para[8] = new MySqlParameter("_storeCode", objProp.StoreCode);
            para[9] = new MySqlParameter("_storeName", objProp.StoreName);
            para[10] = new MySqlParameter("_userTypeId", objProp.UserTypeId);
            para[11] = new MySqlParameter("_zoneId", objProp.ZoneId == 0 ? null : objProp.ZoneId);
            para[12] = new MySqlParameter("_cityId", objProp.CityId == 0 ? null : objProp.CityId);
            para[13] = new MySqlParameter("_stateId", objProp.StateId == 0 ? null : objProp.StateId);
            string cityIdsJson = JsonConvert.SerializeObject(objProp.CitiesIds);
            para[14] = new MySqlParameter("cityIdsJson", cityIdsJson);
            para[15] = new MySqlParameter("gst", objProp.GST);
            para[16] = new MySqlParameter("licenseNo", objProp.licenseNo);
            para[17] = new MySqlParameter("dob", objProp.dob);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }

    public DataSet ProfileUpdate(Property objProp)
    {
        try
        {

            objProp.Query = "sp_updateProfile";
            MySqlParameter[] para = new MySqlParameter[14];
            para[0] = new MySqlParameter("_userID", objProp.UserId);
            para[1] = new MySqlParameter("_address", objProp.Address);
            para[2] = new MySqlParameter("_pincode", objProp.Pincode);
            para[3] = new MySqlParameter("_firstName", objProp.FirstName);
            para[4] = new MySqlParameter("_lastName", objProp.LastName);
            para[5] = new MySqlParameter("_storeCode", objProp.StoreCode);
            para[6] = new MySqlParameter("_storeName", objProp.StoreName);
            para[7] = new MySqlParameter("_zoneId", objProp.ZoneId == 0 ? null : objProp.ZoneId);
            para[8] = new MySqlParameter("_cityId", objProp.CityId == 0 ? null : objProp.CityId);
            para[9] = new MySqlParameter("_stateId", objProp.StateId == 0 ? null : objProp.StateId);
            string cityIdsJson = JsonConvert.SerializeObject(objProp.CitiesIds);
            para[10] = new MySqlParameter("cityIdsJson", cityIdsJson);
            para[11] = new MySqlParameter("gst", objProp.GST);
            para[12] = new MySqlParameter("licenseNo", objProp.licenseNo);
            para[13] = new MySqlParameter("dob", objProp.dob);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }

    public DataSet ProductList(List<ProductListRoot> chunkList)
    {
        Property objProp = new Property();
        try
        {
            objProp.Query = "sp_productList_insert";

            string productListJson = JsonConvert.SerializeObject(chunkList);

            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_ProductListJson", productListJson);

            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }

    //public DataSet CreateLog(Property objProp)
    //{
    //    try
    //    {
    //        objProp.Query = "sp_Sapproductlog";
    //        MySqlParameter[] para = new MySqlParameter[7];

    //        para[0] = new MySqlParameter("FileName", objProp.File_Name);
    //        para[1] = new MySqlParameter("StatusName", objProp.StatusName);
    //        para[2] = new MySqlParameter("Total_Updated", objProp.Total_Updated);
    //        para[3] = new MySqlParameter("CreatedDate", objProp.Created_Date);
    //        para[4] = new MySqlParameter("ProcessDate", objProp.ProcessDate);
    //        para[5] = new MySqlParameter("Total_Record", objProp.Total_Record);
    //        para[6] = new MySqlParameter("Total_Inserted", objProp.Total_Inserted);
    //        objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
    //    }
    //    catch (Exception ex)
    //    {
    //        objProp.Result = ex.Message;
    //    }
    //    return objProp.DataSet;
    //}
    public DataSet getOfferById(Property objProp)
    {
        try
        {
            objProp.Query = "sp_GetOfferByID";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("p_offerID", objProp.Offer_Id);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet CreateOffer(Property objProp)
    {
        try
        {

            string path = ConfigurationManager.AppSettings["ImagePath"];
            string filePath = AppDomain.CurrentDomain.BaseDirectory + path;
            string file = filePath + objProp.image;

            SaveImageToFolder(filePath);
            file = Path.GetFileName(file);



            objProp.Query = "sp_Addoffer";
            MySqlParameter[] para = new MySqlParameter[13];

            para[0] = new MySqlParameter("Name", objProp.Offer_Name);
            para[1] = new MySqlParameter("Description", objProp.Offer_Description);
            para[2] = new MySqlParameter("FromDate", objProp.From_Date);
            para[3] = new MySqlParameter("ToDate", objProp.To_Date);
            para[4] = new MySqlParameter("EligibilityQty", objProp.Eligibility_Qty);
            para[5] = new MySqlParameter("OfferQty", objProp.Offer_Qty);

            string productIdsJson = JsonConvert.SerializeObject(objProp.ProductIds);
            para[6] = new MySqlParameter("ProductIdsJSON", productIdsJson);
            para[7] = new MySqlParameter("Status", objProp.Offer_Status);
            para[8] = new MySqlParameter("CreatedBy", objProp.CreatedBy);
            para[9] = new MySqlParameter("CreatedOn", objProp.CreatedDate);
            para[10] = new MySqlParameter("UpdatedBy", objProp.UpdatedBy);
            para[11] = new MySqlParameter("UpdatedOn", objProp.UpdatedDate);
            para[12] = new MySqlParameter("Image", file);

            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;


    }
    public DataSet ForgotPass(Property objProp)
    {
        try
        {

            objProp.Query = "sp_forgotPass";
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("_userEmail", objProp.emailID);
            para[1] = new MySqlParameter("_password", objProp.Password);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }

    public void LogWrite(string query, string infile)
    {
        Property objProp = new Property();
        System.IO.StreamWriter file = null;
        try
        {
            objProp.FileName = "C:\\ZeeLog\\AEPS_LOGS_" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "_LOG_" + infile.ToUpper() + ".txt";
            file = new System.IO.StreamWriter(objProp.FileName, true);
            file.WriteLine(".................................." + System.DateTime.Now.ToString() + " IP " + objProp.GetIpAddress + "..........................>\r\n" + query);
            file.Close();
        }
        catch (Exception ex)
        { }
    }
    public DataSet CreateBanner(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["ImagePath"];
        string filePath = AppDomain.CurrentDomain.BaseDirectory + path;
        string file = filePath + objProp.image;

        SaveImageToFolder(filePath);
        file = Path.GetFileName(file);
        if (file != null)
        {
            try
            {
                objProp.Query = "sp_createbanner";
                MySqlParameter[] para = new MySqlParameter[3];
                para[0] = new MySqlParameter("_bannerName", objProp.bannerName);
                para[1] = new MySqlParameter("_image", file);
                para[2] = new MySqlParameter("_sequence", objProp.sequence);
                objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            }
            catch (Exception ex)
            {
                objProp.Result = ex.Message;
            }
        }
        else { objProp.Result = "File not found"; }
        return objProp.DataSet;
    }
    public DataSet getStateList(Property objProp)
    {
        try
        {
            objProp.Query = "sp_Statelist";
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet GetCityList(Property objProp)
    {
        try
        {
            objProp.Query = "sp_CityList";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_stateId", objProp.StateId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet getZone(Property objProp)
    {
        try
        {
            objProp.Query = "sp_ZoneList";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_listData", objProp.ListData);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet getUsers(Property objProp)
    {
        try
        {
            objProp.Query = "sp_userList";
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataTable UserById(Property objProp)
    {
        try
        {

            objProp.Query = "sp_userById";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_userid", objProp.Id);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            if (objProp.DataSet.Tables[0].Rows.Count > 0)
            {
                objProp.DataTable = objProp.DataSet.Tables[0];
            }
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataTable;
    }

    public void SaveImageToFolder(string filePath)
    {
        Property property = new Property();

        var httpRequest = HttpContext.Current.Request;
        if (httpRequest.Files.Count > 0)
        {
            var file = httpRequest.Files[0];
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            file.SaveAs(filePath + file.FileName);

        }

    }

    public DataSet AddZone(Property objProp)
    {
        try
        {
            objProp.Query = "sp_addZone";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_zoneName", objProp.Zone);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;

    }

    public DataTable ZoneById(Property objProp)
    {
        try
        {
            objProp.Query = "sp_getByZoneId";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_zoneId", objProp.Id);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            if (objProp.DataSet.Tables[0].Rows.Count > 0)
            {
                objProp.DataTable = objProp.DataSet.Tables[0];
            }
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataTable;
    }
    public DataSet ZoneUpdate(Property objProp)
    {
        try
        {

            objProp.Query = "sp_zoneUpdate";
            MySqlParameter[] para = new MySqlParameter[3];
            para[0] = new MySqlParameter("_zoneId", objProp.ZoneId);
            para[1] = new MySqlParameter("_zoneName", objProp.Zone);
            para[2] = new MySqlParameter("_stateId", objProp.state);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet GetOrdersList(Property objProp)
    {
        try
        {
            objProp.Query = "sp_OrderDetails";
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("_userId", objProp.UserId);
            para[1] = new MySqlParameter("_usertype", objProp.UserTypeId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet UserOrderDetails(Property objProp)
    {
        try
        {
            objProp.Query = "sp_UserOrderDetails";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_orderId", objProp.OrderId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataTable ItemList(Property objProp)
    {
        try
        {
            objProp.Query = "sp_itemList";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_orderId", objProp.OrderId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            if (objProp.DataSet.Tables[0].Rows.Count > 0)
            {
                objProp.DataTable = objProp.DataSet.Tables[0];
            }
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataTable;
    }



    public DataSet SendOrderToSap(Property objProp)
    {
        try
        {

            objProp.Query = "sp_OrderToSAP";
            MySqlParameter[] para = new MySqlParameter[4];
            para[0] = new MySqlParameter("_orderId", objProp.OrderId);
            para[1] = new MySqlParameter("_jsonArray", objProp.JsonArray);
            para[2] = new MySqlParameter("_jsonArrayRequest", objProp.JsonArrayRequest);
            para[3] = new MySqlParameter("_orderShipId", objProp.SalesQuotationNumber);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet DeleteFromUser(Property objProp)
    {
        try
        {
            objProp.Query = "sp_DeleteUser";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_userid", objProp.UserId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet DeleteZone(Property objProp)
    {
        try
        {
            objProp.Query = "sp_DeleteZone";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_zoneId", objProp.ZoneId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }

    public DataSet OrderRejection(Property objProp)
    {
        try
        {
            objProp.Query = "sp_OrderReject";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_orderId", objProp.OrderId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet getBanners(Property objProp)
    {
        try
        {
            objProp.Query = "sp_BannerList";
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet DeleteBanners(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["ImagePath"];
        string filePath = AppDomain.CurrentDomain.BaseDirectory + path;
        string file = filePath + objProp.image;
        File.Delete(file);
        try
        {
            objProp.Query = "sp_DeleteBanner";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_bannerid", objProp.BannerId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataTable BannerById(Property objProp)
    {
        try
        {
            objProp.Query = "sp_getBannerById";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_bannerId", objProp.BannerId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            if (objProp.DataSet.Tables[0].Rows.Count > 0)
            {
                objProp.DataTable = objProp.DataSet.Tables[0];
            }
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataTable;
    }
    public DataSet BannerUpdate(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["ImagePath"];
        string filePath = AppDomain.CurrentDomain.BaseDirectory + path;
        string file = filePath + objProp.image;

        SaveImageToFolder(filePath);
        file = Path.GetFileName(file);
        if (file != null)
        {
            try
            {
                objProp.Query = "sp_bannerUpdate";
                MySqlParameter[] para = new MySqlParameter[4];
                para[0] = new MySqlParameter("_bannerId", objProp.BannerId);
                para[1] = new MySqlParameter("_bannerName", objProp.bannerName);
                para[2] = new MySqlParameter("_image", objProp.image);
                para[3] = new MySqlParameter("_sequence", objProp.sequence);
                objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            }
            catch (Exception ex)
            {
                objProp.Result = ex.Message;
            }
        }
        else { objProp.Result = "File not found"; }
        return objProp.DataSet;
    }
    public DataSet CreatePopupImage(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["PopupImagePath"];
        string filePath = AppDomain.CurrentDomain.BaseDirectory + path;
        string file = objProp.image;

        SaveImageToFolder(filePath);
        if (file != null)
        {
            try
            {
                objProp.Query = "sp_CreatePopupImage";
                MySqlParameter[] para = new MySqlParameter[3];
                para[0] = new MySqlParameter("_imageName", objProp.ImageName);
                para[1] = new MySqlParameter("_image", file);
                para[2] = new MySqlParameter("_productId", objProp.ProductId);
                objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            }
            catch (Exception ex)
            {
                objProp.Result = ex.Message;
            }
        }
        else { objProp.Result = "File not found"; }
        return objProp.DataSet;
    }
    public DataSet getPopupImageList(Property objProp)
    {
        try
        {
            objProp.Query = "sp_PopupImageList";
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataSet DeletePopupImage(Property objProp)
    {
        try
        {
            objProp.Query = "sp_DeletePopupImage";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_popupImageId", objProp.PopupImageId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;
    }
    public DataTable PopupImageById(Property objProp)
    {
        try
        {
            objProp.Query = "sp_getPopupImageById";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_popupImageId", objProp.PopupImageId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            if (objProp.DataSet.Tables[0].Rows.Count > 0)
            {
                objProp.DataTable = objProp.DataSet.Tables[0];
            }
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataTable;
    }
    public DataSet PopupImageUpdate(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["PopupImagePath"];
        string filePath = AppDomain.CurrentDomain.BaseDirectory + path;
        string file = objProp.image;

        SaveImageToFolder(filePath);
        if (file != null)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var files = httpRequest.Files[0];
                files.SaveAs(filePath + files.FileName);
            }
            try
            {
                objProp.Query = "sp_poupImageUpdate";
                MySqlParameter[] para = new MySqlParameter[5];
                para[0] = new MySqlParameter("_popupImageId", objProp.PopupImageId);
                para[1] = new MySqlParameter("_imageName", objProp.ImageName);
                para[2] = new MySqlParameter("_image", objProp.image);
                para[3] = new MySqlParameter("_productId", objProp.ProductId);
                para[4] = new MySqlParameter("_status", objProp.Status);
                objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            }
            catch (Exception ex)
            {
                objProp.Result = ex.Message;
            }
        }
        else { objProp.Result = "File not found"; }
        return objProp.DataSet;
    }
    public void DeleteImageToFolder(string filePath)
    {
        Property property = new Property();

        var httpRequest = HttpContext.Current.Request;
        if (httpRequest.Files.Count > 0)
        {
            var file = httpRequest.Files[0];
            File.Delete(filePath + file.FileName);

        }

    }
    public DataTable ProductById(Property objProp)
    {
        try
        {
            objProp.Query = "sp_getProductById";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_productId", objProp.ProductId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            if (objProp.DataSet.Tables[0].Rows.Count > 0)
            {
                objProp.DataTable = objProp.DataSet.Tables[0];
            }
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataTable;
    }
    public DataSet ProductUpdate(Property objProp, string categoryIds)
    {
        string path = ConfigurationManager.AppSettings["ProductPath"];
        string filePath = AppDomain.CurrentDomain.BaseDirectory + path;
        string files = objProp.image;

        if (files != null)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var file = httpRequest.Files[0];
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                file.SaveAs(filePath + files);
            }

            try
            {
                objProp.Query = "sp_productUpdate";
                MySqlParameter[] para = new MySqlParameter[14];
                para[0] = new MySqlParameter("_productId", objProp.ProductId);
                para[1] = new MySqlParameter("_itemCode", objProp.ItemCode);
                para[2] = new MySqlParameter("_itemName", objProp.ItemName);
                para[3] = new MySqlParameter("_frgnName", objProp.FrgnName);
                para[4] = new MySqlParameter("_onHand", objProp.OnHand);
                para[5] = new MySqlParameter("_available", objProp.Available);
                para[6] = new MySqlParameter("_mrp", objProp.mrp);
                para[7] = new MySqlParameter("_F1", objProp.F1);
                para[8] = new MySqlParameter("_F2", objProp.F2);
                para[9] = new MySqlParameter("_F3", objProp.F3);
                para[10] = new MySqlParameter("_F4", objProp.F4);
                para[11] = new MySqlParameter("_F5", objProp.F5);
                para[12] = new MySqlParameter("_prodImages", objProp.image);
                para[13] = new MySqlParameter("_categoryIds", categoryIds);
                objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            }
            catch (Exception ex)
            {
                objProp.Result = ex.Message;
            }
        }
        else { objProp.Result = "File not found"; }
        return objProp.DataSet;
    }

    public DataSet OfferUpdate(Property objProp)
    {
        try
        {

            string file;
            if(objProp.image != null || !string.IsNullOrEmpty(objProp.image))
            {
                string path = ConfigurationManager.AppSettings["OfferImagePath"];
                string filePath = AppDomain.CurrentDomain.BaseDirectory + path;
                file = filePath + objProp.image;
                SaveImageToFolder(filePath);
                file = Path.GetFileName(file);
            }
            else
            {
                file = null;
            }


            objProp.Query = "sp_UpdateOffer";
            MySqlParameter[] para = new MySqlParameter[14];
            para[0] = new MySqlParameter("_Id", objProp.Offer_Id);
            para[1] = new MySqlParameter("_Name", objProp.Offer_Name);
            para[2] = new MySqlParameter("_Description", objProp.Offer_Description);
            para[3] = new MySqlParameter("_FromDate", objProp.From_Date);
            para[4] = new MySqlParameter("_ToDate", objProp.To_Date);
            para[5] = new MySqlParameter("_EligibilityQty", objProp.Eligibility_Qty);
            para[6] = new MySqlParameter("_OfferQty", objProp.Offer_Qty);

            string productIdsJson = JsonConvert.SerializeObject(objProp.ProductIds);
            para[7] = new MySqlParameter("_ProductIdsJSON", productIdsJson);
            para[8] = new MySqlParameter("_Status", objProp.Offer_Status);
            para[9] = new MySqlParameter("_UpdatedBy", objProp.UpdatedBy);
            para[10] = new MySqlParameter("_UpdatedOn", objProp.UpdatedDate);
            para[11] = new MySqlParameter("_CreatedBy", objProp.CreatedBy);
            para[12] = new MySqlParameter("_CreatedOn", objProp.CreatedDate);
            para[13] = new MySqlParameter("Image", file);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;

    }
    public DataSet OfferDelete(Property objProp)
    {
        try
        {
            objProp.Query = "sp_DeleteOffer";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_Id", objProp.Offer_Id);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProp.DataSet;

    }

    public DataTable OrderDetailsById(Property objProp)
    {
        try
        {
            objProp.Query = "sp_GetOrderDetailsById";
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("_orderId", objProp.orderId);
            objProp.DataSet = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, objProp.Query, para);
            if (objProp.DataSet.Tables[0].Rows.Count > 0)
            {
                objProp.DataTable = objProp.DataSet.Tables[0];
            }
        }
        catch (Exception ex)
        {
            objProp.Result = "2";
        }
        return objProp.DataTable;
    }

    public DataSet GetFrequentlyBoughtProducts(int pageCount = 1, int pageNumber = 10)
    {
        MySqlParameter[] para = new MySqlParameter[2];
        para[0] = new MySqlParameter("PageNumber", pageNumber);
        para[1] = new MySqlParameter("PageCount", pageCount);
        var ds = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, "sp_GetFrequentlyBoughtProducts", para);
        return ds;
    }

    public DataSet GetPreviouslyOrderedProducts(int UserID, int pageCount = 1, int pageNumber = 10)
    {
        MySqlParameter[] para = new MySqlParameter[3];
        para[0] = new MySqlParameter("UserID", UserID);
        para[1] = new MySqlParameter("PageNumber", pageNumber);
        para[2] = new MySqlParameter("PageCount", pageCount);
        var ds = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, "sp_GetPreviouslyOrderedProducts", para);
        return ds;
    }

    public DataSet GetReturnProducts(int UserID)
    {
        MySqlParameter[] para = new MySqlParameter[1];
        para[0] = new MySqlParameter("inputUserId", UserID);
        var ds = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, "sp_GetReturnProducts", para);
        return ds;
    }

    public DataSet GetReturnProductsAdmin()
    {
        MySqlParameter[] para = new MySqlParameter[1];
        para[0] = new MySqlParameter("inputUserId", null);
        var ds = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, "sp_GetReturnProducts", para);
        return ds;
    }

    public void UpdateReturnProduct(ReturnProductModel model)
    {
        string query = $@"
            UPDATE ReturnProduct  
            SET Status = '{model.status}', description = '{model.description}' 
            WHERE Id = {model.Id};";

        DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query);

    }
    public void AddProductsReturn(List<ReturnProductModel> products)
    {
        // Build the bulk INSERT query
        List<string> rows = new List<string>();
        foreach (var product in products)
        {
            string row = $"({product.productId}, {product.batchNumber}, '{product.status}', '{product.description}', {product.userId}, {product.quantity}, '{product.CreatedAt:yyyy-MM-dd HH:mm:ss}')";
            rows.Add(row);
        }

        string bulkInsertQuery = $@"
                INSERT INTO ReturnProduct (productId, batchNumber, Status, description, userId, quantity, CreatedAt) 
                VALUES {string.Join(", ", rows)};";

        DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, bulkInsertQuery);
    }

    public bool DeleteReturnProduct(int id, int userid)
    {
        string query = $@"DELETE FROM ReturnProduct WHERE id = {id} AND userId = {userid} AND Status != 'Approve';";
        return DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query) > 0;
    }


    public void AddCategory(CategoryModel category)
    {
        string query = $@"
            INSERT INTO Category (Name, Image) 
            VALUES ('{category.Name}', '{category.Image}');";
        DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query);
    }

    public void UpdateCategory(CategoryModel category)
    {
        string query = "";
        if (string.IsNullOrEmpty(category.Image))
        {
            query = $@"
            UPDATE Category 
            SET Name = '{category.Name}', UpdatedAt = '{category.updatedAt:yyyy-MM-dd HH:mm:ss}' 
            WHERE Id = {category.Id};";
        }
        else
        {
            query = $@"
            UPDATE Category 
            SET Name = '{category.Name}', Image = '{category.Image}', UpdatedAt = '{category.updatedAt:yyyy-MM-dd HH:mm:ss}' 
            WHERE Id = {category.Id};";
        }

        DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query);
    }

    public void DeleteCategory(int categoryId)
    {
        string query = $@"
            DELETE FROM Category 
            WHERE Id = {categoryId};";
        DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query);

        try
        {
            string selectQuery = $@"
            SELECT * FROM Category 
            WHERE Id = {categoryId};";
            DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, selectQuery);
        }
        catch { }
    }

    public DataSet GetCategories()
    {
        var ds = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, "SELECT * FROM Category;");
        return ds;
    }

    public DataSet GetCategoryById(int categoryId)
    {
        var ds = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, $"SELECT * FROM Category WHERE Id = {categoryId}");
        return ds;
    }


    public DataSet GetProductsByCategoryId(int categoryId)
    {
        MySqlParameter[] para = new MySqlParameter[1];
        para[0] = new MySqlParameter("categoryId", categoryId);
        var ds = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, "sp_ProductsByCategoryId", para);
        return ds;
    }

    public void AddProductInOrderSheet(int userId, int productId)
    {
        string query = $@"
            INSERT INTO OrderSheet (UserId, ProductId) 
            VALUES ({userId}, {productId});";
        DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query);
    }

    public void RemoveProductFromOrderSheet(int userId, int productId)
    {
        string query = $@"
            DELETE FROM OrderSheet 
            WHERE UserId = {userId} AND ProductId = {productId};";
        DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query);
    }

    public DataSet GetOrderSheet(int userId)
    {
        MySqlParameter[] para = new MySqlParameter[1];
        para[0] = new MySqlParameter("userId", userId);
        var ds = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, "sp_GetOrderSheet", para);
        return ds;
    }

    // transfer products from order sheet to cart
    public void OrderSheetToCart(int userId)
    {
        MySqlParameter[] para = new MySqlParameter[1];
        para[0] = new MySqlParameter("userId", userId);
        DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, "sp_OrderSheetToCart", para);
    }

    // AddProductRequest
    public void AddProductRequest(int userId, string composition, string image)
    {
        string query = $@"
            INSERT INTO ProductRequest (UserId, Composition, Image) 
            VALUES ({userId}, '{composition}', '{image}');";
        DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query);
    }

    // delete 
    public void DeleteProductRequest(int id)
    {
        string query = $@"
            DELETE FROM  ProductRequest WHERE Id = {id};";
        DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query);
    }

    public DataSet GetProductRequests()
    {
        var ds = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, "SELECT * FROM ProductRequest ORDER BY Id Desc;");
        return ds;
    }

    public DataSet GetReorderProducts(string orderId)
    {
        MySqlParameter[] para = new MySqlParameter[1];
        para[0] = new MySqlParameter("orderId", orderId);
        var ds = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.StoredProcedure, "sp_GetReorderProducts", para);
        return ds;
    }
    public void AddGiftScheme(GiftSchemeModel giftScheme)
    {
        string query = $@"
            INSERT INTO GiftScheme (name, description, image, fromDate, toDate, isGlobal, eligibilityAmount, offer, excludedProducts) 
            VALUES ('{giftScheme.Name}', '{giftScheme.Description}', '{giftScheme.Image}', '{giftScheme.FromDate.ToString("yyyy-MM-dd HH:mm:ss")}', '{giftScheme.ToDate.ToString("yyyy-MM-dd HH:mm:ss")}', '1', '{giftScheme.EligibilityAmount}', '{giftScheme.Offer}', '{giftScheme.ExcludedProducts}');";
        DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query);
    }

    public void UpdateGiftScheme(GiftSchemeModel giftScheme)
    {
        //string query = $@"
        //    UPDATE GiftScheme 
        //    SET name = '{giftScheme.Name}', description = '{giftScheme.Description}', image = '{giftScheme.Image}', fromDate = '{giftScheme.FromDate.ToString("yyyy-MM-dd HH:mm:ss")}', toDate = '{giftScheme.ToDate.ToString("yyyy-MM-dd HH:mm:ss")}', eligibilityAmount = '{giftScheme.EligibilityAmount}', offer = '{giftScheme.Offer}', excludedProducts = '{giftScheme.ExcludedProducts}', updatedAt = '{giftScheme.UpdatedAt}' 
        //    WHERE Id = {giftScheme.Id};";
        //DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query);


        var updates = new List<string>();

        if (!string.IsNullOrEmpty(giftScheme.Name))
            updates.Add($"name = '{giftScheme.Name}'");

        if (!string.IsNullOrEmpty(giftScheme.Description))
            updates.Add($"description = '{giftScheme.Description}'");

        if (!string.IsNullOrEmpty(giftScheme.Image))
            updates.Add($"image = '{giftScheme.Image}'");

        if (giftScheme.FromDate != null)
            updates.Add($"fromDate = '{giftScheme.FromDate:yyyy-MM-dd HH:mm:ss}'");

        if (giftScheme.ToDate != null)
            updates.Add($"toDate = '{giftScheme.ToDate:yyyy-MM-dd HH:mm:ss}'");

        if (!string.IsNullOrEmpty(giftScheme.Offer))
            updates.Add($"offer = '{giftScheme.Offer}'");

        if (!string.IsNullOrEmpty(giftScheme.ExcludedProducts))
            updates.Add($"excludedProducts = '{giftScheme.ExcludedProducts}'");

        if (giftScheme.UpdatedAt != null)
            updates.Add($"updatedAt = '{giftScheme.UpdatedAt:yyyy-MM-dd HH:mm:ss}'");

        // Only proceed if there's something to update
        if (updates.Count > 0)
        {
            string setClause = string.Join(", ", updates);

            string query = $@"
        UPDATE GiftScheme 
        SET {setClause}
        WHERE Id = {giftScheme.Id};";

            DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query);
        }

    }

    public void DeleteGiftScheme(int giftSchemeId)
    {
        string query = $@"
            DELETE FROM GiftScheme 
            WHERE Id = {giftSchemeId};";
        DataLayer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, query);
    }

    public DataSet GetGiftSchemes()
    {
        var ds = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, "SELECT * FROM GiftScheme;");
        return ds;
    }

    public DataSet GetGiftSchemeById(int id)
    {
        var ds = DataLayer.ExecuteDataset(ConfigurationManager.ConnectionStrings["zlconnstrng"].ToString(), CommandType.Text, $@"SELECT * FROM GiftScheme WHERE Id = {id};");
        return ds;
    }
}