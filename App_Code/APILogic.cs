using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.Charts;
using DataTable = System.Data.DataTable;
using Formatting = Newtonsoft.Json.Formatting;
using Path = System.IO.Path;
using cashfree_pg.Client;
using cashfree_pg.Model;
using System.Net;
using static APILogic;

/// <summary>
/// Summary description for BusinessLogic
/// </summary>

public class APILogic
{
    BusinessLogic blogs = new BusinessLogic();
    public object getmethod(Property objProp)
    {
        object jsonResponse = string.Empty;

        var testValue = HttpContext.Current.Request.Form["zeeTech"];
        switch (testValue)
        {
            case "AddBanner": jsonResponse = AddBanner(objProp); break;
            case "EditBanner": jsonResponse = EditBanner(objProp); break;
            case "AddPopUpImage": jsonResponse = AddPopupImage(objProp); break;
            case "EditPopUpImage": jsonResponse = EditPopupImage(objProp); break;
            case "EditProduct": jsonResponse = EditProduct(objProp); break;
            case "AddProductRequst": jsonResponse = AddProductRequst(objProp); break;
            case "AddCategory": jsonResponse = AddCategory(objProp); break;
            case "AddOffer": jsonResponse = AddOffer(objProp); break;
            case "AddGiftScheme": jsonResponse = AddGiftScheme(objProp); break;
            case "UpdateGiftScheme": jsonResponse = UpdateGiftScheme(objProp); break;
            case "EditOffer": jsonResponse = EditOffer(objProp); break;
            case "EditCategory": jsonResponse = EditCategory(objProp); break;
        }
        switch (objProp.Function)
        {
            case "zlLogin": jsonResponse = Shoplogin(objProp); break;
            case "zladdtocart": jsonResponse = AddToCart(objProp); break;
            case "zlviewCart": jsonResponse = getCartProduct(objProp); break;
            case "zlOrder": jsonResponse = getOrderHistory(objProp); break;
            case "zlOrderList": jsonResponse = getOrderList(objProp); break;
            case "zlPlaceOrder": jsonResponse = PlaceOrder(objProp); break;
            case "RemoveCart": jsonResponse = RemoveCart(objProp); break;
            case "PassChange": jsonResponse = ChangePass(objProp); break;
            case "InfoUpdate": jsonResponse = UpdateInfo(objProp); break;
            case "ForgotPassword": jsonResponse = ForgotPassword(objProp); break;
            case "ProductList": jsonResponse = ProductList(objProp); break;
            case "AddUser": jsonResponse = CreateProfile(objProp); break;
            case "AddBanner": jsonResponse = AddBanner(objProp); break;
            case "GetState": jsonResponse = GetState(objProp); break;
            case "GetCity": jsonResponse = GetCityByStateId(objProp); break;
            case "GetZone": jsonResponse = GetZoneList(objProp); break;
            case "GetUser": jsonResponse = GetUserList(objProp); break;
            case "GetUserById": jsonResponse = GetUserById(objProp); break;
            case "AddZone": jsonResponse = AddZone(objProp); break;
            case "GetByZoneId": jsonResponse = GetByZoneId(objProp); break;
            case "UpdateZone": jsonResponse = UpdateZone(objProp); break;
            case "OrderDetails": jsonResponse = GetOrderDetails(objProp); break;
            case "SapAPI": jsonResponse = UpdateOrderStatus(objProp); break;
            case "DeleteUser": jsonResponse = DeleteUser(objProp); break;
            case "DeleteZone": jsonResponse = DeleteZone(objProp); break;
            case "RejectOrder": jsonResponse = RejectOrder(objProp); break;
            case "GetBanner": jsonResponse = BannerList(objProp); break;
            case "DeleteBanner": jsonResponse = DeleteBanner(objProp); break;
            case "GetBannerById": jsonResponse = GetBannerById(objProp); break;
            case "GetPopupImageList": jsonResponse = GetPopupImageList(objProp); break;
            case "DeletePopupImage": jsonResponse = DeletePopupImage(objProp); break;
            case "GetPopupImageById": jsonResponse = GetPopupImageById(objProp); break;
            case "GetProductById": jsonResponse = GetProductById(objProp); break;
            case "AllProductList": jsonResponse = GetAllProducts(objProp); break;
            case "GetOrderDetailsById": jsonResponse = GetOrderDetailsById(objProp); break;
            case "OfferList": jsonResponse = OfferList(objProp); break;
            case "AddOffer": jsonResponse = AddOffer(objProp); break;
            case "EditOffer": jsonResponse = EditOffer(objProp); break;
            case "DeleteOffer": jsonResponse = DeleteOffer(objProp); break;
            case "GetOfferById": jsonResponse = GetOfferById(objProp); break;
            case "EmailTest": jsonResponse = TestEmail(objProp); break;
            //case "DownloadExcel": jsonResponse = DownloadOrderExcel(objProp); break;
            case "GetFrequentlyBoughtProducts": jsonResponse = GetFrequentlyBoughtProducts(objProp); break;
            case "GetPreviouslyOrderedProducts": jsonResponse = GetPreviouslyOrderedProducts(objProp); break;
            case "GetNewArrivals": jsonResponse = GetFrequentlyBoughtProducts(objProp); break;
            case "GetReturnProducts": jsonResponse = GetReturnProducts(objProp); break;
            case "GetReturnProductsAdmin": jsonResponse = GetReturnProductsAdmin(objProp); break;
            case "UpdateReturnProductsAdmin": jsonResponse = UpdateReturnProductsAdmin(objProp); break;
            case "AddProductsReturn": jsonResponse = AddProductsReturn(objProp); break;
            case "DeleteProductsReturn": jsonResponse = DeleteReturnProduct(objProp); break;
            case "DeleteCategory": jsonResponse = DeleteCategory(objProp); break;
            case "GetCategory": jsonResponse = GetCategories(objProp); break;
            case "GetCategoryById": jsonResponse = GetCategoryById(objProp); break;
            case "GetProductByCategoryId": jsonResponse = GetProductByCategoryId(objProp); break;
            case "AddProductInOrderSheet": jsonResponse = AddProductInOrderSheet(objProp); break;
            case "GetOrderSheet": jsonResponse = GetOrderSheet(objProp); break;
            case "RemoveProductFromOrderSheet": jsonResponse = RemoveProductFromOrderSheet(objProp); break;
            case "OrderSheetToCart": jsonResponse = OrderSheetToCart(objProp); break;
            case "getReorderProducts": jsonResponse = getReorderProducts(objProp); break;
            case "GetProductRequests": jsonResponse = GetProductRequests(objProp); break;
            case "DeleteProductRequest": jsonResponse = DeleteProductRequest(objProp); break;
            case "GetGiftSchemes": jsonResponse = GetGiftSchemes(objProp); break;
            case "DeleteGiftScheme": jsonResponse = DeleteGiftScheme(objProp); break;
            case "GetGiftSchemeById": jsonResponse = GetGiftSchemeById(objProp); break;
            case "CreateOrder": jsonResponse = CreateOrder(objProp); break;
            case "VerifyPayment": jsonResponse = VerifyPayment(objProp); break;
        }
        //JavaScriptSerializer serializer = new JavaScriptSerializer();
        //serializer.MaxJsonLength = Int32.MaxValue;
        //return serializer.Serialize(jsonResponse);

        return JsonConvert.SerializeObject(jsonResponse);
    }

