using System;
using System.Text;
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
                msg = msg.Replace("&", "and");
                contact = contactno;
                Thread.Sleep(15000);
                string msgnew = "https://web.whatsapp.com/send?phone=91" + contactno + "&text=" + msg;
                driver.Navigate().GoToUrl(msgnew);
                Thread.Sleep(20000);
                driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();

                //}
            }
            catch
            {

            }

        }
        //public  void sendd()
        //{
        //    try
        //    {
        //        var lists = driver.FindElement(By.ClassName("_30KVb"));

        //        var listsss = lists.FindElement(By.ClassName("copyable-area"));
        //        var list2 = listsss.FindElement(By.ClassName("_1un-p"));
        //        var listsssss = list2.FindElement(By.ClassName("_2jitM"));
        //        listsssss.Click();
        //        Thread.Sleep(5000);
        //        var list4 = listsssss.FindElement(By.ClassName("_3iTtj"));
        //        var list5 = list4.FindElement(By.ClassName("_1lPfJ"));
        //        var list6 = list5.FindElement(By.ClassName("_1HnQz"));
        //        var list7 = list6.FindElement(By.CssSelector("ul > li:nth-child(3)"));

        //    }
        //    catch(Exception ex)
        //    {
        //        sendd();
        //    }

        //}
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
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2] + " " + dr[3]);
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
                            sendwhatsappDuemessage(dr[0].ToString(), dr[3].ToString());
                        }
                    }
                    catch
                    {

                    }

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
            String ConnectionString = "server=192.168.0.254,1433;" +
            "uid=sa;" +
            "pwd=Satcap@2020;" +
            "database=GenDataSatcapIndia;Timeout=3000;";

            return ConnectionString;
            //return @"Data Source=happy;Initial Catalog=Final;Integrated Security=True";
        }
        public static string orderwithmobile = "";
        public bool CheclMsgSend(int id)
        {
            string query = "select max(msgid) from msglog";
            DataSet dsGetUsers = GetDataSet(query);
            int Datet = Convert.ToInt32(dsGetUsers.Tables[0].Rows[0][0]);
            if (Datet < id)
            {
                return true;
            }
            return false;
        }
        public void smslog(int id)
        {
            string query = "INSERT INTO msglog (msgid,msgsendon)VALUES(" + id + ", getdate())";
            DataSet dsGetUsers = GetDataSet(query);

        }
        public void smsPromotionlog(int id, string contactno)
        {
            string query = "INSERT INTO msglog (msgid,msgsendon,ContactNo)VALUES(" + id + ", getdate()," + contactno + ")";
            DataSet dsGetUsers = GetDataSet(query);

        }
        public void updateSms(int id)
        {
            DataSet dsGetUsers = GetDataSet("update   whatsappmsgsend set IsWhatsAppMsg=1 where Sendid=" + id);

        }

        public void send()
        {

            int id = 0;

            try
            {

                string timequery = "select time from msgtime where id=1";
                DataSet dsGetUser1 = GetDataSet(timequery);
                DateTime Datet = Convert.ToDateTime(dsGetUser1.Tables[0].Rows[0][0].ToString());
                if (DateTime.Now.Hour == Datet.Hour && DateTime.Now.Minute >= Datet.Minute && DateTime.Now.Minute <= Datet.Minute + 10 && Datet.DayOfWeek.ToString() == DateTime.Now.DayOfWeek.ToString())
                {
                    SendDueMessage();
                }


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

                                    try
                                    {
                                        string GetnameofCustomer = " select ISNULL(c.CompName,c.FirstName+' '+c.LastName) as name from orderinfo o " +
                                            " inner join CustomerMst c  on o.UserId = c.CustID  where orderid = " + dr[2];
                                        DataSet dsGUser = GetDataSet(GetnameofCustomer);
                                        string CustomerName = dsGUser.Tables[0].Rows[0][0].ToString().Replace("&", "and");
                                        String message = "Dear " + CustomerName + ", Thanks for your Sale order No. " + dr[2] + ". You can download your order on  https://backoffice.satcapindia.info/order/d/" + EncryptDecryptStringHelper.EncryptString(dr[2].ToString());
                                        // string Urlinv = "https://web.whatsapp.com/send?phone=917009400781&text=" + message;
                                        string Urlinv = "https://web.whatsapp.com/send?phone=91" + dr[7] + "&text=" + message;
                                        driver.Navigate().GoToUrl(Urlinv);
                                        Thread.Sleep(60000);
                                        driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();
                                        Thread.Sleep(5000);
                                        updateSms(Convert.ToInt32(dr[0]));
                                        smslog(id);
                                    }
                                    catch (Exception ex)
                                    {
                                        updateSms(Convert.ToInt32(dr[0]));
                                        smslog(id);
                                    }



                                }
                                else if (dr[1].ToString() == "Promotion")
                                {
                                    //driver.Navigate().GoToUrl(dr[7].ToString());
                                    sendwhastsappPromotion(dr, dr[7].ToString(), dr[7].ToString(), "Promotion");

                                }
                                else if (dr[1].ToString() == "tpt" || dr[1].ToString() == "inv")
                                {
                                    //driver.Navigate().GoToUrl(dr[7].ToString());
                                    // sendwhastsappTPT(dr, dr[9].ToString(), dr[9].ToString(), "tpt");

                                    try
                                    {
                                        String message = "";
                                        string GetnameofCustomer = " select ISNULL(c.CompName,c.FirstName+' '+c.LastName) as name from OrderInvoiceDtl o " +
                                            "  inner join OrderInfo oi on oi.OrderID=o.OrderId inner join CustomerMst c  on oi.UserId = c.CustID where o.InvoiceNo = cast(" + dr[2] + " as varchar(20)) ";
                                        DataSet dsGUser = GetDataSet(GetnameofCustomer);
                                        string CustomerName = dsGUser.Tables[0].Rows[0][0].ToString().Replace("&", "and"); ;
                                        if (dr[1].ToString() == "tpt")
                                            message = "Dear " + CustomerName + ", Bilty is uploaded for your Invoice No. " + dr[2] + ". You can download  on  https://backoffice.satcapindia.info/invoice/t/" + EncryptDecryptStringHelper.EncryptString(dr[2].ToString());
                                        else
                                            message = "Dear " + CustomerName + ", Thanks for your Invoice No. " + dr[2] + ". You can download on  https://backoffice.satcapindia.info/invoice/ui/" + EncryptDecryptStringHelper.EncryptString(dr[2].ToString());

                                        //  string Urlinv = "https://web.whatsapp.com/send?phone=917009400781&text=" + message;
                                        string Urlinv = "https://web.whatsapp.com/send?phone=91" + dr[7] + "&text=" + message;
                                        driver.Navigate().GoToUrl(Urlinv);
                                        Thread.Sleep(60000);
                                        driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();
                                        Thread.Sleep(5000);
                                        updateSms(Convert.ToInt32(dr[0]));
                                        smslog(id);
                                    }
                                    catch (Exception ex)
                                    {
                                        updateSms(Convert.ToInt32(dr[0]));
                                        smslog(id);
                                    }

                                }
                                else
                                {
                                    try
                                    {
                                        string GetnameofCustomer = " select ISNULL(c.CompName,c.FirstName+' '+c.LastName) as name from InvoiceMst o " +
                                         " inner join CustomerMst c  on o.ImUserId = c.CustID  where ImInvNo = " + dr[2];
                                        DataSet dsGUser = GetDataSet(GetnameofCustomer);
                                        string CustomerName = dsGUser.Tables[0].Rows[0][0].ToString().Replace("&", "and"); ;
                                        String message = "Dear " + CustomerName + ", Thanks for your Invoice No. " + dr[2] + " has been generated. You can download your invoice on  https://backoffice.satcapindia.info/invoice/d/" + EncryptDecryptStringHelper.EncryptString(dr[2].ToString());

                                        string Urlinv = "https://web.whatsapp.com/send?phone=91" + dr[7] + "&text=" + message;
                                        driver.Navigate().GoToUrl(Urlinv);
                                        Thread.Sleep(60000);
                                        driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();
                                        Thread.Sleep(5000);
                                        updateSms(Convert.ToInt32(dr[0]));
                                        smslog(id);

                                    }
                                    catch (Exception ex)
                                    {
                                        updateSms(Convert.ToInt32(dr[0]));
                                        smslog(id);
                                    }


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
                    Console.WriteLine("Run after 10 Minute");
                    Thread.Sleep(10 * 60 * 1000);
                    send();
                }
                Console.WriteLine("Run after 10 Minute");
                Thread.Sleep(10 * 60 * 1000);

                send();

            }
            catch (Exception ex)
            {
                Thread.Sleep(600000);

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
                                if (drt[0].ToString().Length == 10)
                                {
                                    // driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=917009400781" );
                                    driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=91" + drt[0]);
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
                                    li.SendKeys(dr[9].ToString() + Keys.Enter);
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
                        {
                            if (CheclMsgSend(Convert.ToInt32(dr[0])))
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

        public static string EncryptString(string toEncrypt, bool useHashing = false)
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
            string base64 = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            return base64.Replace("/", "backSlash").Replace("+", "plus");
        }

        public static string DecryptString(string cipherString, bool useHashing = false)
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

    }

}

