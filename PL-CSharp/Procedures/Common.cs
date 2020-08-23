using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using ViewModel.ViewModel.WebPos.PL_CSharp;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace PL_CSharp.Procedures
{
    public class Common
    {
        public object ClsOperations { get; private set; }

        public void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                // If file found, delete it    
                File.Delete(fileName);
            }

        }

        public void LogMessage(string fileName, string message)
        {
            StreamWriter sw = new StreamWriter(fileName, true);

            sw.Write(message);
            sw.Close();

        }
        public string CallWebServiceWithList<T>(string url, string contentType, T servicModel, string methodType)
        {
            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Method = methodType;

                List<T> servicModels = new List<T>();

                servicModels.Add(servicModel);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string request = JsonConvert.SerializeObject(servicModels, Newtonsoft.Json.Formatting.None);
                    streamWriter.Write(request);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();

                    return result;

                }

            }
            catch (Exception exp)
            {

                return exp.Message;
            }
        }

        public string CallWebServiceWithList<T>(string url, string contentType, List<T> servicModels, string methodType)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Method = methodType;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string request = JsonConvert.SerializeObject(servicModels, Newtonsoft.Json.Formatting.None);
                    streamWriter.Write(request);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    return result;

                }

            }
            catch (Exception exp)
            {

                return exp.Message;
            }

         }

        //public string GetPersianDateNow()
        //{
        //    string PersianDAte = string.Empty;
        //    Dim Query As String = "select GetPersianDateNow() from Dual"
        //}
    //    Public Function GetPersianDateNow() As String
    //    Try
    //        Dim PersianDate As String = String.Empty
    //        Dim Query As String = "select GetPersianDateNow() from Dual"
    //        MyBase.BeginProc()
    //        PersianDate = MyBase.Execute_Scalar(CommandType.Text, Query, "")
    //        MyBase.EndProc()
    //        Return PersianDate
    //    Catch ex As Exception
    //        Throw ex
    //    End Try
    //End Function


        public string CallWebService<T>(string url, string contentType, T servicModel, string methodType)
        {
            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = contentType;
                httpWebRequest.Method = methodType;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string request = JsonConvert.SerializeObject(servicModel, Newtonsoft.Json.Formatting.None);
                    streamWriter.Write(request);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();

                    return result;

                }

            }
            catch (Exception exp)
            {

                return exp.Message;
            }
        }

    }
}