    public List<ProductListRoot> GetFrequentlyBoughtProducts(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["ProductPath"];
        string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
        int pageNumber = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "pageNumber", 1);
        int pageCount = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "pageCount", 10);
        List<ProductListRoot> objProvider = new List<ProductListRoot>();
        DataSet dsProvider = blogs.GetFrequentlyBoughtProducts(pageCount, pageNumber);
        try
        {
            DataTable dtProvider = new DataTable("OrdersList");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable() select MapProductList(x, baseUrl, path));
            objProvider = c.ToList();
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }

    public List<ProductListRoot> GetPreviouslyOrderedProducts(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["ProductPath"];
        string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
        int UserID = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "userId", 1);
        int pageNumber = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "pageNumber", 1);
        int pageCount = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "pageCount", 10);

        List<ProductListRoot> objProvider = new List<ProductListRoot>();
        DataSet dsProvider = blogs.GetPreviouslyOrderedProducts(UserID, pageCount, pageNumber);
        try
        {
            DataTable dtProvider = new DataTable("OrdersList");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable() select MapProductList(x, baseUrl, path));
            objProvider = c.ToList();
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }

    public List<ReturnProductModel> GetReturnProducts(Property objProp)
    {
        string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
        string path = ConfigurationManager.AppSettings["ProductPath"];
        int userId = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "userId", 0);
        List<ReturnProductModel> objProvider = new List<ReturnProductModel>();
        DataSet dsProvider = blogs.GetReturnProducts(userId);
        try
        {
            DataTable dtProvider = new DataTable("ReturnProducts");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable()
                     select new ReturnProductModel
                     {
                         Id = Convert.ToInt32(x["id"]),
                         productId = Convert.ToInt32(x["ProductId"]),
                         batchNumber = Convert.ToString(x["batchNumber"]),
                         productName = Convert.ToString(x["productName"]),
                         productImg = baseUrl + path + Convert.ToString(x["productImg"]),
                         userId = Convert.ToInt32(x["UserId"]),
                         status = Convert.ToString(x["Status"]),
                         description = Convert.ToString(x["Description"]),
                         CreatedAt = Convert.ToDateTime(x["CreatedAt"]),
                         quantity = Convert.ToInt32(x["quantity"]),
                     });
            objProvider = c.ToList();
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }

    public List<ReturnProductModel> GetReturnProductsAdmin(Property objProp)
    {
        List<ReturnProductModel> objProvider = new List<ReturnProductModel>();
        try
        {
            string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
            string path = ConfigurationManager.AppSettings["ProductPath"];

            DataSet dsProvider = blogs.GetReturnProductsAdmin();
            DataTable dtProvider = new DataTable("ReturnProducts");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable()
                     select new ReturnProductModel
                     {
                         Id = Convert.ToInt32(x["id"]),
                         productId = Convert.ToInt32(x["ProductId"]),
                         batchNumber = Convert.ToString(x["batchNumber"]),
                         productName = Convert.ToString(x["productName"]),
                         productImg = baseUrl + path + Convert.ToString(x["productImg"]),
                         userId = Convert.ToInt32(x["UserId"]),
                         status = Convert.ToString(x["Status"]),
                         description = Convert.ToString(x["Description"]),
                         CreatedAt = Convert.ToDateTime(x["CreatedAt"]),
                         quantity = Convert.ToInt32(x["quantity"]),
                     });
            objProvider = c.ToList();
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }

    // update return product status and descriptions
    public ResponseModel<ReturnProductModel> UpdateReturnProductsAdmin(Property objProp)
    {
        ResponseModel<ReturnProductModel> response;

        try
        {
            string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
            string path = ConfigurationManager.AppSettings["ProductPath"];

            string data = Utils.GetEncodeValue<string>(objProp.SplitValueEncode, "data", "");
            ReturnProductModel returnProduct = JsonConvert.DeserializeObject<ReturnProductModel>(data);

            blogs.UpdateReturnProduct(returnProduct);

            response = new ResponseModel<ReturnProductModel>(returnProduct, "Update successfull.");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<ReturnProductModel>(ex.Message);
        }
        return response;
    }

    public Dictionary<string, object> AddProductsReturn(Property objProp)
    {
        try
        {
            Dictionary<string, object> response = new Dictionary<string, object>();

            string data = Utils.GetEncodeValue<string>(objProp.SplitValueEncode, "data", string.Empty);

            List<ReturnProductModel> returnProducts = JsonConvert.DeserializeObject<List<ReturnProductModel>>(data);

            // Validate the return products
            var validationResult = Utils.ValidateReturnProduct(returnProducts);
            if (!validationResult.Item1)
            {
                objProp.Result = string.Join(", ", validationResult.Item2);
                response.Add("status", false);
                response.Add("message", string.Join(", ", validationResult.Item2));
                return response; // Convert the response to JSON
            }

            // If validation passes, perform the operation
            blogs.AddProductsReturn(returnProducts);

            // Success response
            response.Add("status", true);
            response.Add("message", "Products returned successfully.");
            return response; // Convert the response to JSON
        }
        catch (Exception ex)
        {
            // Error handling
            objProp.Result = ex.Message;
            var errorResponse = new Dictionary<string, object>
        {
            { "status", false },
            { "message", ex.Message }
        };
            return errorResponse; // Return error response as JSON
        }
    }

    public ResponseModel<bool> DeleteReturnProduct(Property objProp)
    {
        try
        {
            int id = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "id", 0);
            int userId = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "userId", 0);

            if (userId == 0)
            {
                return new ResponseModel<bool>(message: "Invalid User ID");
            }
            if (id == 0)
            {
                return new ResponseModel<bool>(message: "Invalid ID");
            }

            if (blogs.DeleteReturnProduct(id: id, userid: userId))
            {
                return new ResponseModel<bool>(data: true, message: "Successfully Deleted"); ;
            }
            else
            {
                return new ResponseModel<bool>(message: "Product not found or It's Approved");
            }
        }
        catch (Exception ex)
        {
            return new ResponseModel<bool>(message: ex.Message);
        }
    }
    public Stream DownloadOrderExcel(Property objProp)
    {
        try
        {
            // Get the orders DataSet
            DataSet ordersDataSet = blogs.GetOrdersList(objProp);

            // Convert DataSet to List<Order> assuming DataSet contains Order information
            List<Order> orders = ConvertDataSetToList<Order>(ordersDataSet);

            // Instantiate ExcelExport
            ExcelExport excelExport = new ExcelExport();

            // Export orders to Excel and return the Stream
            return excelExport.DownloadExcel(orders, "orders.xlsx");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred during Excel export: " + ex.Message);
            return null;
        }
    }
    private List<T> ConvertDataSetToList<T>(DataSet dataSet)
    {
        List<T> items = new List<T>();

        DataTable dataTable = dataSet.Tables[0];

        foreach (DataRow row in dataTable.Rows)
        {
            T item = Activator.CreateInstance<T>();

            foreach (DataColumn column in dataTable.Columns)
            {
                var property = typeof(T).GetProperty(column.ColumnName);
                if (property != null && row[column] != DBNull.Value)
                {
                    property.SetValue(item, row[column]);
                }
            }

            items.Add(item);
        }

        return items;

    }
    public async Task<Emailmodel> TestEmail(Property objProp)
    {
        Emailmodel emailModel = new Emailmodel();
        objProp.To = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
        objProp.Subject = "Email Test";
        objProp.Body = "Testing the Email";
        try
        {
            EmailSend.SendEmail(objProp.To, objProp.Body, objProp.Subject);
            return emailModel;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public AgentLogins Shoplogin(Property objProp)
    {
        AgentLogins objLogin = new AgentLogins();
        try
        {
            objProp.emailID = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            objProp.Password = objProp.SplitValueEncode[2].Split('=')[1].ToString().Trim();
            objProp.UserType = objProp.SplitValueEncode[3].Split('=')[1].ToString().Trim();
            if (objProp.Password != "" && objProp.emailID != "")
            {
                DataTable dtLogin = blogs.Agentlogin(objProp);
                if (dtLogin?.Rows.Count > 0)
                {
                    DataRow dr = dtLogin.Rows[0];
                    Console.WriteLine(dr);
                    if (dtLogin.Columns.Count == 2)
                    {
                        objLogin.Id = Convert.ToString(dr["id"]);
                        objLogin.Result = Convert.ToString(dr["Result"]);
                    }
                    else
                    {
                        objLogin.Id = Convert.ToString(dr["UserId"]);
                        objLogin.username = Convert.ToString(dr["UserName"]);
                        objLogin.Mobile = Convert.ToString(dr["Mobile"]);
                        objLogin.Email = Convert.ToString(dr["Email"]);
                        objLogin.Address = Convert.ToString(dr["Address"]);
                        objLogin.Pincode = Convert.ToString(dr["Pincode"]);
                        objLogin.City = Convert.ToString(dr["City"]);
                        objLogin.CityId = Convert.ToString(dr["CityId"]);
                        objLogin.StateId = Convert.ToString(dr["StateId"]);
                        objLogin.State = Convert.ToString(dr["State"]);
                        objLogin.Status = Convert.ToString(dr["Status"]);
                        objLogin.FirstName = Convert.ToString(dr["FirstName"]);
                        objLogin.LastName = Convert.ToString(dr["LastName"]);
                        objLogin.StoreCode = Convert.ToString(dr["StoreCode"]);
                        objLogin.StoreName = Convert.ToString(dr["StoreName"]);
                        objLogin.Usertype = Convert.ToString(dr["Usertype"]);
                        objLogin.Zone = Convert.ToString(dr["Zone"]);
                        objLogin.Result = Convert.ToString(dr["Result"]);
                    }
                }
                return objLogin;
            }
            else { objProp.Result = "5"; }

        }
        catch (Exception ex)
        { objProp.Result = ex.Message; }
        return objLogin;
    }
    public AddToCarts AddToCart(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        try
        {
            objProp.UserId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            objProp.ProductName = objProp.SplitValueEncode[2].Split('=')[1].ToString().Trim();
            objProp.Count = Convert.ToInt32(objProp.SplitValueEncode[3].Split('=')[1].ToString().Trim());
            objProp.mrp = objProp.SplitValueEncode[4].Split('=')[1].ToString().Trim();
            objProp.ProductID = objProp.SplitValueEncode[5].Split('=')[1].ToString().Trim();
            objProp.PTR = objProp.SplitValueEncode[6].Split('=')[1].ToString().Trim();
            if (objProp.UserId != "" && objProp.ProductName != "" && objProp.Count != 0 && objProp.mrp != "" || objProp.ProductID != "")
            {
                objProp.DataSet = blogs.AddToCartLogic(objProp);
                if (objProp.DataSet.Tables[0].Rows.Count > 0)
                {
                    if (objProp.DataSet.Tables[0].Rows[0]["id"].ToString() == "Y")
                    {
                        addcart.Status = "Success";
                        addcart.Result = objProp.DataSet.Tables[0].Rows[0]["Result"].ToString();
                    }
                    else
                    {
                        addcart.Status = "Fail";
                        addcart.Result = objProp.DataSet.Tables[0].Rows[0]["Result"].ToString();
                    }
                }
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }
    public AddToCarts PlaceOrder(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        try
        {
            objProp.UserId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            if (objProp.UserId != "")
            {
                string orderId = Utils.GetEncodeValue<string>(objProp.SplitValueEncode, "orderId", "");

                if (!string.IsNullOrEmpty(orderId) && !PaymentGatewayService.VerifyOrder(orderId))
                {
                    addcart.Result = "Payment Fail";
                    return addcart;
                }

                string mode = string.IsNullOrEmpty(orderId) ? "COD": "Online";
                objProp.DataSet = blogs.GetOrderPlace(objProp.UserId, orderId, mode);
                
                if (objProp.DataSet.Tables[0].Rows.Count > 0)
                {
                    if (objProp.DataSet.Tables[0].Rows[0]["id"].ToString() == "Y")
                    {
                        addcart.Status = "Success";
                        addcart.Result = objProp.DataSet.Tables[0].Rows[0]["Result"].ToString();
                    }
                    else
                    {
                        addcart.Status = "Fail";
                        addcart.Result = objProp.DataSet.Tables[0].Rows[0]["Result"].ToString();
                    }
                }
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }

    public AddToCarts RemoveCart(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        try
        {
            objProp.ProductID = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            objProp.UserId = objProp.SplitValueEncode[2].Split('=')[1].ToString().Trim();
            if (objProp.UserId != "" && objProp.ProductID != "")
            {
                objProp.DataSet = blogs.DeleteFromcart(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }

    public AddToCarts ChangePass(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        try
        {
            objProp.UserId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            objProp.CustomerId = objProp.SplitValueEncode[2].Split('=')[1].ToString().Trim();
            objProp.Password = objProp.SplitValueEncode[3].Split('=')[1].ToString().Trim();
            if (objProp.UserId != "" && objProp.Password != "")
            {
                objProp.DataSet = blogs.ChangePassword(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }

    public List<CartView> getCartProduct(Property objProp)
    {
        objProp.UserId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
        string path = ConfigurationManager.AppSettings["ProductPath"];
        string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
        List<CartView> objProvider = new List<CartView>();
        DataSet dsProvider = blogs.GetCartList(objProp);
        try
        {
            DataTable dtProvider = new DataTable();
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable()
                     select new CartView
                     {
                         ProductId = Convert.ToString(x["ProductId"]),
                         Result = Convert.ToString(x["Result"]),
                         ProductName = Convert.ToString(x["ProductName"]),
                         Quantity = Convert.ToString(x["Quantity"]),
                         MRP = Convert.ToString(x["MRP"]),
                         TotalAmount = Convert.ToDecimal(x["TotalAmount"]),
                         GST = Convert.ToDecimal(x["GST"]),
                         PTR = Convert.ToDecimal(x["PTR"]),
                         Adddate = Convert.ToString(x["Adddate"]),
                         ImageUrl = baseUrl + path + Convert.ToString(x["ImageUrl"]),
                         Offer_Applied = x["Offer_Details"] != DBNull.Value ?
                             new OfferApplied
                             {
                                 OfferId = JObject.Parse(x["Offer_Details"].ToString())["offerid"].ToString(),
                                 OfferName = JObject.Parse(x["Offer_Details"].ToString())["offername"].ToString(),
                                 OfferedProducts = Convert.ToInt32(JObject.Parse(x["Offer_Details"].ToString())["offeredproducts"]),
                                 offerQty = Convert.ToInt32(JObject.Parse(x["Offer_Details"].ToString())["offerQty"]),
                                 eligibilityQty = Convert.ToInt32(JObject.Parse(x["Offer_Details"].ToString())["eligibilityQty"]),
                             } : null
                     });

            objProvider = c.ToList();

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }
    public ProductOrder getOrderHistory(Property objProp)
    {
        objProp.orderId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
        ProductOrder objProvider = new ProductOrder();
        List<Product> objProviders = new List<Product>();
        string path = ConfigurationManager.AppSettings["ProductPath"];
        string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
        DataSet dsProvider = blogs.GetOrderList(objProp);
        try
        {
            DataTable dtProvider = new DataTable("Provider");
            dtProvider = dsProvider.Tables[0];
            if (!dtProvider.Rows[0]["Status"].ToString().Contains("No Data Found"))
            {
                objProvider.Date = dtProvider.Rows[0]["Date"].ToString();
                objProvider.OrderID = dtProvider.Rows[0]["orderID"].ToString();
                objProvider.Totality = dtProvider.Rows.Count;
                objProvider.SalesQuotation = dtProvider.Rows[0]["SaleQuotation"].ToString();
                int sum = 0;
                objProvider.totalamount = sum;
                var c = (from x in dtProvider.AsEnumerable()
                         select new Product
                         {
                             ODID = Convert.ToInt32(x["ordid"]),
                             pid = Convert.ToInt32(x["uid"]),
                             OrderID = Convert.ToString(x["orderID"]),
                             ProductName = Convert.ToString(x["ProductName"]),
                             Count = Convert.ToInt32(x["Counts"]),
                             MRP = Convert.ToString(x["mrp"]),
                             GST = Convert.ToString(x["GST"]),
                             PTR = Convert.ToString(x["PTR"]),
                             Offer_Qty = Convert.ToString(x["Offer_Qty"]),
                             Status = Convert.ToString(x["Status"]),
                             Date = Convert.ToString(x["Date"]),
                             Tamount = Convert.ToString(x["Tamount"]),
                             image = baseUrl + path + Convert.ToString(x["image"]),

                         });
                objProviders = c.ToList();
                objProvider.Products = objProviders;
            }
            else
            {
                objProvider.OrderID = dtProvider.Rows[0]["Status"].ToString();
                return objProvider;
            }
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }

    public AddToCarts CreateProfile(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        List<int> Cities = GetCityIdsFromForm();

        try
        {

            objProp.Username = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            objProp.Mobile = objProp.SplitValueEncode[2].Split('=')[1].ToString().Trim();
            objProp.emailID = objProp.SplitValueEncode[3].Split('=')[1].ToString().Trim();
            objProp.Address = objProp.SplitValueEncode[4].Split('=')[1].ToString().Trim() != "" ? (objProp.SplitValueEncode[4].Split('=')[1].ToString().Trim()) : (string)null;
            objProp.Pincode = objProp.SplitValueEncode[5].Split('=')[1].ToString().Trim();
            objProp.FirstName = objProp.SplitValueEncode[6].Split('=')[1].ToString().Trim();
            objProp.LastName = objProp.SplitValueEncode[7].Split('=')[1].ToString().Trim();
            objProp.StoreCode = objProp.SplitValueEncode[8].Split('=')[1].ToString().Trim();
            objProp.StoreName = objProp.SplitValueEncode[9].Split('=')[1].ToString().Trim();
            objProp.UserTypeId = Convert.ToInt32(objProp.SplitValueEncode[10].Split('=')[1].ToString().Trim());
            objProp.ZoneId = objProp.SplitValueEncode[11].Split('=')[1].ToString().Trim() != "" ? Convert.ToInt32(objProp.SplitValueEncode[11].Split('=')[1].ToString().Trim()) : (int?)null;
            objProp.CityId = objProp.SplitValueEncode[12].Split('=')[1].ToString().Trim() != "" ? Convert.ToInt32(objProp.SplitValueEncode[12].Split('=')[1].ToString().Trim()) : (int?)null;
            objProp.CitiesIds = Cities;
            objProp.StateId = objProp.SplitValueEncode[13].Split('=')[1].ToString().Trim() != "" ? Convert.ToInt32(objProp.SplitValueEncode[13].Split('=')[1].ToString().Trim()) : (int?)null;
            objProp.Password = CreateRandomPassword(10);
            if (objProp.emailID != "")
            {
                objProp.DataSet = blogs.AddProfile(objProp);
                if (objProp.DataSet.Tables[0].Rows.Count > 0)
                {
                    if (objProp.DataSet.Tables[0].Rows[0]["id"].ToString() == "Y")
                    {
                        string subject = "Registration Email";
                        string body = "This is your Login credentials: Username is " + objProp.emailID + " and password is :" + objProp.Password;
                        EmailSend.SendEmail(objProp.emailID, body, subject);
                        addcart.Status = "Success";
                        addcart.Result = objProp.DataSet.Tables[0].Rows[0]["desc"].ToString();
                    }
                    else
                    {
                        addcart.Status = "Fail";
                        addcart.Result = objProp.DataSet.Tables[0].Rows[0]["desc"].ToString();
                    }
                }
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }

    public AddToCarts UpdateInfo(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        List<int> Cities = GetCityIdsFromForm();
        try
        {
            objProp.UserId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            objProp.Address = objProp.SplitValueEncode[2].Split('=')[1].ToString().Trim();
            objProp.Pincode = objProp.SplitValueEncode[3].Split('=')[1].ToString().Trim();
            objProp.FirstName = objProp.SplitValueEncode[4].Split('=')[1].ToString().Trim();
            objProp.LastName = objProp.SplitValueEncode[5].Split('=')[1].ToString().Trim();
            objProp.StoreCode = objProp.SplitValueEncode[6].Split('=')[1].ToString().Trim();
            objProp.StoreName = objProp.SplitValueEncode[7].Split('=')[1].ToString().Trim();
            objProp.ZoneId = objProp.SplitValueEncode[8].Split('=')[1].ToString().Trim() != "" ? Convert.ToInt32(objProp.SplitValueEncode[8].Split('=')[1].ToString().Trim()) : (int?)null;
            objProp.CityId = objProp.SplitValueEncode[9].Split('=')[1].ToString().Trim() != "" ? Convert.ToInt32(objProp.SplitValueEncode[9].Split('=')[1].ToString().Trim()) : (int?)null;
            objProp.StateId = objProp.SplitValueEncode[10].Split('=')[1].ToString().Trim() != "" ? Convert.ToInt32(objProp.SplitValueEncode[10].Split('=')[1].ToString().Trim()) : (int?)null;
            objProp.CitiesIds = Cities;
            if (objProp.UserId != "" && objProp.Username != "")
            {
                objProp.DataSet = blogs.ProfileUpdate(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }

    public AddToCarts ForgotPassword(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        try
        {
            objProp.emailID = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            if (objProp.UserId != "")
            {
                objProp.Password = CreateRandomPassword(10);
                objProp.DataSet = blogs.ForgotPass(objProp);
                if (objProp.DataSet.Tables[0].Rows.Count > 0)
                {
                    if (objProp.DataSet.Tables[0].Rows[0]["id"].ToString() == "Y")
                    {
                        string subject = "Forgot Password Email";
                        string body = "Your new password is : " + objProp.Password;
                        EmailSend.SendEmail(objProp.emailID, body, subject);
                        addcart.Status = "Success";
                        addcart.Result = objProp.DataSet.Tables[0].Rows[0]["desc"].ToString();
                    }
                    else
                    {
                        addcart.Status = "Fail";
                        addcart.Result = objProp.DataSet.Tables[0].Rows[0]["desc"].ToString();
                    }
                }
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }

    private static string CreateRandomPassword(int length = 10)
    {
        string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$";
        Random random = new Random();
        char[] chars = new char[length];
        for (int i = 0; i < length; i++)
        {
            chars[i] = validChars[random.Next(0, validChars.Length)];
        }
        return new string(chars);
    }

    public List<OrdersList> getOrderList(Property objProp)
    {
        objProp.UserId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
        OrdersList objOrder = new OrdersList();

        List<OrdersList> objProvider = new List<OrdersList>();
        DataSet dsProvider = blogs.GetOrders(objProp);
        try
        {
            DataTable dtProvider = new DataTable("OrdersList");
            dtProvider = dsProvider.Tables[0];

            var c = (from x in dtProvider.AsEnumerable()
                     select new OrdersList
                     {
                         id = Convert.ToString(x["id"]),
                         Result = Convert.ToString(x["Result"]),
                         OrderID = Convert.ToString(x["OrderID"]),
                         DateOrder = Convert.ToString(x["DateOrder"]),
                         Status = Convert.ToString(x["Status"]),
                         OrderShipID = Convert.ToString(x["OrderShipID"]),
                         BillDate = Convert.ToString(x["BillDate"]),
                         ShipDate = Convert.ToString(x["ShipDate"]),
                         TotalAmount = Convert.ToString(x["TotalAmount"]),
                         StoreCode = Convert.ToString(x["StoreCode"]),
                         StoreName = Convert.ToString(x["StoreName"]),
                         StatusId = Convert.ToString(x["StatusId"]),
                         SalesQuotation = Convert.ToString(x["SaleQuotation"]),
                         Totality = Convert.ToInt32(x["Totality"])
                     });
            objProvider = c.ToList();
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }

    public List<ProductListRoot> ProductList(Property objProp)
    {
        var ProductVisibility = HttpContext.Current.Request.Form["Value"];
        string path = ConfigurationManager.AppSettings["ProductPath"];
        string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
        List<ProductListRoot> objProvider = new List<ProductListRoot>();
        objProp.IsProductVisible = ProductVisibility == null ? "ALL" : ProductVisibility;
        DataSet dsProvider = blogs.getProductList(objProp);
        try
        {
            DataTable dtProvider = new DataTable("OrdersList");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable() select MapProductList(x, baseUrl, path));
            objProvider = c.ToList();
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }
    public List<OfferListRoot> OfferList(Property objProp)
    {
        var status = HttpContext.Current.Request.Form["status"];
        List<OfferListRoot> objProvider = new List<OfferListRoot>();
        objProp.Status = Convert.ToString(status);
        DataSet dsProvider = blogs.getOfferList(objProp);
        try
        {
            DataTable dtProvider = new DataTable("offer");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable()
                     select new OfferListRoot
                     {
                         OfferId = Convert.ToString(x["id"]),
                         OfferName = Convert.ToString(x["name"]),
                         Description = Convert.ToString(x["description"]),
                         FromDate = Convert.ToDateTime(x["FromDate"]).ToString("yyyy/MM/dd"),
                         ToDate = Convert.ToDateTime(x["ToDate"]).ToString("yyyy/MM/dd"),
                         EligibilityQty = Convert.ToString(x["eligibilityQty"]),
                         OfferQty = Convert.ToString(x["offerQty"]),
                         offerstatus = Convert.ToString(x["status"]),
                         Image = Convert.ToString(x["image"]),
                         productId = Convert.ToString(x["product_id"]),
                         Status = "Successfully listed",
                         Result = "Sucess",
                     });
            objProvider = c.ToList();
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }
    public List<OfferListRoot> GetOfferById(Property objProp)
    {
        var ID = HttpContext.Current.Request.Form["id"];
        var objProvider = new List<OfferListRoot>();
        objProp.Offer_Id = Convert.ToInt32(ID);

        string path = ConfigurationManager.AppSettings["ImagePath"];
        string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
        DataSet dsOffer = blogs.getOfferById(objProp);
        try
        {
            DataTable dtProvider = new DataTable("offer");
            dtProvider = dsOffer.Tables[0];
            var c = (from x in dtProvider.AsEnumerable()
                     select new OfferListRoot
                     {
                         OfferId = Convert.ToString(x["id"]),
                         OfferName = Convert.ToString(x["name"]),
                         Description = Convert.ToString(x["description"]),
                         FromDate = Convert.ToDateTime(x["FromDate"]).ToString("yyyy/MM/dd"),
                         ToDate = Convert.ToDateTime(x["ToDate"]).ToString("yyyy/MM/dd"),
                         EligibilityQty = Convert.ToString(x["eligibilityQty"]),
                         OfferQty = Convert.ToString(x["offerQty"]),
                         offerstatus = Convert.ToString(x["status"]),
                         productId = x["productIds"] != DBNull.Value ? Convert.ToString(x["productIds"]) : null,
                         Image = baseUrl + path + Convert.ToString(x["image"]),
                         Status = "Successfully listed",
                         Result = "Sucess",
                     });
            objProvider = c.ToList();
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }
    public OfferListRoot AddOffer(Property objProp)
    {
        var id = HttpContext.Current.Request.Form["id"];
        var name = HttpContext.Current.Request.Form["name"];
        var description = HttpContext.Current.Request.Form["description"];
        var fromDate = HttpContext.Current.Request.Form["fromDate"];
        var toDate = HttpContext.Current.Request.Form["toDate"];
        var eligibilityQty = HttpContext.Current.Request.Form["eligibilityQty"];
        var offerQty = HttpContext.Current.Request.Form["offerQty"];
        var status = HttpContext.Current.Request.Form["status"];
        var createdby = HttpContext.Current.Request.Form["createdBy"];
        var updatedby = HttpContext.Current.Request.Form["updatedBy"];
        var image = HttpContext.Current.Request.Files["image"].FileName;

        List<int> productIds = GetProductIdsFromForm();
        OfferListRoot offerListResponse = new OfferListRoot();

        // image path 
        string path = ConfigurationManager.AppSettings["ImagePath"];
        string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";


        try
        {
            objProp.Offer_Id = Convert.ToInt32(id);
            objProp.Offer_Name = name;
            objProp.Offer_Description = description;
            objProp.From_Date = Convert.ToDateTime(fromDate);
            objProp.To_Date = Convert.ToDateTime(toDate);
            objProp.Eligibility_Qty = Convert.ToString(eligibilityQty);
            objProp.Offer_Qty = Convert.ToString(offerQty);
            objProp.ProductIds = productIds;
            objProp.Offer_Status = Convert.ToInt32(status);
            objProp.CreatedBy = createdby;
            objProp.CreatedDate = DateTime.Now;
            objProp.UpdatedBy = updatedby;
            objProp.UpdatedDate = DateTime.Now;
            objProp.image = image;

            objProp.DataSet = blogs.CreateOffer(objProp);
            if (objProp.DataSet.Tables[0].Rows.Count > 0)
            {
                if (objProp.DataSet.Tables[0].Rows[0]["id"].ToString() == "Y")
                {
                    offerListResponse.OfferId = Convert.ToString(objProp.Offer_Id);
                    offerListResponse.OfferName = objProp.Offer_Name;
                    offerListResponse.Description = objProp.Offer_Description;
                    offerListResponse.FromDate = objProp.From_Date.ToString("yyyy/MM/dd");
                    offerListResponse.ToDate = objProp.To_Date.ToString("yyyy/MM/dd");
                    offerListResponse.EligibilityQty = objProp.Eligibility_Qty;
                    offerListResponse.Image = baseUrl + path + objProp.image;

                    offerListResponse.OfferQty = objProp.Offer_Qty;
                    if (objProp.Offer_Status == 1)
                    {
                        offerListResponse.offerstatus = "Active";
                    }
                    else if (objProp.Offer_Status == 2)
                    {
                        offerListResponse.offerstatus = "Deactive";
                    }
                    else
                    {
                        offerListResponse.offerstatus = "status not found";
                    }
                    offerListResponse.Status = "Success";
                    offerListResponse.Result = objProp.DataSet.Tables[0].Rows[0]["desc"].ToString();
                }
                else
                {
                    offerListResponse.Status = "Fail";
                    offerListResponse.Result = objProp.DataSet.Tables[0].Rows[0]["desc"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            offerListResponse.Result = ex.Message;
        }

        return offerListResponse;
    }

    private List<int> GetProductIdsFromForm()
    {
        List<int> productIds = new List<int>();

        var productIdsString = HttpContext.Current.Request.Form["productIds"];

        if (!string.IsNullOrEmpty(productIdsString))
        {
            string[] productIdArray = productIdsString.Split(',');

            foreach (var productId in productIdArray)
            {
                if (int.TryParse(productId, out int id))
                {
                    productIds.Add(id);
                }
            }
        }

        return productIds;
    }
    private List<int> GetCityIdsFromForm()
    {
        List<int> Cities = new List<int>();

        var cityIdsString = HttpContext.Current.Request.Form["CitiesIds"];

        if (!string.IsNullOrEmpty(cityIdsString))
        {
            string[] cityIdArray = cityIdsString.Split(',');

            foreach (var cities in cityIdArray)
            {
                if (int.TryParse(cities, out int id))
                {
                    Cities.Add(id);
                }
            }
        }

        return Cities;
    }

    public void LogWrite(string query, string infile)
    {
        Property objProp = new Property();
        System.IO.StreamWriter file = null;
        try
        {
            objProp.FileName = ".\\ZeeLog\\FetchBill_" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "_LOG_" + infile.ToUpper() + ".txt";
            file = new System.IO.StreamWriter(objProp.FileName, true);
            file.WriteLine(".................................." + System.DateTime.Now.ToString() + " IP " + objProp.GetIpAddress + "..........................>\r\n" + query);
            file.Close();
        }
        catch (Exception ex)
        { }
    }
    public AddToCarts AddBanner(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();

        var name = HttpContext.Current.Request.Form["bannerName"];
        var image = HttpContext.Current.Request.Files["image"].FileName;
        var seq = HttpContext.Current.Request.Form["sequence"];
        try
        {
            objProp.bannerName = name;
            objProp.image = image.ToString();
            objProp.sequence = seq;

            if (objProp.bannerName != "")
            {
                objProp.DataSet = blogs.CreateBanner(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }

        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }
    public List<AgentLogins> GetState(Property objProp)
    {
        List<AgentLogins> objProvider = new List<AgentLogins>();
        DataSet dsProvider = blogs.getStateList(objProp);
        try
        {
            DataTable dtProvider = new DataTable("StateList");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable()
                     select new AgentLogins
                     {
                         Id = Convert.ToString(x["id"]),
                         State = Convert.ToString(x["name"])
                     });
            objProvider = c.ToList();
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }
    public List<AgentLogins> GetCityByStateId(Property objProp)
    {
        objProp.StateId = Convert.ToInt32(objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim());
        List<AgentLogins> objProvider = new List<AgentLogins>();
        DataSet dsProvider = blogs.GetCityList(objProp);
        try
        {
            DataTable dtProvider = new DataTable("CityList");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable()
                     select new AgentLogins
                     {
                         Id = Convert.ToString(x["id"]),
                         City = Convert.ToString(x["name"])
                     });
            objProvider = c.ToList();

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;


    }
    public List<Property> GetZoneList(Property objProp)
    {
        objProp.ListData = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
        List<Property> objProvider = new List<Property>();
        DataSet dsProvider = blogs.getZone(objProp);
        try
        {
            DataTable dtProvider = new DataTable("ZoneList");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable()
                     select new Property
                     {
                         ZoneId = Convert.ToInt32(x["id"]),
                         Zone = Convert.ToString(x["name"])
                     });
            objProvider = c.ToList();
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }
    public List<AgentLogins> GetUserList(Property objProp)
    {
        List<AgentLogins> objProvider = new List<AgentLogins>();
        DataSet dsProvider = blogs.getUsers(objProp);
        try
        {
            DataTable dtProvider = new DataTable("UserList");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable()
                     select new AgentLogins
                     {
                         Id = Convert.ToString(x["Id"]),
                         FirstName = Convert.ToString(x["FirstName"]),
                         LastName = Convert.ToString(x["LastName"]),
                         Email = Convert.ToString(x["Email"]),
                         Mobile = Convert.ToString(x["Mobile"]),
                         StoreCode = Convert.ToString(x["StoreCode"]),
                         StoreName = Convert.ToString(x["StoreName"]),
                         UsertypeId = Convert.ToString(x["UserTypeId"]),
                         Usertype = Convert.ToString(x["UserType"]),
                         Zone = Convert.ToString(x["Zone"]),
                         City = Convert.ToString(x["City"]),
                         State = Convert.ToString(x["State"]),
                         Regional_Cites = Convert.ToString(x["RegionalCities"])
                     });
            objProvider = c.ToList();
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }
    public AgentLogins GetUserById(Property objProp)
    {
        AgentLogins objLogin = new AgentLogins();
        try
        {
            objProp.Id = Convert.ToInt32(objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim());
            if (objProp.Password != "" && objProp.LoginID != "")
            {
                DataTable dtLogin = blogs.UserById(objProp);
                if (dtLogin?.Rows.Count > 0)
                {
                    DataRow dr = dtLogin.Rows[0];
                    Console.WriteLine(dr);
                    if (dtLogin.Columns.Count == 2)
                    {
                        objLogin.Id = Convert.ToString(dr["id"]);
                        objLogin.Result = Convert.ToString(dr["Result"]);
                    }
                    else
                    {
                        objLogin.Id = Convert.ToString(dr["Id"]);
                        objLogin.Address = Convert.ToString(dr["Address"]);
                        objLogin.Pincode = Convert.ToString(dr["Pincode"]);
                        objLogin.City = Convert.ToString(dr["City"]);
                        objLogin.State = Convert.ToString(dr["State"]);
                        objLogin.FirstName = Convert.ToString(dr["FirstName"]);
                        objLogin.LastName = Convert.ToString(dr["LastName"]);
                        objLogin.StoreCode = Convert.ToString(dr["StoreCode"]);
                        objLogin.StoreName = Convert.ToString(dr["StoreName"]);
                        objLogin.UsertypeId = Convert.ToString(dr["UsertypeId"]);
                        objLogin.Usertype = Convert.ToString(dr["Usertype"]);
                        objLogin.username = Convert.ToString(dr["Username"]);
                        objLogin.Mobile = Convert.ToString(dr["Mobile"]);
                        objLogin.Email = Convert.ToString(dr["Email"]);
                        objLogin.Zone = Convert.ToString(dr["Zone"]);
                        objLogin.Result = Convert.ToString(dr["Result"]);
                        objLogin.CitiesIds = Convert.ToString(dr["CitiesIds"]);
                    }
                }
                return objLogin;
            }
            else { objProp.Result = "5"; }

        }
        catch (Exception ex)
        { objProp.Result = ex.Message; }
        return objLogin;
    }
    public AddToCarts AddZone(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        try
        {
            objProp.Zone = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();

            if (objProp.Zone != "")
            {
                objProp.DataSet = blogs.AddZone(objProp);
                if (objProp.DataSet.Tables[0].Rows.Count > 0)
                {
                    if (objProp.DataSet.Tables[0].Rows[0]["id"].ToString() == "Success")
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }

        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }
    public AgentLogins GetByZoneId(Property objProp)
    {
        AgentLogins objLogin = new AgentLogins();
        try
        {
            objProp.Id = Convert.ToInt32(objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim());
            if (objProp.Password != "" && objProp.LoginID != "")
            {
                DataTable dtLogin = blogs.ZoneById(objProp);
                if (dtLogin?.Rows.Count > 0)
                {
                    DataRow dr = dtLogin.Rows[0];
                    Console.WriteLine(dr);
                    if (dtLogin.Columns.Count == 2)
                    {
                        objLogin.Id = Convert.ToString(dr["id"]);
                        objLogin.Result = Convert.ToString(dr["Result"]);
                    }
                    else
                    {
                        objLogin.Id = Convert.ToString(dr["Id"]);
                        objLogin.Zone = Convert.ToString(dr["ZoneName"]);
                        objLogin.State = Convert.ToString(dr["SelectedStates"]);
                        objLogin.Result = Convert.ToString(dr["Result"]);
                    }
                }
                return objLogin;
            }
            else { objProp.Result = "5"; }

        }
        catch (Exception ex)
        { objProp.Result = ex.Message; }
        return objLogin;
    }
    public AddToCarts UpdateZone(Property objProp)
    {

        AddToCarts addcart = new AddToCarts();
        try
        {
            objProp.ZoneId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim() != "" ? Convert.ToInt32(objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim()) : (int?)null;
            objProp.Zone = objProp.SplitValueEncode[2].Split('=')[1].ToString().Trim();
            objProp.state = objProp.SplitValueEncode[3].Split('=')[1].ToString().Trim();
            if (objProp.Zone != "" && objProp.Username != "")
            {
                objProp.DataSet = blogs.ZoneUpdate(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }
    public List<OrdersList> GetOrderDetails(Property objProp)
    {
        objProp.UserId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
        objProp.UserTypeId = Convert.ToInt32(objProp.SplitValueEncode[2].Split('=')[1].ToString().Trim());
        List<OrdersList> objProvider = new List<OrdersList>();
        DataSet dsProvider = blogs.GetOrdersList(objProp);
        try
        {
            DataTable dtProvider = new DataTable("OrdersList");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable()
                     select new OrdersList
                     {
                         id = Convert.ToString(x["order_Id"]),
                         Result = Convert.ToString(x["Result"]),
                         OrderID = Convert.ToString(x["OrderID"]),
                         SalesQuotation = Convert.ToString(x["SaleQuotation"]),
                         StoreCode = Convert.ToString(x["StoreCode"]),
                         StoreName = Convert.ToString(x["StoreName"]),
                         BillDate = Convert.ToString(x["OrderDate"]),
                         ShipDate = Convert.ToString(x["OrderInDate"]),
                         StatusId = Convert.ToString(x["StatusId"]),
                         Status = Convert.ToString(x["Status"]),
                         TotalAmount = Convert.ToString(x["TotalAmount"])
                     });
            objProvider = c.ToList();
        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }

    public AddToCarts UpdateOrderStatus(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();

        objProp.OrderId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
        UserOrderList objProvider = new UserOrderList();
        DataSet dsProvider = blogs.UserOrderDetails(objProp);
        DataTable dtItemList = blogs.ItemList(objProp);
        try
        {
            var itemListData = (from x in dtItemList.AsEnumerable()
                                select new ItemList
                                {
                                    ItemCode = Convert.ToString(x["itemCode"]),
                                    Quantity = Convert.ToInt32(x["qty"]),
                                    Mrp = Convert.ToDecimal(x["unitPrice"]),
                                    OfferdQty = Convert.ToInt32(x["OfferdQty"])
                                }).ToList();

            DataTable dtProvider = new DataTable("UserOrdersList");
            dtProvider = dsProvider.Tables[0];
            objProvider = (from x in dtProvider.AsEnumerable()
                           select new UserOrderList
                           {
                               OrderId = Convert.ToString(x["orderID"]),
                               OrderDate = Convert.ToDateTime(x["OrderDate"]),
                               FirstName = Convert.ToString(x["CustomerDetail"]),
                               Email = Convert.ToString(x["customeremailid"]),
                               Mobile = Convert.ToString(x["MobileNo"]),
                               Address = Convert.ToString(x["Address"]),
                               City = Convert.ToString(x["City"]),
                               State = Convert.ToString(x["State"]),
                               ZipCode = Convert.ToString(x["ZipCode"]),
                               PaymentMode = Convert.ToString(x["StoreCode"]),
                               UserOrderListItems = itemListData
                           }).FirstOrDefault();

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }


        var client = new RestClient();
        var request = new RestRequest("http://122.187.28.27:81/api/SalesQuotionPostAPI", Method.Post);
        request.AddHeader("Content-Type", "application/json");
        JObject jObjectbody = new JObject();
        JArray childItems = new JArray();

        jObjectbody.Add("OrderNo", objProvider.OrderId);
        jObjectbody.Add("OrderDate", string.Format("{0:yyyyMMdd}", objProvider.OrderDate));
        jObjectbody.Add("PaymentMode", objProvider.PaymentMode);
        jObjectbody.Add("CustomerDetail", objProvider.FirstName);
        jObjectbody.Add("customeremailid", objProvider.Email);
        jObjectbody.Add("MobileNo", objProvider.Mobile);
        jObjectbody.Add("Street", objProvider.Address);
        jObjectbody.Add("Block", "");
        jObjectbody.Add("Country", "");
        jObjectbody.Add("City", objProvider.City);
        jObjectbody.Add("State", objProvider.State);
        jObjectbody.Add("ZipCode", objProvider.ZipCode);
        jObjectbody.Add("Discount_percentage", 0);
        jObjectbody.Add("ShippingCharge", 0);

        foreach (var item in objProvider.UserOrderListItems)
        {
            JObject itemObject = new JObject();
            itemObject.Add("itemCode", item.ItemCode);
            itemObject.Add("qty", item.Quantity);
            itemObject.Add("unitPrice", item.Mrp);
            childItems.Add(itemObject);
            if (item.OfferdQty > 0)
            {
                itemObject = new JObject();
                itemObject.Add("itemCode", item.ItemCode);
                itemObject.Add("qty", item.OfferdQty);
                itemObject.Add("unitPrice", 0);
                childItems.Add(itemObject);
            }
        }

        jObjectbody["childs"] = childItems;
        string objectTosend = jObjectbody.ToString(Formatting.None);

        request.AddParameter("application/json", objectTosend, ParameterType.RequestBody);

        var response = client.Execute(request);
        string trimmedContent = response.Content.Trim(' ', '[', ']');
        string itemJson = response.Content;
        objProp.JsonArray = itemJson;
        objProp.JsonArrayRequest = objectTosend;

        // If response content has JSON then if block will execute.
        if (trimmedContent.StartsWith("{") && trimmedContent.EndsWith("}"))
        {
            ResponseData ObjRoot = JsonConvert.DeserializeObject<List<ResponseData>>(itemJson).FirstOrDefault();
            objProp.SalesQuotationNumber = ObjRoot.SalesQuotationNumber;
        }
        else
        {
            objProp.SalesQuotationNumber = "";
        }
        try
        {
            objProp.DataSet = blogs.SendOrderToSap(objProp);
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
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }

    public AddToCarts DeleteUser(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        try
        {
            objProp.UserId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            if (objProp.UserId != "")
            {
                objProp.DataSet = blogs.DeleteFromUser(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }
    public AddToCarts DeleteZone(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        try
        {
            objProp.ZoneId = Convert.ToInt32(objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim());
            if (Convert.ToString(objProp.ZoneId) != "")
            {
                objProp.DataSet = blogs.DeleteZone(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }
    public AddToCarts RejectOrder(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        try
        {
            objProp.OrderId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            if (objProp.OrderId != "")
            {
                objProp.DataSet = blogs.OrderRejection(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }
    public List<Banner> BannerList(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["ImagePath"];
        string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
        List<Banner> objProvider = new List<Banner>();
        DataSet dsProvider = blogs.getBanners(objProp);
        try
        {
            DataTable dtProvider = new DataTable("BannerList");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable()
                     select new Banner
                     {
                         BannerId = Convert.ToInt32(x["id"]),
                         BannerName = Convert.ToString(x["name"]),
                         ImageUrl = baseUrl + path + Uri.EscapeUriString(Convert.ToString(x["image"])),
                         Sequence = Convert.ToInt32(x["sequence"])
                     });
            objProvider = c.ToList();

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }
    public AddToCarts DeleteBanner(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        try
        {
            objProp.BannerId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            string fileName = objProp.SplitValueEncode[2].Split('=')[1].ToString().Trim();
            objProp.image = Path.GetFileName(fileName);
            if (objProp.BannerId != "")
            {
                objProp.DataSet = blogs.DeleteBanners(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }
    public Banner GetBannerById(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["ImagePath"];
        Banner objBanner = new Banner();
        try
        {
            objProp.BannerId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            if (objProp.BannerId != "")
            {
                DataTable dtLogin = blogs.BannerById(objProp);
                if (dtLogin?.Rows.Count > 0)
                {
                    DataRow dr = dtLogin.Rows[0];
                    Console.WriteLine(dr);
                    if (dtLogin.Columns.Count == 2)
                    {
                        objBanner.Id = Convert.ToInt32(dr["id"]);
                        objBanner.Result = Convert.ToString(dr["Result"]);
                    }
                    else
                    {
                        objBanner.BannerId = Convert.ToInt32(dr["Id"]);
                        objBanner.BannerName = Convert.ToString(dr["BannerName"]);
                        objBanner.ImageUrl = path + Uri.EscapeUriString(Convert.ToString(dr["ImageUrl"]));
                        objBanner.Sequence = Convert.ToInt32(dr["Sequence"]);
                        objBanner.Result = Convert.ToString(dr["Result"]);
                    }
                }
                return objBanner;
            }
            else { objProp.Result = "5"; }

        }
        catch (Exception ex)
        { objProp.Result = ex.Message; }
        return objBanner;
    }
    public AddToCarts EditBanner(Property objProp)
    {

        AddToCarts addcart = new AddToCarts();
        var bannerId = HttpContext.Current.Request.Form["BannerId"];
        var name = HttpContext.Current.Request.Form["BannerName"];
        var image = HttpContext.Current.Request.Form["ImageUrl"];
        var seq = HttpContext.Current.Request.Form["Sequence"];
        try
        {
            objProp.BannerId = bannerId;
            objProp.bannerName = name;
            objProp.image = Path.GetFileName(image);
            objProp.sequence = seq;

            if (objProp.bannerName != "")
            {
                objProp.DataSet = blogs.BannerUpdate(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }

        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }
    public AddToCarts AddPopupImage(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();

        var ImageName = HttpContext.Current.Request.Form["ImageName"];
        var Image = HttpContext.Current.Request.Files["image"].FileName;
        var Product = HttpContext.Current.Request.Form["Products"];
        try
        {
            objProp.ImageName = ImageName;
            objProp.image = Image.ToString();
            objProp.ProductId = Product;

            if (objProp.ImageName != "")
            {
                objProp.DataSet = blogs.CreatePopupImage(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }

        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }

    public List<PopupImage> GetPopupImageList(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["PopupImagePath"];
        string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
        List<PopupImage> objProvider = new List<PopupImage>();
        DataSet dsProvider = blogs.getPopupImageList(objProp);
        try
        {
            DataTable dtProvider = new DataTable("PopupImageList");
            dtProvider = dsProvider.Tables[0];
            var c = (from x in dtProvider.AsEnumerable()
                     select new PopupImage
                     {
                         Id = Convert.ToString(x["id"]),
                         ImageName = Convert.ToString(x["imageName"]),
                         ImageUrl = baseUrl + path + Uri.EscapeUriString(Convert.ToString(x["image"])),
                         Product = Convert.ToString(x["ProductName"]),
                         Status = Convert.ToString(x["Status"])
                     });
            objProvider = c.ToList();

        }
        catch (Exception ex)
        {
            objProp.Result = ex.Message;
        }
        return objProvider;
    }
    public AddToCarts DeletePopupImage(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["PopupImagePath"];
        AddToCarts addcart = new AddToCarts();
        try
        {
            objProp.PopupImageId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            if (objProp.PopupImageId != "")
            {
                objProp.DataSet = blogs.DeletePopupImage(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }
        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }
    public PopupImage GetPopupImageById(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["PopupImagePath"];
        PopupImage objPopupImage = new PopupImage();
        try
        {
            objProp.PopupImageId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            if (objProp.PopupImageId != "")
            {
                DataTable dtLogin = blogs.PopupImageById(objProp);
                if (dtLogin?.Rows.Count > 0)
                {
                    DataRow dr = dtLogin.Rows[0];
                    Console.WriteLine(dr);
                    if (dtLogin.Columns.Count == 2)
                    {
                        objPopupImage.Id = Convert.ToString(dr["Id"]);
                        objPopupImage.Result = Convert.ToString(dr["Result"]);
                    }
                    else
                    {
                        objPopupImage.ImageId = Convert.ToInt32(dr["Id"]);
                        objPopupImage.ImageName = Convert.ToString(dr["ImageName"]);
                        objPopupImage.ImageUrl = path + Uri.EscapeUriString(Convert.ToString(dr["ImageUrl"]));
                        objPopupImage.Product = Convert.ToString(dr["Product"]);
                        objPopupImage.Status = Convert.ToString(dr["Status"]);
                        objPopupImage.Result = Convert.ToString(dr["Result"]);
                    }
                }
                return objPopupImage;
            }
            else { objProp.Result = "5"; }

        }
        catch (Exception ex)
        { objProp.Result = ex.Message; }
        return objPopupImage;
    }
    public AddToCarts EditPopupImage(Property objProp)
    {

        AddToCarts addcart = new AddToCarts();
        var ImageId = HttpContext.Current.Request.Form["PoupImageId"];
        var ImageName = HttpContext.Current.Request.Form["ImageName"];
        var Image = HttpContext.Current.Request.Form["ImageUrl"];
        var ProductId = HttpContext.Current.Request.Form["Product"];
        var Status = HttpContext.Current.Request.Form["Status"];
        try
        {
            objProp.PopupImageId = ImageId;
            objProp.ImageName = ImageName;
            objProp.image = Path.GetFileName(Image);
            objProp.ProductId = ProductId;
            objProp.Status = Status;

            if (objProp.ImageName != "")
            {
                objProp.DataSet = blogs.PopupImageUpdate(objProp);
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
                return addcart;
            }
            else { addcart.Result = "5"; }

        }

        catch (Exception ex)
        { addcart.Result = ex.Message; }
        return addcart;
    }
    public ProductListRoot GetProductById(Property objProp)
    {
        string path = ConfigurationManager.AppSettings["ProductPath"];
        string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
        ProductListRoot objProduct = new ProductListRoot();
        try
        {
            objProp.ProductId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            if (objProp.ProductId != "")
            {
                DataTable dtLogin = blogs.ProductById(objProp);
                if (dtLogin?.Rows.Count > 0)
                {
                    DataRow dr = dtLogin.Rows[0];
                    Console.WriteLine(dr);
                    if (dtLogin.Columns.Count == 2)
                    {
                        objProduct.Id = Convert.ToString(dr["id"]);
                        objProduct.Result = Convert.ToString(dr["Result"]);
                    }
                    else
                    {
                        //objProduct.ProductId = Convert.ToString(dr["ProductId"]);
                        //objProduct.ItemCode = Convert.ToString(dr["ItemCode"]);
                        //objProduct.ItemName = Convert.ToString(dr["ItemName"]);
                        //objProduct.FrgnName = Convert.ToString(dr["FrgnName"]);
                        //objProduct.OnHand = Convert.ToString(dr["OnHand"]);
                        //objProduct.Available = Convert.ToString(dr["Available"]);
                        //objProduct.MRP = Convert.ToString(dr["MRP"]);
                        //objProduct.GST = Convert.ToString(dr["F_1"]);
                        //objProduct.PTR = Convert.ToString(dr["F_2"]);
                        //objProduct.F_3 = Convert.ToString(dr["F_3"]);
                        //objProduct.F_4 = Utils.FormatProductF4(Convert.ToString(dr["F_4"]));
                        //objProduct.F_5 = Convert.ToString(dr["F_5"]);
                        //objProduct.Image = baseUrl + path + Convert.ToString(dr["ImageUrl"]);
                        objProduct = MapProductList(dr, baseUrl, path);
                    }
                }
                return objProduct;
            }
            else { objProp.Result = "5"; }

        }
        catch (Exception ex)
        { objProp.Result = ex.Message; }
        return objProduct;
    }
    public ResponseModel<bool> EditProduct(Property objProp)
    {

        ResponseModel<bool> response;

        try
        {

            //AddToCarts addcart = new AddToCarts();
            var ProductId = HttpContext.Current.Request.Form["ProductId"];
            var ItemCode = HttpContext.Current.Request.Form["ItemCode"];
            var ItemName = HttpContext.Current.Request.Form["ItemName"];
            var FrgnName = HttpContext.Current.Request.Form["FrgnName"];
            var OnHand = HttpContext.Current.Request.Form["OnHand"];
            var Available = HttpContext.Current.Request.Form["Available"];
            var MRP = HttpContext.Current.Request.Form["MRP"];
            var F1 = HttpContext.Current.Request.Form["F_1"];
            var F2 = HttpContext.Current.Request.Form["F_2"];
            var F3 = HttpContext.Current.Request.Form["F_3"];
            var F4 = HttpContext.Current.Request.Form["F_4"];
            var F5 = HttpContext.Current.Request.Form["F_5"];
            var ImageUrl = HttpContext.Current.Request.Form["ImageUrl"];
            var categoryIds = HttpContext.Current.Request.Form["categoryIds"];
            //var Image = HttpContext.Current.Request.Files["Image"];


            objProp.ProductId = ProductId;
            objProp.ItemCode = ItemCode;
            objProp.ItemName = ItemName;
            objProp.FrgnName = FrgnName;
            objProp.OnHand = OnHand;
            objProp.Available = Available;
            objProp.mrp = MRP;
            objProp.F1 = F1;
            objProp.F2 = F2;
            objProp.F3 = F3;
            objProp.F4 = F4;
            objProp.F5 = F5;
            objProp.image = ImageUrl;




            if (objProp.ProductId == "")
            {
                response = new ResponseModel<bool>("ProductId is required");
            }

            else
            {
                objProp.DataSet = blogs.ProductUpdate(objProp, categoryIds ?? "");

                response = new ResponseModel<bool>(true, "Successfully Edit product");
            }

        }

        catch (Exception ex)
        {
            response = new ResponseModel<bool>(ex.Message);
        }
        return response;
    }

    public OfferListRoot EditOffer(Property objProp)
    {
        OfferListRoot offerlist = new OfferListRoot();

        var offerId = HttpContext.Current.Request.Form["id"];
        var name = HttpContext.Current.Request.Form["name"];
        var description = HttpContext.Current.Request.Form["description"];
        var fromDate = HttpContext.Current.Request.Form["fromDate"];
        var toDate = HttpContext.Current.Request.Form["toDate"];
        var eligibilityQty = HttpContext.Current.Request.Form["eligibilityQty"];
        var offerQty = HttpContext.Current.Request.Form["offerQty"];
        var status = HttpContext.Current.Request.Form["status"];
        var createdby = HttpContext.Current.Request.Form["createdBy"];
        var updatedby = HttpContext.Current.Request.Form["updatedBy"];
        if (HttpContext.Current.Request.Files.Count > 0)
        {
            var image = HttpContext.Current.Request.Files["image"].FileName;
            objProp.image = image;
        }
        List<int> productIds = GetProductIdsFromForm();
        try
        {
            objProp.Offer_Id = Convert.ToInt32(offerId);
            objProp.Offer_Name = name;
            objProp.Offer_Description = description;
            objProp.From_Date = Convert.ToDateTime(fromDate);
            objProp.To_Date = Convert.ToDateTime(toDate);
            objProp.Eligibility_Qty = Convert.ToString(eligibilityQty);
            objProp.Offer_Qty = Convert.ToString(offerQty);
            objProp.Offer_Status = Convert.ToInt32(status);
            objProp.CreatedBy = createdby;
            objProp.CreatedDate = DateTime.Now;
            objProp.UpdatedBy = updatedby;
            objProp.UpdatedDate = DateTime.Now;
            //objProp.image = image;

            if (objProp.Offer_Id != 0)
            {
                objProp.ProductIds = productIds;

                objProp.DataSet = blogs.OfferUpdate(objProp);

                if (objProp.DataSet.Tables[0].Rows.Count > 0)
                {
                    if (objProp.DataSet.Tables[0].Rows[0]["id"].ToString() == "Y")
                    {
                        offerlist.OfferId = objProp.Offer_Id.ToString();
                        offerlist.OfferName = objProp.Offer_Name;
                        offerlist.Description = objProp.Offer_Description;
                        offerlist.FromDate = objProp.From_Date.ToString("yyyy/MM/dd");
                        offerlist.ToDate = objProp.To_Date.ToString("yyyy/MM/dd");
                        offerlist.EligibilityQty = objProp.Eligibility_Qty;
                        offerlist.OfferQty = objProp.Offer_Qty;
                        if (objProp.Offer_Status == 1)
                        {
                            offerlist.offerstatus = "Active";
                        }
                        else if (objProp.Offer_Status == 2)
                        {
                            offerlist.offerstatus = "Deactive";
                        }
                        else
                        {
                            offerlist.offerstatus = "status not found";
                        }
                        offerlist.Status = "Success";
                        offerlist.Result = objProp.DataSet.Tables[0].Rows[0]["desc"].ToString();
                    }
                    else
                    {
                        offerlist.Status = "Fail";
                        offerlist.Result = objProp.DataSet.Tables[0].Rows[0]["desc"].ToString();
                    }
                }
                return offerlist;
            }
            else
            {
                offerlist.Result = "5";
            }
        }
        catch (Exception ex)
        {
            offerlist.Result = ex.Message;
        }

        return offerlist;
    }
    public OfferListRoot DeleteOffer(Property objProp)
    {
        OfferListRoot offerlist = new OfferListRoot();

        try
        {
            var offerId = HttpContext.Current.Request.Form["id"];

            if (!string.IsNullOrEmpty(offerId))
            {
                objProp.Offer_Id = Convert.ToInt32(offerId);
                objProp.Offer_Name = objProp.Offer_Name;
                objProp.Offer_Description = objProp.Offer_Description;
                objProp.From_Date = Convert.ToDateTime(objProp.From_Date);
                objProp.To_Date = Convert.ToDateTime(objProp.To_Date);
                objProp.Eligibility_Qty = Convert.ToString(objProp.Eligibility_Qty);
                objProp.Offer_Qty = Convert.ToString(objProp.Offer_Qty);
                objProp.Offer_Status = Convert.ToInt32(objProp.Offer_Status);
                objProp.DataSet = blogs.OfferDelete(objProp);

                if (objProp.DataSet.Tables[0].Rows.Count > 0)
                {
                    if (objProp.DataSet.Tables[0].Rows[0]["id"].ToString() == "Y")
                    {
                        offerlist.OfferId = objProp.Offer_Id.ToString();
                        offerlist.Description = objProp.Offer_Description;
                        offerlist.FromDate = objProp.From_Date.ToString("yyyy/MM/dd");
                        offerlist.ToDate = objProp.To_Date.ToString("yyyy/MM/dd");
                        offerlist.EligibilityQty = objProp.Eligibility_Qty;
                        offerlist.OfferQty = objProp.Offer_Qty;
                        offerlist.offerstatus = objProp.Offer_Status.ToString();
                        offerlist.Status = "Success";
                        offerlist.Result = objProp.DataSet.Tables[0].Rows[0]["desc"].ToString();
                    }
                    else
                    {
                        offerlist.Status = "Fail";
                        offerlist.Result = objProp.DataSet.Tables[0].Rows[0]["desc"].ToString();
                    }
                }
            }
            else
            {
                offerlist.Result = "Invalid Offer ID";
            }
        }
        catch (Exception ex)
        {
            offerlist.Result = ex.Message;
        }

        return offerlist;
    }


    public AddToCarts GetAllProducts(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        ProductListRoot prodListRoot = new ProductListRoot();
        string contentData = HttpContext.Current.Request.Form["contentData"];
        try
        {
            ArrayList testarray = JsonConvert.DeserializeObject<ArrayList>(contentData);
            string leng = testarray.Count.ToString();
            int chunkSize = 500; // Set the chunk size
            List<ProductListRoot> chunkList = new List<ProductListRoot>();

            for (int i = 0; i < testarray.Count; i += chunkSize)
            {
                // Clear the chunk list for the next set of items
                chunkList.Clear();

                // Iterate over the chunk of items
                for (int j = i; j < Math.Min(i + chunkSize, testarray.Count); j++)
                {
                    string item = testarray[j].ToString();
                    prodListRoot = JsonConvert.DeserializeObject<ProductListRoot>(item);
                    objProp.ItemCode = prodListRoot.ItemCode;
                    objProp.ItemName = prodListRoot.ItemName;
                    objProp.FrgnName = prodListRoot.FrgnName;
                    objProp.OnHand = prodListRoot.OnHand;
                    objProp.Available = prodListRoot.Available;
                    objProp.MRP = prodListRoot.MRP;
                    objProp.F1 = prodListRoot.F_1;
                    objProp.F2 = prodListRoot.F_2;
                    objProp.F3 = prodListRoot.F_3;
                    objProp.F4 = prodListRoot.F_4;
                    objProp.F5 = prodListRoot.F_5;

                    chunkList.Add(new ProductListRoot
                    {
                        ItemCode = objProp.ItemCode,
                        ItemName = objProp.ItemName,
                        FrgnName = objProp.FrgnName,
                        OnHand = objProp.OnHand,
                        Available = objProp.Available,
                        MRP = objProp.MRP,
                        F_1 = objProp.F1,
                        F_2 = objProp.F2,
                        F_3 = objProp.F3,
                        F_4 = Utils.FormatProductF4(objProp.F4),
                        F_5 = objProp.F5,
                    });
                }

                // Call the stored procedure with the current chunk
                objProp.DataSet = blogs.ProductList(chunkList);
            }

            addcart.Status = "Success";
            addcart.Result = "Items processed successfully";

            return addcart;
        }
        catch (Exception ex)
        {
            addcart.Result = ex.Message;
        }

        return addcart;
    }
    public OrdersList GetOrderDetailsById(Property objProp)
    {
        AddToCarts addcart = new AddToCarts();
        OrdersList objOrder = new OrdersList();
        List<ProductDetails> itemListData = new List<ProductDetails>();
        try
        {
            objProp.orderId = objProp.SplitValueEncode[1].Split('=')[1].ToString().Trim();
            if (objProp.orderId != "")
            {
                DataTable dtLogin = blogs.OrderDetailsById(objProp);
                DataSet dsProviders = blogs.GetOrderList(objProp);
                DataTable dtProviders = new DataTable("ProductList");
                dtProviders = dsProviders.Tables[0];
                if (dtLogin?.Rows.Count > 0)
                {
                    DataRow dr = dtLogin.Rows[0];
                    Console.WriteLine(dr);
                    if (dtLogin.Columns.Count == 2)
                    {
                        objOrder.id = Convert.ToString(dr["id"]);
                        objOrder.Result = Convert.ToString(dr["Result"]);
                    }
                    else
                    {
                        if (dtProviders.Rows[0]["id"].ToString() == "Y")
                        {
                            itemListData = (from x in dtProviders.AsEnumerable()
                                            select new ProductDetails
                                            {
                                                OrderID = Convert.ToString(x["orderID"]),
                                                ProductName = Convert.ToString(x["ProductName"]),
                                                Count = Convert.ToInt32(x["Counts"]),
                                                MRP = Convert.ToString(x["mrp"]),
                                                Date = Convert.ToString(x["Date"]),
                                                Tamount = Convert.ToString(x["Tamount"]),
                                                GST = Convert.ToString(x["gst"]),
                                                PTR = Convert.ToString(x["ptr"]),
                                                OfferedQTY = Convert.ToString(x["offer_qty"]),
                                            }).ToList();
                        }
                        else
                        {
                            addcart.Status = "Fail";
                            addcart.Result = objProp.DataSet.Tables[0].Rows[0]["Result"].ToString();
                        }
                        objOrder.OrderID = Convert.ToString(dr["OrderID"]);
                        objOrder.SalesQuotation = Convert.ToString(dr["SaleQuotation"]);
                        objOrder.StoreCode = Convert.ToString(dr["StoreCode"]);
                        objOrder.StoreName = Convert.ToString(dr["StoreName"]);
                        objOrder.BillDate = Convert.ToString(dr["OrderDate"]);
                        objOrder.ShipDate = Convert.ToString(dr["OrderInDate"]);
                        objOrder.TotalAmount = Convert.ToString(dr["TotalAmount"]);
                        objOrder.Result = Convert.ToString(dr["Result"]);
                        objOrder.Productdetails = itemListData;

                    }
                }
                return objOrder;
            }
            else { objProp.Result = "5"; }

        }
        catch (Exception ex)
        { objProp.Result = "2"; }
        return objOrder;
    }

    public ResponseModel<CategoryModel> AddCategory(Property objProp)
    {
        ResponseModel<CategoryModel> response = null;
        try
        {
            var image = HttpContext.Current.Request.Files["image"];
            string name = HttpContext.Current.Request.Form["name"];
            DateTime createdDate = DateTime.Now;
            DateTime updateDate = DateTime.Now;

            if (string.IsNullOrEmpty(name))
            {
                response = new ResponseModel<CategoryModel>("Category name is required");
                return response;
            }

            CategoryModel category = new CategoryModel
            {
                Name = name,
                Image = Utils.SaveRequestedImage(image, "CategoryPath"),
                createdAt = createdDate,
                updatedAt = updateDate
            };

            blogs.AddCategory(category);

            response = new ResponseModel<CategoryModel>(category, "Category add successfully.");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<CategoryModel>(ex.Message);
        }
        return response;
    }

    // edit category
    public ResponseModel<CategoryModel> EditCategory(Property objProp)
    {
        ResponseModel<CategoryModel> response = null;
        try
        {
            var image = HttpContext.Current.Request.Files["image"];
            string name = HttpContext.Current.Request.Form["name"];
            string id = HttpContext.Current.Request.Form["id"];
            string imageUrl = HttpContext.Current.Request.Form["url"];

            if (string.IsNullOrEmpty(name))
            {
                response = new ResponseModel<CategoryModel>("Category name is required");
                return response;
            }

            CategoryModel category = new CategoryModel
            {
                Id = Convert.ToInt32(id),
                Name = name,
                Image = Utils.SaveRequestedImage(image, "CategoryPath"),
                updatedAt = DateTime.Now
            };

            blogs.UpdateCategory(category);

            response = new ResponseModel<CategoryModel>(category, "Category add successfully.");
        }
        catch(Exception ex)
        {
            response = new ResponseModel<CategoryModel>(ex.Message);
        }
        return response;
    }


    public ResponseModel<bool> DeleteCategory(Property objProp)
    {
        ResponseModel<bool> response;
        try
        {
            int categoryId = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "categoryId", 0);
            if (categoryId == 0)
            {
                response = new ResponseModel<bool>("Category Id is required");
                return response;
            }

            blogs.DeleteCategory(categoryId);
            response = new ResponseModel<bool>(true, "Category delete successfully.");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<bool>(ex.Message);
        }
        return response;
    }
    // get all categories
    public ResponseModel<List<CategoryModel>> GetCategories(Property objProp)
    {
        try
        {
            // Fetch data
            DataSet data = blogs.GetCategories();
            if (data == null || data.Tables.Count == 0 || data.Tables[0].Rows.Count == 0)
            {
                return new ResponseModel<List<CategoryModel>>(new List<CategoryModel>(), "No categories found");
            }

            // Retrieve configurations
            string path = ConfigurationManager.AppSettings["CategoryPath"];
            string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";

            // Convert data to CategoryModel
            var categories = data.Tables[0].AsEnumerable().Select(row => new CategoryModel
            {
                Id = row.Field<int>("Id"),
                Name = row.Field<string>("Name"),
                Image = $"{baseUrl}{path}{row.Field<string>("Image")}",
                IsActive = row.Field<bool>("IsActive"),
                createdAt = row.Field<DateTime>("CreatedAt"),
                updatedAt = row.Field<DateTime>("UpdatedAt")
            }).ToList();

            // Return successful response
            return new ResponseModel<List<CategoryModel>>(categories, "Categories fetched successfully");
        }
        catch (Exception ex)
        {
            // Handle exceptions gracefully
            return new ResponseModel<List<CategoryModel>>(ex.Message);
        }
    }

    // get category by id
    public ResponseModel<CategoryModel> GetCategoryById(Property objProp)
    {
        ResponseModel<CategoryModel> response = null;
        try
        {
            string categoryId = Utils.GetEncodeValue<string>(objProp.SplitValueEncode, "categoryId", "");
            if (string.IsNullOrEmpty(categoryId))
            {
                response = new ResponseModel<CategoryModel>("Category Id is required");
                return response;
            }
            DataSet data = blogs.GetCategoryById(Convert.ToInt32(categoryId));
            if (data == null || data.Tables.Count == 0 || data.Tables[0].Rows.Count == 0)
            {
                return new ResponseModel<CategoryModel>(new CategoryModel(), "No categories found");
            }

            // Retrieve configurations
            string path = ConfigurationManager.AppSettings["CategoryPath"];
            string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";

            // Convert data to CategoryModel
            var category = data.Tables[0].AsEnumerable().Select(row => new CategoryModel
            {
                Id = row.Field<int>("Id"),
                Name = row.Field<string>("Name"),
                Image = $"{baseUrl}{path}{row.Field<string>("Image")}",
                IsActive = row.Field<bool>("IsActive"),
                createdAt = row.Field<DateTime>("CreatedAt"),
                updatedAt = row.Field<DateTime>("UpdatedAt")
            }).First();
            response = new ResponseModel<CategoryModel>(category, "Category fetched successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<CategoryModel>(ex.Message);
        }
        return response;
    }

    // get all products by category id
    public ResponseModel<List<ProductListRoot>> GetProductByCategoryId(Property objProp)
    {
        ResponseModel<List<ProductListRoot>> response = null;
        try
        {
            string categoryId = Utils.GetEncodeValue<string>(objProp.SplitValueEncode, "categoryId", "");
            if (string.IsNullOrEmpty(categoryId))
            {
                response = new ResponseModel<List<ProductListRoot>>("Category Id is required");
                return response;
            }
            DataSet data = blogs.GetProductsByCategoryId(Convert.ToInt32(categoryId));
            string path = ConfigurationManager.AppSettings["ProductPath"];
            string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
            var products = data.Tables[0]
                           .AsEnumerable()
                           .Select(x => MapProductList(x, baseUrl, path))
                           .ToList();
            response = new ResponseModel<List<ProductListRoot>>(products, "Products fetched successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<List<ProductListRoot>>(ex.Message);
        }
        return response;
    }

    public ResponseModel<bool> AddProductInOrderSheet(Property objProp)
    {
        ResponseModel<bool> response = null;
        try
        {
            int userId = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "userId", 0);
            int productId = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "productId", 0);

            if (userId == 0)
            {
                response = new ResponseModel<bool>("User Id is required");
                return response;
            }
            if (productId == 0)
            {
                response = new ResponseModel<bool>("Product Id is required");
                return response;
            }

            blogs.AddProductInOrderSheet(userId, productId);
            response = new ResponseModel<bool>(true, "Product added successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<bool>(ex.Message);
        }

        return response;
    }

    public ResponseModel<List<ProductListRoot>> GetOrderSheet(Property objProp)
    {
        ResponseModel<List<ProductListRoot>> response = null;
        try
        {
            int userId = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "userId", 0);
            if (userId == 0)
            {
                response = new ResponseModel<List<ProductListRoot>>("User Id is required");
                return response;
            }
            DataSet data = blogs.GetOrderSheet(userId);
            string path = ConfigurationManager.AppSettings["ProductPath"];
            string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
            var products = data.Tables[0]
                           .AsEnumerable()
                           .Select(x => MapProductList(x, baseUrl, path))
                           .ToList();
            response = new ResponseModel<List<ProductListRoot>>(products, "Products fetched successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<List<ProductListRoot>>(ex.Message);
        }
        return response;
    }

    public ResponseModel<bool> RemoveProductFromOrderSheet(Property objProp)
    {
        ResponseModel<bool> response = null;
        try
        {
            int userId = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "userId", 0);
            int productId = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "productId", 0);
            if (userId == 0)
            {
                response = new ResponseModel<bool>("User Id is required");
                return response;
            }
            if (productId == 0)
            {
                response = new ResponseModel<bool>("Product Id is required");
                return response;
            }
            blogs.RemoveProductFromOrderSheet(userId, productId);
            response = new ResponseModel<bool>(true, "Product removed successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<bool>(ex.Message);
        }
        return response;
    }

    public ResponseModel<bool> AddProductRequst(Property objProp)
    {
        ResponseModel<bool> response = null;
        try
        {
            var image = HttpContext.Current.Request.Files["image"];
            int userId = Convert.ToInt16(HttpContext.Current.Request.Form["userId"].ToString());
            string composition = HttpContext.Current.Request.Form["composition"];
            if (userId == 0)
            {
                response = new ResponseModel<bool>("User Id is required");
                return response;
            }
            if (string.IsNullOrEmpty(composition))
            {
                response = new ResponseModel<bool>("composition is required");
                return response;
            }

            string imgPath = "";

            if (image != null)
            {
                imgPath = Utils.SaveRequestedImage(image, "ProductRequestPath");
            }


            blogs.AddProductRequest(userId, composition, imgPath);
            response = new ResponseModel<bool>(true, "Product request added successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<bool>(ex.Message);
        }
        return response;
    }

    public ResponseModel<bool> DeleteProductRequest(Property objProp)
    {
        ResponseModel<bool> response = null;
        try
        {
            int id = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "id", 0);
            if (id == 0)
            {
                response = new ResponseModel<bool>("User Id is required");
                return response;
            }


            blogs.DeleteProductRequest(id);
            response = new ResponseModel<bool>(true, "Product request added successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<bool>(ex.Message);
        }
        return response;
    }



    public ResponseModel<List<ProductRequestModel>> GetProductRequests(Property objProp)
    {
        ResponseModel<List<ProductRequestModel>> response = null;
        try
        {
            DataSet data = blogs.GetProductRequests();
            if (data == null || data.Tables.Count == 0 || data.Tables[0].Rows.Count == 0)
            {
                return new ResponseModel<List<ProductRequestModel>>(new List<ProductRequestModel>(), "No product requests found");
            }
            string path = ConfigurationManager.AppSettings["ProductRequestPath"];
            string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
            var requests = data.Tables[0]
                           .AsEnumerable()
                           .Select(x => new ProductRequestModel
                           {
                               Id = Convert.ToInt32(x["Id"]),
                               UserId = Convert.ToInt32(x["UserId"]),
                               Composition = Convert.ToString(x["Composition"]),
                               Image = $"{baseUrl}{path}{x["Image"]}",
                               CreatedAt = Convert.ToDateTime(x["CreatedAt"])
                           })
                           .ToList();
            response = new ResponseModel<List<ProductRequestModel>>(requests, "Product requests fetched successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<List<ProductRequestModel>>(ex.Message);
        }
        return response;
    }


    public ResponseModel<bool> OrderSheetToCart(Property objProp)
    {
        ResponseModel<bool> response = null;
        try
        {
            int userId = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "userId", 0);
            if (userId == 0)
            {
                response = new ResponseModel<bool>("User Id is required");
                return response;
            }
            blogs.OrderSheetToCart(userId);
            response = new ResponseModel<bool>(true, "Order sheet transferred to cart successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<bool>(ex.Message);
        }
        return response;
    }

    public ResponseModel<List<ProductListRoot>> getReorderProducts(Property objProp)
    {
        ResponseModel<List<ProductListRoot>> response = null;
        try
        {
            string orderId = Utils.GetEncodeValue<string>(objProp.SplitValueEncode, "orderId", "");
            if (string.IsNullOrWhiteSpace(orderId))
            {
                response = new ResponseModel<List<ProductListRoot>>("OrderId is required");
                return response;
            }
            DataSet data = blogs.GetReorderProducts(orderId);
            string path = ConfigurationManager.AppSettings["ProductPath"];
            string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
            var products = data.Tables[0]
                           .AsEnumerable()
                           .Select(x => MapProductList(x, baseUrl, path))
                           .ToList();
            response = new ResponseModel<List<ProductListRoot>>(products, "Products fetched successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<List<ProductListRoot>>(ex.Message);
        }
        return response;
    }

    public ResponseModel<GiftSchemeModel> AddGiftScheme(Property objProp)
    {
        ResponseModel<GiftSchemeModel> response = null;
        try
        {
            var image = HttpContext.Current.Request.Files["image"];
            string name = HttpContext.Current.Request.Form["name"];
            string description = HttpContext.Current.Request.Form["description"];
            string fromDate = HttpContext.Current.Request.Form["fromDate"];
            string toDate = HttpContext.Current.Request.Form["toDate"];
            string eligibilityAmount = HttpContext.Current.Request.Form["eligibilityAmount"];
            string excludedProducts = HttpContext.Current.Request.Form["excludedProducts"];
            string offer = HttpContext.Current.Request.Form["offer"];

            DateTime createdDate = DateTime.Now;
            DateTime updateDate = DateTime.Now;

            GiftSchemeModel giftScheme = new GiftSchemeModel()
            {
                Name = name,
                Description = description,
                Image = Utils.SaveRequestedImage(image, "GiftSchemePath"),
                FromDate = Convert.ToDateTime(fromDate),
                ToDate = Convert.ToDateTime(toDate),
                EligibilityAmount = Convert.ToInt32(eligibilityAmount),
                Offer = offer,
                ExcludedProducts = excludedProducts,
                CreatedAt = createdDate,
                UpdatedAt = updateDate
            };

            blogs.AddGiftScheme(giftScheme);

            response = new ResponseModel<GiftSchemeModel>(giftScheme, "Gift scheme added successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<GiftSchemeModel>(ex.Message);
        }
        return response;
    }

    public ResponseModel<bool> DeleteGiftScheme(Property objProp)
    {
        ResponseModel<bool> response = null;
        try
        {
            int id = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "id", 0);
            if (id == 0)
            {
                response = new ResponseModel<bool>("Gift Scheme Id is required");
                return response;
            }
            blogs.DeleteGiftScheme(id);
            response = new ResponseModel<bool>(true, "Gift scheme deleted successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<bool>(ex.Message);
        }
        return response;
    }

    public ResponseModel<List<GiftSchemeModel>> GetGiftSchemes(Property objProp)
    {
        ResponseModel<List<GiftSchemeModel>> response = null;
        try
        {
            DataSet data = blogs.GetGiftSchemes();
            if (data == null || data.Tables.Count == 0 || data.Tables[0].Rows.Count == 0)
            {
                return new ResponseModel<List<GiftSchemeModel>>(new List<GiftSchemeModel>(), "No gift schemes found");
            }
            string path = ConfigurationManager.AppSettings["GiftSchemePath"];
            string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
            var giftSchemes = data.Tables[0]
                           .AsEnumerable()
                           .Select(x => new GiftSchemeModel
                           {
                               Id = Convert.ToInt32(x["Id"]),
                               Name = Convert.ToString(x["name"]),
                               Description = Convert.ToString(x["description"]),
                               Image = $"{baseUrl}{path}{x["image"]}",
                               FromDate = Convert.ToDateTime(x["fromDate"]),
                               ToDate = Convert.ToDateTime(x["toDate"]),
                               EligibilityAmount = Convert.ToInt32(x["eligibilityAmount"]),
                               Offer = Convert.ToString(x["offer"]),
                               ExcludedProducts = Convert.ToString(x["excludedProducts"]),
                               CreatedAt = Convert.ToDateTime(x["createdAt"]),
                               UpdatedAt = Convert.ToDateTime(x["updatedAt"])
                           })
                           .ToList();
            response = new ResponseModel<List<GiftSchemeModel>>(giftSchemes, "Gift schemes fetched successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<List<GiftSchemeModel>>(ex.Message);
        }
        return response;
    }

    public ResponseModel<GiftSchemeModel> GetGiftSchemeById(Property objProp)
    {
        ResponseModel<GiftSchemeModel> response = null;
        try
        {
            int id = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "id", 0);
            if (id == 0)
            {
                response = new ResponseModel<GiftSchemeModel>("No gift schemes found");
            }
            DataSet data = blogs.GetGiftSchemeById(id);
            if (data == null || data.Tables.Count == 0 || data.Tables[0].Rows.Count == 0)
            {
                return new ResponseModel<GiftSchemeModel>("No gift schemes found");
            }
            string path = ConfigurationManager.AppSettings["GiftSchemePath"];
            string baseUrl = $"http://{HttpContext.Current.Request.Url.Authority}/";
            var giftSchemes = data.Tables[0]
                           .AsEnumerable()
                           .Select(x => new GiftSchemeModel
                           {
                               Id = Convert.ToInt32(x["Id"]),
                               Name = Convert.ToString(x["name"]),
                               Description = Convert.ToString(x["description"]),
                               Image = $"{baseUrl}{path}{x["image"]}",
                               FromDate = Convert.ToDateTime(x["fromDate"]),
                               ToDate = Convert.ToDateTime(x["toDate"]),
                               EligibilityAmount = Convert.ToInt32(x["eligibilityAmount"]),
                               Offer = Convert.ToString(x["offer"]),
                               ExcludedProducts = Convert.ToString(x["excludedProducts"]),
                               CreatedAt = Convert.ToDateTime(x["createdAt"]),
                               UpdatedAt = Convert.ToDateTime(x["updatedAt"])
                           })
                           .ToList();
            response = new ResponseModel<GiftSchemeModel>(giftSchemes[0], "Gift schemes fetched successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<GiftSchemeModel>(ex.Message);
        }
        return response;
    }

    public ResponseModel<GiftSchemeModel> UpdateGiftScheme(Property objProp)
    {
        ResponseModel<GiftSchemeModel> response = null;
        try
        {
            var image = HttpContext.Current.Request.Files["image"];
            int id = Convert.ToInt32(HttpContext.Current.Request.Form["id"]);
            string name = HttpContext.Current.Request.Form["name"];
            string description = HttpContext.Current.Request.Form["description"];
            string fromDate = HttpContext.Current.Request.Form["fromDate"];
            string toDate = HttpContext.Current.Request.Form["toDate"];
            string eligibilityAmount = HttpContext.Current.Request.Form["eligibilityAmount"];
            string excludedProducts = HttpContext.Current.Request.Form["excludedProducts"];
            string offer = HttpContext.Current.Request.Form["offer"];
            DateTime createdDate = DateTime.Now;
            DateTime updateDate = DateTime.Now;
            GiftSchemeModel giftScheme = new GiftSchemeModel()
            {
                Id = id,
                Name = name,
                Description = description,
                Image = Utils.SaveRequestedImage(image, "GiftSchemePath"),
                FromDate = Convert.ToDateTime(fromDate),
                ToDate = Convert.ToDateTime(toDate),
                EligibilityAmount = Convert.ToInt32(eligibilityAmount),
                Offer = offer,
                ExcludedProducts = excludedProducts,
                CreatedAt = createdDate,
                UpdatedAt = updateDate
            };
            blogs.UpdateGiftScheme(giftScheme);
            response = new ResponseModel<GiftSchemeModel>(giftScheme, "Gift scheme updated successfully");
        }
        catch (Exception ex)
        {
            response = new ResponseModel<GiftSchemeModel>(ex.Message);
        }
        return response;
    }


    public ResponseModel<Dictionary<string, string>> CreateOrder(Property objProp)
    {
        ResponseModel<Dictionary<string, string>> response = null;
        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            int userId = Utils.GetEncodeValue<int>(objProp.SplitValueEncode, "userId", 0);
            string userName = Utils.GetEncodeValue<string>(objProp.SplitValueEncode, "userName", "");
            string userNumber = Utils.GetEncodeValue<string>(objProp.SplitValueEncode, "userNumber", "");
            double amount = Utils.GetEncodeValue<double>(objProp.SplitValueEncode, "amount", 0);

            if (userId == 0)
            {
                response = new ResponseModel<Dictionary<string, string>>("User Id is required");
                return response;
            }
            
            if (string.IsNullOrEmpty(userName))
            {
                response = new ResponseModel<Dictionary<string, string>>("userName is required");
                return response;
            }

            if (string.IsNullOrEmpty(userNumber))
            {
                response = new ResponseModel<Dictionary<string, string>>("userNumber is required");
                return response;
            }

            if (amount < 1)
            {
                response = new ResponseModel<Dictionary<string, string>>("amount should be greater than 0.");
                return response;
            }
            try
            {
                var result = PaymentGatewayService.CreateOrder(userName, userNumber, amount);
                Dictionary<string, string> res = new Dictionary<string, string>();
                res.Add("orderId", result.order_id);
                res.Add("sessionId", result.payment_session_id);
                response = new ResponseModel<Dictionary<string, string>>(res, "");
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception when calling PGCreateOrder: " + e.Message);
                Console.WriteLine("Status Code: " + e.ErrorCode);
                Console.WriteLine(e.StackTrace);
                response = new ResponseModel<Dictionary<string, string>>(e.Message);
            }
            //blogs.CreateOrder(userId);
            
        }
        catch (Exception ex)
        {
            response = new ResponseModel<Dictionary<string, string>>(ex.Message);
        }
        return response;
    }

    public ResponseModel<OrderEntity> VerifyPayment(Property objProp)
    {
        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string orderId = Utils.GetEncodeValue<string>(objProp.SplitValueEncode, "orderId", "");
            if (string.IsNullOrEmpty(orderId))
            {
                return new ResponseModel<OrderEntity>("orderId is required.") ;
            }
            Cashfree.XClientId = "TEST10437818e09024c9be7f3f5fe43581873401";
            Cashfree.XClientSecret = "cfsk_ma_test_72582f14312271ea5b355a78350db1ff_e17c5789";
            Cashfree.XEnvironment = Cashfree.SANDBOX;
            var cashfree = new Cashfree();
            var xApiVersion = "2022-09-01";

            var result = cashfree.PGFetchOrder(xApiVersion, orderId, null, null);

            return new ResponseModel<OrderEntity>(result.Content as OrderEntity, "Fetch successfull");

        }
        catch (Exception ex)
        {
            return new ResponseModel<OrderEntity>(ex.Message);
        }

    }

    private ProductListRoot MapProductList(DataRow data, string baseUrl, string path)
    {
        return new ProductListRoot
        {
            ProductId = Convert.ToString(data["pk_product_id"]),
            ItemCode = Convert.ToString(data["ItemCode"]),
            ItemName = Convert.ToString(data["ItemName"]),
            FrgnName = Convert.ToString(data["FrgnName"]),
            OnHand = Convert.ToString(data["OnHand"]),
            Available = Convert.ToString(data["Available"]),
            MRP = Convert.ToString(data["MRP"]),
            GST = Convert.ToString(data["F_1"]),
            PTR = Convert.ToString(data["F_2"]),
            F_3 = Convert.ToString(data["F_3"]),
            F_4 = Utils.FormatProductF4(Convert.ToString(data["F_4"])),
            F_5 = Convert.ToString(data["F_5"]),
            Image = baseUrl + path + Convert.ToString(data["prod_images"]),
            Categories = data.Table.Columns.Contains("Category") ? JsonConvert.DeserializeObject<List<CategoryModel>>(Convert.ToString(data["Category"])) : null,
            Offers = data.Table.Columns.Contains("offers") ? Convert.ToString(data["offers"]) : ""
        };
    }


    public class ResponseModel<T>
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public T data { get; set; }

        // error response model
        public ResponseModel(string message)
        {
            Error = true;
            Message = message;
        }

        // success response model
        public ResponseModel(T data, string message)
        {
            Error = false;
            Message = message;
            this.data = data;
        }
    }

    public class Emailmodel
    {
        public string Status { get; set; }
        public string Result { get; set; }
    }
    public class Product
    {
        public int ODID { get; set; }
        public int pid { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public string MRP { get; set; }
        public string PTR { get; set; }
        public string GST { get; set; }
        public string Offer_Qty { get; set; }
        public string Status { get; set; }
        public string Tamount { get; set; }
        public string OrderID { get; set; }
        public string Date { get; set; }
        public string image { get; set; }
    }

    public class ProductOrder
    {
        public string OrderID { get; set; }
        public string Date { get; set; }
        public int totalamount { get; set; }
        public int Totality { get; set; }
        public string SalesQuotation { get; set; }
        public List<Product> Products { get; set; }
    }

    public class ProductDetails
    {
        public int ODID { get; set; }
        public int pid { get; set; }
        public string OrderID { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public string MRP { get; set; }
        public string PTR { get; set; }
        public string GST { get; set; }
        public string Offer { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public string Tamount { get; set; }
        public string OfferedQTY { get; set; }
    }
    public class CartView
    {
        public string ProductId { get; set; }
        public string Result { get; set; }
        public string ProductName { set; get; }
        public string Quantity { get; set; }
        public string MRP { set; get; }
        public decimal TotalAmount { get; set; }
        public string Adddate { get; set; }
        public decimal GST { get; set; }
        public decimal PTR { get; set; }
        public string ImageUrl { get; set; }
        public OfferApplied Offer_Applied { get; set; }
    }
    public class OrdersList
    {
        public string id { set; get; }
        public string Result { set; get; }
        public string OrderID { set; get; }
        public string DateOrder { set; get; }
        public string Status { set; get; }
        public string OrderShipID { set; get; }
        public string BillDate { set; get; }
        public string ShipDate { set; get; }
        public string TotalAmount { set; get; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string StatusId { get; set; }
        public string SalesQuotation { get; set; }
        public int Totality { get; set; }
        public List<ProductDetails> Productdetails { get; set; }

    }
    public class AddToCarts
    {
        public string Status { get; set; }
        public string Result { get; set; }
    }
    public class OfferApplied
    {
        public string OfferId { get; set; }
        public string OfferName { get; set; }
        public int OfferedProducts { get; set; }
        public int offerQty { get; set; }
        public int eligibilityQty { get; set; }
    }
    public class AgentLogins
    {
        public string Id { get; set; }
        public string username { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string CityId { get; set; }
        public string State { get; set; }
        public string StateId { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StoreName { get; set; }
        public string StoreCode { get; set; }
        public string Password { get; set; }
        public string UsertypeId { get; set; }
        public string Usertype { get; set; }
        public string Zone { get; set; }
        public string Banner { get; set; }
        public string CitiesIds { get; set; }
        public string Regional_Cites { get; set; }
    }

    public class ProductListRoot
    {
        public string ProductId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string FrgnName { get; set; }
        public string OnHand { get; set; }
        public string Available { get; set; }
        public string MRP { get; set; }
        public string GST { get; set; }
        public string PTR { get; set; }
        public string F_1 { get; set; }
        public string F_2 { get; set; }
        public string F_3 { get; set; }
        public string F_4 { get; set; }
        public string F_5 { get; set; }
        public string Image { get; set; }
        public int Inout { get; set; }
        public string Id { get; set; }
        public string Result { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public string Offers { get; set; }

    }
    public class OfferListRoot
    {
        public string OfferId { get; set; }
        public string OfferName { get; set; }
        public string Description { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string EligibilityQty { get; set; }
        public string OfferQty { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public string Result { get; set; }
        public string offerstatus { get; set; }
        public string productId { get; set; }

    }
    public class UserOrderList
    {
        public string OrderId { set; get; }
        public DateTime OrderDate { set; get; }
        public string FirstName { set; get; }
        public string Email { set; get; }
        public string Mobile { set; get; }
        public string Address { set; get; }
        public string City { set; get; }
        public string State { set; get; }
        public string ZipCode { set; get; }
        public List<ItemList> UserOrderListItems { get; set; }
        public string PaymentMode { get; set; }
        public string DiscountPercentage { get; set; }
        public string ShippingCharge { get; set; }
    }
    public class ItemList
    {
        public string ItemCode { get; set; }
        public int Quantity { get; set; }
        public decimal Mrp { get; set; }
        public int OfferdQty { get; set; }
    }
    public class ResponseData
    {
        public string Message { get; set; }
        public string SalesQuotationNumber { get; set; }
    }
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
    }
    public class Banner
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public int BannerId { get; set; }
        public string BannerName { get; set; }
        public int Sequence { get; set; }
        public string ImageUrl { get; set; }

    }
    public class PopupImage
    {
        public string Id { get; set; }
        public string Result { get; set; }
        public int ImageId { get; set; }
        public string Product { get; set; }
        public string ImageName { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }

    }

    public class ReturnProductModel
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public string batchNumber { get; set; }
        public string productName { get; set; } = null;
        public string productImg { get; set; } = null;
        public string status { get; set; } = "Pending";
        public string description { get; set; } = "";
        public int userId { get; set; }
        public int quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
    //public class SAPProductLog
    //{
    //    public int Log_Id { get; set; }
    //    public string File_Name { get; set; }
    //    public string StatusName { get; set; }
    //    public DateTime Created_Date { get; set; }
    //    public DateTime? ProcessDate { get; set; }
    //    public string Total_Updated { get; set; }
    //    public int Total_Record { get; set; }
    //    public string Total_Inserted { get; set; }
    //}

    public class CategoryModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Image")]
        public string Image { get; set; }
        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
        [JsonProperty("createdAt")]
        public DateTime createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }
    }

    public class ProductRequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Composition { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class GiftSchemeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int EligibilityAmount { get; set; }
        public string Offer { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsGlobal { get; set; }
        public string ExcludedProducts { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}