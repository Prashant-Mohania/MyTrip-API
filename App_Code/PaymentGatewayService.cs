using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using cashfree_pg.Client;
using cashfree_pg.Model;
using DocumentFormat.OpenXml.Bibliography;
using Razorpay.Api;

/// <summary>
/// Summary description for PaymentGatewayService
/// </summary>
public class PaymentGatewayService
{

    //public static OrderEntity CreateOrder(string userName, string userNumber, double amount)
    //{
    //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    //    //Cashfree.XClientId = "TEST10437818e09024c9be7f3f5fe43581873401";
    //    //Cashfree.XClientSecret = "cfsk_ma_test_72582f14312271ea5b355a78350db1ff_e17c5789";
    //    //Cashfree.XEnvironment = Cashfree.SANDBOX;
    //    Cashfree.XClientId = "88168630317598316c466ebfc5686188";
    //    Cashfree.XClientSecret = "cfsk_ma_prod_a67071623012d681c2e4f796c9cfd6d7_7e0c6a8a";
    //    Cashfree.XEnvironment = Cashfree.PRODUCTION;
    //    var cashfree = new Cashfree();
    //    var xApiVersion = "2022-09-01";
    //    var customerDetails = new CustomerDetails(userNumber, null, userNumber, userName);
    //    var createOrdersRequest = new CreateOrderRequest(null, Math.Round(amount, 2), "INR", customerDetails: customerDetails);
    //    var result = cashfree.PGCreateOrder(xApiVersion, createOrdersRequest, null, null, null);
    //    return result.Content as OrderEntity;
    //}

    public static OrderEntity CreateOrder(string userName, string userNumber, double amount)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


        RazorpayClient razorpay = new RazorpayClient("rzp_test_Wjfu0851PseHOO", "JK5790o4LjQh3y0J8eQMggyV"); // Test Razorpay
        Dictionary<string, object> options = new Dictionary<string, object>();
        options.Add("amount", Math.Round(amount, 2) * 100); // amount in the smallest currency unit
        options.Add("currency", "INR");
        options.Add("receipt", $"{userNumber}_{DateTime.Now.ToString("dd_MM_yyyy_HH:mm:ss")}");
        Order order = razorpay.Order.Create(options);
        var orderId = order["id"].ToString();
        var orderEntity = new OrderEntity();
        orderEntity.order_id = orderId;
        orderEntity.order_status = "CREATED";
        return orderEntity;


        ////Cashfree.XClientId = "TEST10437818e09024c9be7f3f5fe43581873401";
        ////Cashfree.XClientSecret = "cfsk_ma_test_72582f14312271ea5b355a78350db1ff_e17c5789";
        ////Cashfree.XEnvironment = Cashfree.SANDBOX;
        //Cashfree.XClientId = "88168630317598316c466ebfc5686188";
        //Cashfree.XClientSecret = "cfsk_ma_prod_a67071623012d681c2e4f796c9cfd6d7_7e0c6a8a";
        //Cashfree.XEnvironment = Cashfree.PRODUCTION;
        //var cashfree = new Cashfree();
        //var xApiVersion = "2022-09-01";
        //var customerDetails = new CustomerDetails(userNumber, null, userNumber, userName);
        //var createOrdersRequest = new CreateOrderRequest(null, Math.Round(amount, 2), "INR", customerDetails: customerDetails);
        //var result = cashfree.PGCreateOrder(xApiVersion, createOrdersRequest, null, null, null);
        //return result.Content as OrderEntity;
    }


    //public static bool VerifyOrder(string orderId)
    //{
    //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    //    //Cashfree.XClientId = "TEST10437818e09024c9be7f3f5fe43581873401";
    //    //Cashfree.XClientSecret = "cfsk_ma_test_72582f14312271ea5b355a78350db1ff_e17c5789";
    //    //Cashfree.XEnvironment = Cashfree.SANDBOX;
    //    Cashfree.XClientId = "88168630317598316c466ebfc5686188";
    //    Cashfree.XClientSecret = "cfsk_ma_prod_a67071623012d681c2e4f796c9cfd6d7_7e0c6a8a";
    //    Cashfree.XEnvironment = Cashfree.PRODUCTION;
    //    var cashfree = new Cashfree();
    //    var xApiVersion = "2022-09-01";

    //    var result = cashfree.PGFetchOrder(xApiVersion, orderId, null, null);
    //    return (result.Content as OrderEntity).order_status == "PAID";
    //}



    public static bool VerifyOrder(string orderId)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


        RazorpayClient razorpay = new RazorpayClient("rzp_test_Wjfu0851PseHOO", "JK5790o4LjQh3y0J8eQMggyV"); // Test Razorpay

        Order order = razorpay.Order.Fetch(orderId);

        return order["status"] == "paid";


        ////Cashfree.XClientId = "TEST10437818e09024c9be7f3f5fe43581873401";
        ////Cashfree.XClientSecret = "cfsk_ma_test_72582f14312271ea5b355a78350db1ff_e17c5789";
        ////Cashfree.XEnvironment = Cashfree.SANDBOX;
        //Cashfree.XClientId = "88168630317598316c466ebfc5686188";
        //Cashfree.XClientSecret = "cfsk_ma_prod_a67071623012d681c2e4f796c9cfd6d7_7e0c6a8a";
        //Cashfree.XEnvironment = Cashfree.PRODUCTION;
        //var cashfree = new Cashfree();
        //var xApiVersion = "2022-09-01";

        //var result = cashfree.PGFetchOrder(xApiVersion, orderId, null, null);
        //return (result.Content as OrderEntity).order_status == "PAID";
    }
}