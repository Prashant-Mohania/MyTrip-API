using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for Property
/// </summary>
public class Property
{
    public object headerKey;

    public Property()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string GetIpAddress
    {
        get { return HttpContext.Current.Request.UserHostAddress; }
    }
    public string ApiUrl
    {
        //get{ return "https://pass-api-ite.paytmbank.com"; } //Test
        get { return "https://partner.rnfi.in"; }//
    }
    public string FinalResponse { get; set; }
    public int Count { get; set; }
    public string Result { get; set; }
    public string URL { get;  set; }
    public string Query { get;  set; }
    public string BankID { get; set; }
    public string Mobile { get; set; }
    public string AdhaarCard { get; set; }
    public string Tid { get; set; }
    public string Buffer { get;  set; }
    public byte[] PostData { get;  set; }
    public string PIDData { get; set; }
    public string FileName { get; set; }
    public string IpAddress { get; set; }
    public string GetUrlValues { get; set; }
    public string[] SplitValueEncode { get; set; }
    public string Timestamp { get; internal set; }
    public string Amount { get; set; }
    public string MerchantID { get; set; }
    public string ApiResponse { get; set; }
    public string OperatorID { get; set; }
    public DataSet DataSet { get; set; }
    public DataTable DataTable { get; set; }
    public string UserId { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public MySqlDataReader DataReader { get; set; }
    public string Message { get; set; }
    public string TypeApp { get; set; }
    public object Tpin { get; set; }
    public string Password { get; set; }
    public string Accuracy { get; set; }
    public string Ip { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string NewData { get; set; }
    public string MerchantUserId { get; set; }
    public string Function { get; set; }
    public string EsciiValueReverse { get; set; }
    public string LoginID { get; set; }
    public string ProviderID { get; set; }
    public string RechargeAmount { get; set; }
    public string ServiceType { get; set; }
    public string TransactionType { get; set; }
    public string MobileNumber { get; set; }
    public string CustomerId { get; set; }
    public string ApiType { get; set; }
    public string optional { get; set; }
    public string orderId { get; set; }
    public string ProductName { get; set; }    
    public string IsProductVisible { get; set; }    
    public string mrp { get; set; }
    public string PTR { get; set; }
    public string MRP { get; set; }
    public string GST { get; set; }
    public string ProductID { get; set; }
    public List<int> CitiesIds { get; set; }
    public string Username { get; set; }
    public string shopName { get; set; }
    public string emailID { get; set; }
    public string Address { get; set; }
    public string Pincode { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string ItemCode { get; set; }
    public string ItemName { get; set; }
    public string FrgnName { get; set; }
    public string OnHand { get; set; }
    public string Available { get; set; }
    public string F1 { get; set; }
    public string F2 { get; set; }
    public string F3 { get; set; }
    public string F4 { get; set; }
    public string F5 { get; set; }

    //Add new columns date:06/07/23
    public int Id { get; set; }
    public int? StateId { get; set; } 
    public string StateName { get; set; }
    public int? CityId { get; set; } 
    public string CityName { get; set; }
    public int UserTypeId { get; set; } 
    public string UserType { get; set; }
    public bool IsDisplayed { get; set; }
     public int? ZoneId { get; set; }
    public string Zone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StoreCode { get; set; }
    public string StoreName { get; set; }
    public string Regional_Cites { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string ProductId { get; set; }

    // add new field for banner table
    public string BannerId { get; set; }
    public string bannerName { get; set; }
    public string image { get; set; }
    public string tags { get; set; }
    public string sequence { get; set; }
    public List<string> states { get; set; }
    public string OrderId { get; set; }
    public string Date { get; set; }
    public string PaymentMode { get; set; }
    public string DiscountPercentage { get; set; }
    public string ShippingCharge { get; set; }
    public string Quantity { get; set; }
    public string SalesQuotationNumber { get; set; }
    public string JsonArray { get; set; }
    public string JsonArrayRequest { get; set; }
    public string ListData { get; set; }

    // add for pop up image
    public string ImageName { get; set; }
    public string PopupImageId { get; set; }

    //add fields for offer table
    public int Offer_Id { get; set; }
    public string Offer_Name { get; set; }
    public string Offer_Description { get; set; } 
    public string Eligibility_Qty { get; set; }
    public string Offer_Qty { get; set; }
    public DateTime From_Date { get; set; }
    public DateTime To_Date { get; set;}
    public int Offer_Status { get; set; }
    public List<int> ProductIds { get; set; }

    //add fields for SAPPRODUCTSYNCLOGTABLE table
    //public int Log_Id { get; set; }
    //public string File_Name { get; set; }
    //public string StatusName { get; set; }
    //public DateTime Created_Date { get; set; }
    //public DateTime? ProcessDate { get; set; }
    //public string Total_Updated { get; set; }
    //public int Total_Record { get; set; }
    //public string Total_Inserted { get; set; }


    //EMAIL 
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public string licenseNo { get; set; }
    public DateTime dob { get; set; }
    public string BankDetails { get; set; }
}