using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace selenium1
{
    class Program
    {
        public static IWebDriver driver;
        static void Main(string[] args)
        {

            //Program p1 = new Program();
            //p1.SendDueMessage();
           
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://web.whatsapp.com/");
            try
            {
                Console.WriteLine("----------------------------------------------------------------- ");
                Console.WriteLine("Please scan with in one minute");
                Thread.Sleep(60000);
                Program p = new Program();
               p.send();
               //p.sendd();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(60000);
                Program p = new Program();
               p.send();
              // p.sendd();
            }

        }
        public static string contact;
        public void sendwhatsappDuemessage(string msg, string contactno)
        {
            try
            {
                //if (contact == contactno)
                //{
                //    var lists = driver.FindElement(By.ClassName("_3uxr9"));

                //    var listsss = lists.FindElement(By.ClassName("copyable-area"));
                //    var list2 = listsss.FindElement(By.ClassName("_1SEwr"));
                //    var lists3 = list2.FindElement(By.ClassName("_6h3Ps"));
                //    var listsssss = lists3.FindElement(By.ClassName("copyable-text"));
                //    listsssss.SendKeys(msg + Keys.Enter);

                //}
                //else
                //{
                    contact = contactno;
                    Thread.Sleep(15000);
               string msgnew= "https://web.whatsapp.com/send?phone=91" + contactno + "&text=" + msg;
                driver.Navigate().GoToUrl(msgnew);
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();
                //driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91" + contactno);
                //    //driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91" + 7696249893);
                //    Thread.Sleep(15000);
                //    Thread.Sleep(15000);
                //    var lists = driver.FindElement(By.ClassName("_30KVb"));

                //    var listsss = lists.FindElement(By.ClassName("copyable-area"));
                //    var list2 = listsss.FindElement(By.ClassName("_1SEwr"));
                //    var lists3 = list2.FindElement(By.ClassName("_6h3Ps"));
                //    var listsssss = lists3.FindElement(By.ClassName("copyable-text"));
                //    listsssss.SendKeys(msg + Keys.Enter);
                //}
            }
            catch
            {
               
            }
          
        }
        public  void sendd()
        {
            try
            {
                var lists = driver.FindElement(By.ClassName("_30KVb"));

                var listsss = lists.FindElement(By.ClassName("copyable-area"));
                var list2 = listsss.FindElement(By.ClassName("_1un-p"));
                var listsssss = list2.FindElement(By.ClassName("_2jitM"));
                listsssss.Click();
                Thread.Sleep(5000);
                var list4 = listsssss.FindElement(By.ClassName("_3iTtj"));
                var list5 = list4.FindElement(By.ClassName("_1lPfJ"));
                var list6 = list5.FindElement(By.ClassName("_1HnQz"));
                var list7 = list6.FindElement(By.CssSelector("ul > li:nth-child(3)"));
                //Thread.Sleep(2000);
                //list7.FindElement(By.CssSelector("input[type='file']")).SendKeys(filePathMainInvoice);
                //Thread.Sleep(5000);
                //driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();
                //    //string query = "select Query from querytable where queryfor = 'dueorder'";
                //DataSet dsGetUser = GetDataSet(query);
                //query = dsGetUser.Tables[0].Rows[0][0].ToString();
                //dsGetUser = GetDataSet(query);

                //if (dsGetUser.Tables[0].Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dsGetUser.Tables[0].Rows)
                //    {
                //        Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]);
                //        Thread.Sleep(2000);
                //        if (dr[1] == dr[2])
                //        {
                //            sendwhatsappDuemessage(dr[0].ToString(), dr[1].ToString());
                //        }
                //        else
                //        {

                //            sendwhatsappDuemessage(dr[0].ToString(), dr[1].ToString());
                //            sendwhatsappDuemessage(dr[0].ToString(), dr[2].ToString());
                //        }

                //    }
                //}


                //var list2 = listsss.FindElement(By.ClassName("_3qpzV"));
                //var listsssss = list2.FindElement(By.ClassName("_2wfYK"));
                //listsssss.Click();
                //Thread.Sleep(5000);
                //var list4 = listsssss.FindElement(By.ClassName("eBZuM"));
                //var list5 = list4.FindElement(By.ClassName("_2c4Sf"));
                //var list6 = list5.FindElement(By.ClassName("_1hhxx"));
                //var list7 = list6.FindElement(By.CssSelector("ul > li:nth-child(3)"));
            }
            catch(Exception ex)
            {
                sendd();
            }

        }
        public void SendDueMessage()
        {
            string query = "select Query from querytable where queryfor = 'dueorder'";
            DataSet dsGetUser = GetDataSet(query);
            query = dsGetUser.Tables[0].Rows[0][0].ToString();
            dsGetUser = GetDataSet(query);

            if (dsGetUser.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsGetUser.Tables[0].Rows)
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]);
                    Thread.Sleep(2000);
                    try
                    {
                        if (dr[1] == dr[2])
                        {
                            sendwhatsappDuemessage(dr[0].ToString(), dr[1].ToString());
                        }
                        else
                        {

                            sendwhatsappDuemessage(dr[0].ToString(), dr[1].ToString());
                            sendwhatsappDuemessage(dr[0].ToString(), dr[2].ToString());
                        }
                    }
                    catch
                    {

                    }

                }
            }
        }
        public void SendDueMessageRep()
        {
            string query = "select Query from querytable where queryfor = 'dueorder'";
            DataSet dsGetUser = GetDataSet(query);
            query = dsGetUser.Tables[0].Rows[0][0].ToString();
            dsGetUser = GetDataSet(query);

            if (dsGetUser.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsGetUser.Tables[0].Rows)
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]);
                    Thread.Sleep(2000);
                    //if (dr[1] == dr[2])
                    //{
                    //    sendwhatsappDuemessage(dr[0].ToString(), dr[1].ToString());
                    //}
                    //else
                    //{

                      //  sendwhatsappDuemessage(dr[0].ToString(), dr[1].ToString());
                        sendwhatsappDuemessage(dr[0].ToString(), dr[2].ToString());

                    Console.WriteLine("Send  " + dr[2].ToString());
                   // }

                }
            }
        }
        public static DataSet GetDataSet(string Query)
        {
            using (var _VarDataSet = new DataSet())
            {
                try
                {
                    using (var _VarSqlDataAdapter = new SqlDataAdapter(Query, new SqlConnection(GetConnection())))
                    {
                        _VarSqlDataAdapter.SelectCommand.CommandTimeout = 9000;
                        _VarSqlDataAdapter.Fill(_VarDataSet);
                    }
                    return _VarDataSet;
                }
                catch (Exception ex)
                {


                    return null;
                }
            }
        }
        public static String GetConnection()
        {
            //String ConnectionString =
            //"server=SOFTWARE-DEVELO\\SQLEXPRESS;" +
            //"uid=sat;" +
            //"pwd=Satcap@2020;" +
            //"database=GenDataSatcapIndia;Timeout=3000;";
            ////
            String ConnectionString = "server=192.168.1.24,1433;" +
            "uid=sa;" +
            "pwd=Satcap@2020;" +
            "database=GenDataSatcapIndia;Timeout=3000;";


            return ConnectionString;


            //return @"Data Source=happy;Initial Catalog=Final;Integrated Security=True";

        }
        public static string orderwithmobile="";
        public void sendwhastsapp(DataRow dr,string  filePathMainInvoice,string url,string type)
        {
            try
            {
      
                Console.WriteLine("-------------sendwhastsapp function----------");
                Console.WriteLine(filePathMainInvoice);
                if (dr[7].ToString().Length == 10 && orderwithmobile != dr[2].ToString()+ dr[7].ToString())
                {
                    orderwithmobile = dr[2].ToString() + dr[7].ToString();
                    try
                    {
                        Console.WriteLine("-------------sendwhastsapp function----------");

                        //var lists = driver.FindElement(By.ClassName("_2ig1U"));


                       

                        driver.Navigate().GoToUrl(url);
                        Console.WriteLine("-------------filesave succesfully----------" + dr[2]);

                        if(type=="order")
                        {
                            driver.Navigate().GoToUrl("http://backoffice.satcapindia.info/files/SatcapOrder_" + dr[2] + "_" + dr[8] + ".pdf");
                        }
                        Thread.Sleep(5000);

                        Console.WriteLine("--------find---" + dr[7]);

                        try
                        {
                            driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91" + dr[7]);

                          //  driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=917009400781");
                            Thread.Sleep(25000);
                            var lists = driver.FindElement(By.ClassName("_30KVb"));

                            var listsss = lists.FindElement(By.ClassName("copyable-area"));

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Message upddate true phone no not available on whatsapp" + dr[2] + " " + dr[7]);
                            smslog(Convert.ToInt32(dr[0]));

                            updateSms(Convert.ToInt32(dr[0]));
                            Thread.Sleep(30000);
                            send();

                        }
                       // driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91" + dr[7]);
                        Thread.Sleep(5000);
                        try
                        {
                            // var listsss = lists.FindElement(By.ClassName("copyable-area"));
                            //var list2 = listsss.FindElement(By.ClassName("_3qpzV"));
                            //var listsssss = list2.FindElement(By.ClassName("_2wfYK"));
                            if (CheclMsgSend(Convert.ToInt32(dr[0])))
                            {
                                smslog(Convert.ToInt32(dr[0]));
                                var lists = driver.FindElement(By.ClassName("_30KVb"));

                                var listsss = lists.FindElement(By.ClassName("copyable-area"));
                                var list2 = listsss.FindElement(By.ClassName("_1un-p"));
                                var listsssss = list2.FindElement(By.ClassName("_2jitM"));
                                listsssss.Click();
                                Thread.Sleep(5000);
                                var list4 = listsssss.FindElement(By.ClassName("_3iTtj"));
                                var list5 = list4.FindElement(By.ClassName("_1lPfJ"));
                                var list6 = list5.FindElement(By.ClassName("_1HnQz"));
                                var list7 = list6.FindElement(By.CssSelector("ul > li:nth-child(3)"));
                                Thread.Sleep(2000);
                                var list8 = list7.FindElement(By.ClassName("_2t8DP"));
                                //filePathMainInvoice = filePathMainInvoice.Replace("Administrator", "Satcap");
                                list8.FindElement(By.CssSelector("input[type='file']")).SendKeys(filePathMainInvoice);
                                Thread.Sleep(5000);
                                driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();
                                Thread.Sleep(5000);
                                Console.WriteLine("msg sent on " + dr[7]);
                                smslog(Convert.ToInt32(dr[0]));
                                Console.WriteLine("Log created of " + dr[2]);
                                updateSmsnew(Convert.ToInt32(dr[2]), dr[7].ToString());
                                //  updateSms(Convert.ToInt32(dr[0]));
                                Console.WriteLine("Message upddate true" + dr[2]);

                                System.IO.File.Delete(filePathMainInvoice);
                                Console.WriteLine("file deleted" + dr[2]);

                                Thread.Sleep(30000);
                                send();
                            }
                            else
                            {
                                smslog(Convert.ToInt32(dr[0]));
                                Console.WriteLine("Log created of " + dr[2]);
                                updateSmsnew(Convert.ToInt32(dr[2]), dr[7].ToString());
                                //  updateSms(Convert.ToInt32(dr[0]));
                                Console.WriteLine("Message upddate true" + dr[2]);

                                System.IO.File.Delete(filePathMainInvoice);
                                Console.WriteLine("file deleted" + dr[2]);

                                Thread.Sleep(30000);
                                send();

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Message upddate true phone no not available on whatsapp" + dr[2] + " " + dr[7]);


                            updateSms(Convert.ToInt32(dr[0]));
                            Thread.Sleep(30000);
                            send();
                            
                        }

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Run after 60 second");
                        Thread.Sleep(60000);
                        send();

                    }
                }
                else
                {
                    Console.WriteLine("Message upddate true phone no not correct" + dr[2] + " " + dr[7]);

                    updateSms(Convert.ToInt32( dr[0]));
                    Thread.Sleep(60000);
                    send();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Run after 50 second");
                Thread.Sleep(50000);
                send();
                //  updateSms(Convert.ToInt32( dr[2]));
            }
           
           
            
        }
        public bool CheclMsgSend(int id)
        {
            string query = "select max(msgid) from msglog";
            DataSet dsGetUsers = GetDataSet(query);
            int Datet = Convert.ToInt32(dsGetUsers.Tables[0].Rows[0][0]);
            if(Datet<id)
            {
                return true;
            }
            return false;
        }
        public  void smslog(int id)
        {
            string query= "INSERT INTO msglog (msgid,msgsendon)VALUES("+id+", getdate())";
            DataSet dsGetUsers = GetDataSet(query);

        }
        public void smsPromotionlog(int id,string contactno)
        {
            string query = "INSERT INTO msglog (msgid,msgsendon,ContactNo)VALUES(" + id + ", getdate(),"+ contactno + ")";
            DataSet dsGetUsers = GetDataSet(query);

        }
        public void updateSms(int id)
        {
            DataSet dsGetUsers = GetDataSet("update   whatsappmsgsend set IsWhatsAppMsg=1 where Sendid=" + id);

        }
        public void updateSmsnew(int id,string contact)
        {
            
            Console.WriteLine("update doc no" + id + "Contactno =" + contact);
            DataSet dsGetUsers = GetDataSet("update   whatsappmsgsend set IsWhatsAppMsg=1 where DocNo='" + id + "' and Contactno='"+ contact + "'");

        }
        public void send()
        {
           
            int id = 0;
             
            try
            {


                if (DateTime.Now.DayOfWeek.ToString() == "Monday")
                {
                    string timequery = "select time from msgtime where id=1";
                    DataSet dsGetUser1 = GetDataSet(timequery);
                    DateTime Datet = Convert.ToDateTime(dsGetUser1.Tables[0].Rows[0][0].ToString());
                    if (DateTime.Now.Hour == Datet.Hour && DateTime.Now.Minute == Datet.Minute)
                    {
                        SendDueMessage();
                    }
                }
                //if (DateTime.Now.DayOfWeek.ToString() == "Friday" && DateTime.Now.Hour == 11 && DateTime.Now.Minute == 1)
                //{
                //    SendDueMessageRep();
                //}
                Console.WriteLine("-------------Start----------");
                DataSet dsGetUserss = GetDataSet("delete  FROM whatsappmsgsend where  contactno in ('1122334455','6655443322')  ");
                Console.WriteLine("-------------deleteted----------");

                DataSet dsGetUsers = GetDataSet("update whatsappmsgsend set IsWhatsAppMsg=0 where Sendid>(select max(msgid) from msglog )");
                Console.WriteLine("-------------updated----------");
                string query = "select Query from querytable where queryfor = 'WhatsappMessageInvoicesandorder'";
                DataSet dsGetUser = GetDataSet(query);
                query = dsGetUser.Tables[0].Rows[0][0].ToString();
                dsGetUser = GetDataSet(query);
              
                if (dsGetUser.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsGetUser.Tables[0].Rows)
                    {
                        if (dr[7].ToString().Length == 10 && orderwithmobile != dr[2].ToString() + dr[7].ToString())
                        {
                            id = Convert.ToInt32(dr[0]);
                            if (CheclMsgSend(id))
                            {


                                if (dr[1].ToString() == "Order")
                                {
                                    //if (dr[8].ToString() != "1034")
                                    //{

                                    //  string url = "http://backoffice.satcapindia.info/order/SendOrderwhtsapp?orderId=" + dr[2];
                                    // string url = "http://localhost:49916/checkout/SendOrderwhtsapp?orderId=" + dr[2];
                                    //   string filePathMainInvoice = "C:\\inetpub\\wwwroot\\SatcapIndia\\Files\\SatcapOrder_" + dr[2] + "_"+dr[8]+".pdf"; //" C:\\Users\\Satcap\\Downloads\\SatcapInvoice_" + dr[2] + ".pdf";
                                    // string filePathMainInvoice = "http://www.satcapindia.com/Files/SatcapOrder_" + dr[2] + "_" + dr[8] + ".pdf";
                                    // string filePathMainInvoice = "D:\\Projects\\SatcapIndia\\SatcapIndia\\SatcapIndia\\Files\\SatcapOrder_" + dr[2] + "_" + dr[8] + ".pdf";
                                    // string filePathMainInvoice = " C:\\Users\\Administrator\\Downloads\\SatcapOrder_" + dr[2] + "_" + dr[8] + ".pdf";
                                    //string filePathMainInvoice = " C:\\inetpub\\wwwroot\\SatcapIndiaAdmin\\Files\\SatcapOrder_" + dr[2] + "_" + dr[8] + ".pdf";

                                    //string filePathMainInvoice = " C:\\Users\\Administrator\\Downloads\\SatcapOrder_" + dr[2] + "_" + dr[8] + ".pdf";

                                    // sendwhastsapp(dr, filePathMainInvoice, url,"order");
                                    string GetnameofCustomer= " select ISNULL(c.CompName,c.FirstName+' '+c.LastName) as name from orderinfo o " +
                                        " inner join CustomerMst c  on o.UserId = c.CustID  where orderid = "+dr[2];
                                    DataSet dsGUser = GetDataSet(GetnameofCustomer);
                                   string  CustomerName = dsGUser.Tables[0].Rows[0][0].ToString();
                                    String message = "Dear "+ CustomerName + ", Thanks for your Sale order No. "+ dr[2] + ". You can download your order on  https://backoffice.satcapindia.info/order/d/" + EncryptDecryptStringHelper.EncryptString(dr[2].ToString());
                                    //string Urlinv = "https://web.whatsapp.com/send?phone=917009400781&text=" + message;
                                    string Urlinv = "https://web.whatsapp.com/send?phone=91" + dr[7] + "&text=" + message;
                                    driver.Navigate().GoToUrl(Urlinv);
                                    Thread.Sleep(5000);
                                    driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();
                                    updateSms(Convert.ToInt32(dr[0]));
                                    smslog(id);
                                    //}
                                    //else
                                    //{
                                    //    updateSms(id);

                                    //}


                                }
                                else if (dr[1].ToString() == "Promotion")
                                {
                                    //driver.Navigate().GoToUrl(dr[7].ToString());
                                    sendwhastsappPromotion(dr, dr[7].ToString(), dr[7].ToString(), "Promotion");

                                }
                                else if (dr[1].ToString() == "tpt" || dr[1].ToString() == "inv")
                                {
                                    //driver.Navigate().GoToUrl(dr[7].ToString());
                                    sendwhastsappTPT(dr, dr[9].ToString(), dr[9].ToString(), "tpt");

                                }
                                else
                                {
                                    //string url = "http://192.168.1.24:81/order/Invoicedownload?invno=" + dr[2];

                                    // string filePathMainInvoice = " C:\\Users\\Administrator\\Downloads\\SatcapInvoice_" + dr[2] + ".pdf";
                                    //string url = "http://localhost:57395/order/Invoicedownload?invno=" + dr[2];
                                    //string filePathMainInvoice = " C:\\Users\\Administrator\\Downloads\\SatcapInvoice_" + dr[2] + ".pdf";
                                    string GetnameofCustomer = " select ISNULL(c.CompName,c.FirstName+' '+c.LastName) as name from InvoiceMst o " +
                                       " inner join CustomerMst c  on o.ImUserId = c.CustID  where ImInvNo = " + dr[2];
                                    DataSet dsGUser = GetDataSet(GetnameofCustomer);
                                    string CustomerName = dsGUser.Tables[0].Rows[0][0].ToString();
                                    String message = "Dear " + CustomerName + ", Thanks for your Invoice No. " + dr[2] + " has been generated. You can download your invoice on  https://backoffice.satcapindia.info/invoice/d/" + EncryptDecryptStringHelper.EncryptString(dr[2].ToString());

                                     string Urlinv = "https://web.whatsapp.com/send?phone=91"+dr[7]+"&text=" + message;
                                    driver.Navigate().GoToUrl(Urlinv);
                                    Thread.Sleep(5000);
                                    driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();
                                    updateSms(Convert.ToInt32(dr[0]));
                                    smslog(id);
                                    //var lists = driver.FindElement(By.ClassName("_3uxr9"));

                                    //var listsss = lists.FindElement(By.ClassName("copyable-area"));
                                    //var list2 = listsss.FindElement(By.ClassName("_1SEwr"));
                                    //var lists3 = list2.FindElement(By.ClassName("_6h3Ps"));
                                    //var listsssss = lists3.FindElement(By.ClassName("copyable-text"));
                                    //listsssss.SendKeys(msg + Keys.Enter);
                                    //sendwhastsapp(dr, filePathMainInvoice, url, "Invoice");

                                }
                            }
                            else
                            {
                                smslog(id);
                                updateSms(id);
                            }
                        }
                        else
                        {
                            smslog(id);
                            updateSms(id);
                        }


                        }
                }
                else
                {
                    Console.WriteLine("Run after 60 second");
                    Thread.Sleep(50000);
                    send();
                }
               send();

            }
            catch (Exception ex)
            {
                Thread.Sleep(5000);

                send();
            }
        }
        public void sendwhastsappPromotion(DataRow dr, string filePathMainInvoice, string url, string type)
        {
            updateSms(Convert.ToInt32(dr[0]));
            smslog(Convert.ToInt32(dr[0]));
            string query = "";
            if (!String.IsNullOrEmpty(dr[8].ToString()))
                {
                query = "select customermst.ContactNo from msglog " +
                    " right join customermst on  msglog.msgid = " + dr[0] + " and customermst.ContactNo = msglog.ContactNo" +
                    " where CustTypeId =  " + dr[2] + " and City = (select CityName from CityMst where CityId = " + dr[8] + ") and msglog.msgid is null";
            }
            else
            {
                query = "select customermst.ContactNo from msglog " +
                      " right join customermst on  msglog.msgid = " + dr[0] + " and customermst.ContactNo = msglog.ContactNo" +
                      " where CustTypeId =  " + dr[2] + " and State = (select StateName from StateMst where StateId=  " + dr[10] + ") and msglog.msgid is null";


            }
            //"" +
            //" select ContactNo from customermst where CustTypeId=" + dr[2]+ "and City=(select CityName from CityMst where CityId="+dr[8]+")";
            DataSet dsGetUser = GetDataSet(query);
            if (dsGetUser.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drt in dsGetUser.Tables[0].Rows)
                {
                    try
            {
                        smsPromotionlog(Convert.ToInt32(dr[0]), drt[0].ToString());
                Console.WriteLine("-------------sendwhastsapp function----------");
                Console.WriteLine(filePathMainInvoice);
                
                    orderwithmobile = dr[2].ToString() + dr[7].ToString();
             //.  driver.Navigate().GoToUrl(url);
                Console.WriteLine("-------------filesave succesfully----------" + dr[2]);
               


                
                        try
                    {
                        Console.WriteLine("-------------sendwhastsapp function----------");

                        //var lists = driver.FindElement(By.ClassName("_2ig1U"));




                      

                          
                        Thread.Sleep(5000);

                        Console.WriteLine("--------find---" + dr[7]);

                        try
                        {
                                // driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91" + dr[7]);
                                if (drt[0].ToString().Length == 10 )
                                {
                                   // driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=917009400781" );
                                     driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91"+ drt[0]);
                                    Thread.Sleep(25000);

                                    var listss = driver.FindElement(By.ClassName("_30KVb"));


                                    var list2 = listss.FindElement(By.ClassName("copyable-area"));
                                }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Message upddate true phone no not available on whatsapp" + drt[2] + " " + dr[7]);
                            //smslog(Convert.ToInt32(dr[0]));

                            //updateSms(Convert.ToInt32(dr[0]));
                            Thread.Sleep(30000);
                          
                        }
                        // driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91" + dr[7]);
                        Thread.Sleep(5000);
                        try
                        {
                                // var listsss = lists.FindElement(By.ClassName("copyable-area"));
                                //var list2 = listsss.FindElement(By.ClassName("_3qpzV"));
                                //var listsssss = list2.FindElement(By.ClassName("_2wfYK"));
                                if (drt[0].ToString().Length == 10)
                                {
                                    var lists = driver.FindElement(By.ClassName("_30KVb"));

                                    var listsss = lists.FindElement(By.ClassName("copyable-area"));
                                    var list2 = listsss.FindElement(By.ClassName("_1un-p"));
                                    var listsssss = list2.FindElement(By.ClassName("_2jitM"));
                                    listsssss.Click();
                                    Thread.Sleep(5000);
                                    var list4 = listsssss.FindElement(By.ClassName("_3iTtj"));
                                    var list5 = list4.FindElement(By.ClassName("_1lPfJ"));
                                    var list6 = list5.FindElement(By.ClassName("_1HnQz"));
                                    var list7 = list6.FindElement(By.CssSelector("ul > li:nth-child(3)"));
                                    Thread.Sleep(2000);
                                    var list8 = list7.FindElement(By.ClassName("_2t8DP"));
                                    // filePathMainInvoice = filePathMainInvoice.Replace("Administrator", "Satcap");
                                    list8.FindElement(By.CssSelector("input[type='file']")).SendKeys(filePathMainInvoice);
                                    Thread.Sleep(5000);
                                    driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();
                                    Thread.Sleep(2000);
                                    var list29 = listsss.FindElement(By.ClassName("_1SEwr"));
                                    var lists39 = list29.FindElement(By.ClassName("_6h3Ps"));
                                    var li = lists39.FindElement(By.ClassName("copyable-text"));
                                    li.SendKeys(dr[9].ToString()+Keys.Enter);
                                    Thread.Sleep(5000);
                                    Console.WriteLine("msg sent on " + dr[0]);
                                    

                                    Thread.Sleep(30000);
                                }
                           
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Message upddate true phone no not available on whatsapp" + dr[2] + " " + dr[7]);


                            updateSms(Convert.ToInt32(dr[0]));
                            Thread.Sleep(30000);
                          
                        }
                           
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Run after 6 second");
                        Thread.Sleep(6000);
                       

                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Run after 50 second");
                Thread.Sleep(50000);
                send();
                //  updateSms(Convert.ToInt32( dr[2]));
            }

        }
    }
            Console.WriteLine("Run after 1 minute");
            Thread.Sleep(50000);
            send();


}
        public void sendwhastsappTPT(DataRow dr, string filePathMainInvoice, string url, string type)
        {
            updateSms(Convert.ToInt32(dr[0]));
            smslog(Convert.ToInt32(dr[0]));
            //string query = " select ContactNo from customermst where CustTypeId=" + dr[2];
            //DataSet dsGetUser = GetDataSet(query);
           
                    try
                    {

                        Console.WriteLine("-------------sendwhastsapp function----------");
                        Console.WriteLine(filePathMainInvoice);
                if (dr[7].ToString().Length == 10 && orderwithmobile != dr[9].ToString() + dr[7].ToString())
                {
                    orderwithmobile = dr[9].ToString() + dr[7].ToString();
                    //.  driver.Navigate().GoToUrl(url);
                    Console.WriteLine("-------------filesave succesfully----------" + dr[9]);




                    try
                    {
                        Console.WriteLine("-------------sendwhastsapp function----------");

                        //var lists = driver.FindElement(By.ClassName("_2ig1U"));







                        Thread.Sleep(5000);

                        Console.WriteLine("--------find---" + dr[7]);

                        try
                        {
                            // driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91" + dr[7]);
                            if (dr[7].ToString().Length == 10)
                            {
                                driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91" + dr[7]);
                                Thread.Sleep(25000);

                                var listss = driver.FindElement(By.ClassName("_3uxr9"));


                                var list2 = listss.FindElement(By.ClassName("copyable-area"));
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Message upddate true phone no not available on whatsapp" + dr[9] + " " + dr[7]);
                            smslog(Convert.ToInt32(dr[0]));

                            updateSms(Convert.ToInt32(dr[0]));
                            Thread.Sleep(30000);

                        }
                        // driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91" + dr[7]);
                        Thread.Sleep(5000);
                        try
                        {if (CheclMsgSend(Convert.ToInt32(dr[0])))
                            {
                                smslog(Convert.ToInt32(dr[0]));
                                // var listsss = lists.FindElement(By.ClassName("copyable-area"));
                                //var list2 = listsss.FindElement(By.ClassName("_3qpzV"));
                                //var listsssss = list2.FindElement(By.ClassName("_2wfYK"));
                                if (dr[7].ToString().Length == 10)
                                {
                                    var lists = driver.FindElement(By.ClassName("_30KVb"));

                                    var listsss = lists.FindElement(By.ClassName("copyable-area"));
                                    var list2 = listsss.FindElement(By.ClassName("_1un-p"));
                                    var listsssss = list2.FindElement(By.ClassName("_2jitM"));
                                    listsssss.Click();
                                    Thread.Sleep(5000);
                                    var list4 = listsssss.FindElement(By.ClassName("_3iTtj"));
                                    var list5 = list4.FindElement(By.ClassName("_1lPfJ"));
                                    var list6 = list5.FindElement(By.ClassName("_1HnQz"));
                                    var list7 = list6.FindElement(By.CssSelector("ul > li:nth-child(3)"));
                                    Thread.Sleep(2000);
                                    list7.FindElement(By.CssSelector("input[type='file']")).SendKeys(filePathMainInvoice);
                                    Thread.Sleep(5000);
                                    driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();
                                    Thread.Sleep(5000);
                                    Console.WriteLine("msg sent on " + dr[0]);
                                    smslog(Convert.ToInt32(dr[0]));
                                    Thread.Sleep(5000);
                                    updateSms(Convert.ToInt32(dr[0]));
                                    Thread.Sleep(30000);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Message upddate true phone no not available on whatsapp" + dr[2] + " " + dr[7]);

                            smslog(Convert.ToInt32(dr[0]));
                            updateSms(Convert.ToInt32(dr[0]));
                            Thread.Sleep(30000);

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Run after 6 second");
                        Thread.Sleep(6000);


                    }
                }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Run after 50 second");
                        Thread.Sleep(50000);
                        send();
                        //  updateSms(Convert.ToInt32( dr[2]));
                    }

            send();


        }

    }
    public class EncryptDecryptStringHelper
    {
        private static string SecurityKey = "_Satcap_07082021";

        public static string EncryptString(string toEncrypt, bool useHashing = true)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            string key = SecurityKey;

            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string DecryptString(string cipherString, bool useHashing = true)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = SecurityKey;

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        //public static string EncryptString(string text, string keyString = "E546C8DF278CD5931069B522E695D4F2")
        //{
        //    var key = Encoding.UTF8.GetBytes(keyString);

        //    using (var aesAlg = Aes.Create())
        //    {
        //        using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
        //        {
        //            using (var msEncrypt = new MemoryStream())
        //            {
        //                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //                using (var swEncrypt = new StreamWriter(csEncrypt))
        //                {
        //                    swEncrypt.Write(text);
        //                }

        //                var iv = aesAlg.IV;

        //                var decryptedContent = msEncrypt.ToArray();

        //                var result = new byte[iv.Length + decryptedContent.Length];

        //                Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
        //                Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

        //                return Convert.ToBase64String(result);
        //            }
        //        }
        //    }
        //}

        //public static string DecryptString(string cipherText, string keyString = "E546C8DF278CD5931069B522E695D4F2")
        //{
        //    var fullCipher = Convert.FromBase64String(cipherText);

        //    var iv = new byte[16];
        //    var cipher = new byte[16];

        //    Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
        //    Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
        //    var key = Encoding.UTF8.GetBytes(keyString);

        //    using (var aesAlg = Aes.Create())
        //    {
        //        using (var decryptor = aesAlg.CreateDecryptor(key, iv))
        //        {
        //            string result;
        //            using (var msDecrypt = new MemoryStream(cipher))
        //            {
        //                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
        //                {
        //                    using (var srDecrypt = new StreamReader(csDecrypt))
        //                    {
        //                        result = srDecrypt.ReadToEnd();
        //                    }
        //                }
        //            }

        //            return result;
        //        }
        //    }
        //}
    }

}
//        public void send()
//        {
//            try
//            {
//                DataSet dsGetUser = GetDataSet("select Gname from whatsappgroups where isActive=1");
//                if (dsGetUser.Tables[0].Rows.Count > 0)
//                {
//                    foreach (DataRow dr in dsGetUser.Tables[0].Rows)
//                    {
//                        driver.FindElement(By.ClassName("_2S1VP")).SendKeys(dr[0] + Keys.Enter);
//                        Thread.Sleep(10000);
//                        var list = driver.FindElement(By.ClassName("_2WovP"));
//                        DataSet dsGetLinks = GetDataSet("select top 5 YtubeLink  from links where isActive=1 and Message_Send=0 and cast(senddate as date) <> cast(GETDATE() as date) or senddate is null or Message_Send is null");
//                        if (dsGetLinks.Tables[0].Rows.Count > 0)
//                        {
//                            foreach (DataRow drlink in dsGetLinks.Tables[0].Rows)
//                            {
//                                try
//                                {
//                                    list.FindElement(By.ClassName("_2S1VP")).SendKeys(drlink[0] + Keys.Shift + Keys.Enter);
//                                    Thread.Sleep(5000);
//                                    list.FindElement(By.ClassName("_2S1VP")).SendKeys(Keys.Enter);
//                                }
//                                catch
//                                {
//                                    continue;
//                                }
//                            }
//                        }

//                    }
//                    DataSet dsGet = GetDataSet("update top(5) links set Message_Send=1 , senddate=getdate()  where isActive=1 and Message_Send=0 and cast(senddate as date) <> cast(GETDATE() as date) or senddate is null or Message_Send is null");

//                }
//                //_3F6QL _3xlwb _3F6QL _2WovP  driver.FindElement(By.XPath("//span[@title='WIT']")).Click();





//                Thread.Sleep(600000);
//            }
//            catch (Exception ex)
//            {
//                send();
//            }
//        }
//    }
//}

