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
                Program p = new Program();
                p.send();
               //p.sendd();


            }
            catch (Exception)
            {
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
                if (contact == contactno)
                {
                    var lists = driver.FindElement(By.ClassName("_2ig1U"));

                    var listsss = lists.FindElement(By.ClassName("copyable-area"));
                    var list2 = listsss.FindElement(By.ClassName("DuUXI"));
                    var lists3 = list2.FindElement(By.ClassName("_2HE1Z"));
                    var listsssss = lists3.FindElement(By.ClassName("copyable-text"));
                    listsssss.SendKeys(msg + Keys.Enter);
                }
                else
                {
                    contact = contactno;
                    Thread.Sleep(15000);
                
                    driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91" + contactno);
                    //driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91" + 7696249893);
                    Thread.Sleep(15000);
                    Thread.Sleep(15000);
                  
                    var lists = driver.FindElement(By.ClassName("_2ig1U"));

                    var listsss = lists.FindElement(By.ClassName("copyable-area"));
                    var list2 = listsss.FindElement(By.ClassName("DuUXI"));
                    var lists3 = list2.FindElement(By.ClassName("_2HE1Z"));
                    var listsssss = lists3.FindElement(By.ClassName("copyable-text"));
                    listsssss.SendKeys(msg + Keys.Enter);
                }
            }
            catch
            {
               
            }
          
        }
        public  void sendd()
        {
            try
            { 
            
                //string query = "select Query from querytable where queryfor = 'dueorder'";
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
            String ConnectionString = "server=192.168.1.24,1433;uid=sa;pwd=Satcap@2020;database=GenDataSatcapIndia;Timeout=3000;";

            ; return ConnectionString;


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
                            Thread.Sleep(25000);

                            var listss = driver.FindElement(By.ClassName("_2ig1U"));

                            var list2 = listss.FindElement(By.ClassName("copyable-area"));

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

                            var lists = driver.FindElement(By.ClassName("_2ig1U"));

                            var listsss = lists.FindElement(By.ClassName("copyable-area"));
                            var list2 = listsss.FindElement(By.ClassName("_3qpzV"));
                            var listsssss = list2.FindElement(By.ClassName("_2wfYK"));
                            listsssss.Click();
                            Thread.Sleep(5000);
                            var list4 = listsssss.FindElement(By.ClassName("eBZuM"));
                            var list5 = list4.FindElement(By.ClassName("_2c4Sf"));
                            var list6 = list5.FindElement(By.ClassName("_1hhxx"));
                            var list7 = list6.FindElement(By.CssSelector("ul > li:nth-child(3)"));
                            Thread.Sleep(2000);
                            list7.FindElement(By.CssSelector("input[type='file']")).SendKeys(filePathMainInvoice);
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
        public  void smslog(int id)
        {
            string query= "INSERT INTO msglog (msgid,msgsendon)VALUES("+id+", getdate())";
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
                if (DateTime.Now.DayOfWeek.ToString()=="Monday" && DateTime.Now.Hour == 14 && DateTime.Now.Minute==55)
                {
                    SendDueMessage();
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
                        id =Convert.ToInt32( dr[0]);
                        if (dr[1].ToString() == "Order")
                        {
                            //if (dr[8].ToString() != "1034")
                            //{
                              
                                string url = "http://backoffice.satcapindia.info/order/SendOrderwhtsapp?orderId=" + dr[2];
                                // string url = "http://localhost:49916/checkout/SendOrderwhtsapp?orderId=" + dr[2];
                                //   string filePathMainInvoice = "C:\\inetpub\\wwwroot\\SatcapIndia\\Files\\SatcapOrder_" + dr[2] + "_"+dr[8]+".pdf"; //" C:\\Users\\Satcap\\Downloads\\SatcapInvoice_" + dr[2] + ".pdf";
                                // string filePathMainInvoice = "http://www.satcapindia.com/Files/SatcapOrder_" + dr[2] + "_" + dr[8] + ".pdf";
                                // string filePathMainInvoice = "D:\\Projects\\SatcapIndia\\SatcapIndia\\SatcapIndia\\Files\\SatcapOrder_" + dr[2] + "_" + dr[8] + ".pdf";
                                string filePathMainInvoice = " C:\\Users\\Administrator\\Downloads\\SatcapOrder_" + dr[2] + "_" + dr[8] + ".pdf";
                            //string filePathMainInvoice = " C:\\inetpub\\wwwroot\\SatcapIndiaAdmin\\Files\\SatcapOrder_" + dr[2] + "_" + dr[8] + ".pdf";

                            //string filePathMainInvoice = " C:\\Users\\Administrator\\Downloads\\SatcapOrder_" + dr[2] + "_" + dr[8] + ".pdf";

                            sendwhastsapp(dr, filePathMainInvoice, url,"order");
                            //}
                            //else
                            //{
                            //    updateSms(id);

                            //}
                            
                                    
                        }
                        else
                        { 
                            string url = "http://192.168.1.24:81/order/Invoicedownload?invno=" + dr[2];

                          // string filePathMainInvoice = " C:\\Users\\Administrator\\Downloads\\SatcapInvoice_" + dr[2] + ".pdf";
                            //string url = "http://localhost:57395/order/Invoicedownload?invno=" + dr[2];
                            string filePathMainInvoice = " C:\\Users\\Administrator\\Downloads\\SatcapInvoice_" + dr[2] + ".pdf";

                            sendwhastsapp(dr, filePathMainInvoice, url,"Invoice");

                        }

                        //updateSms(id);

                    }
                }
                else
                {
                    Console.WriteLine("Run after 60 second");
                    Thread.Sleep(50000);
                    send();
                }

              
            }
            catch (Exception ex)
            {
                Thread.Sleep(5000);

                send();
            }
        }
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

