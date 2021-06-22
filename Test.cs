using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

public class Test
{
    public static string url = "https://dvc-cgy.projects.greenglobal.vn/";
    public static string data = @"{
                    ""tenDayDu"":""ZALOID:"",
                    ""email"":""minh@gmail.com"",
                    ""soDienThoai"":""02361022"",
                    ""tieuDe"":""ZALO GÓP Ý"",
                    ""noiDungYKien"":""ZALO_TEST_GOPY"",
                    ""noiDienRa"":""02 Quang trung"",
                    ""ngayDienRa"":""2020-02-20"",
                    ""thoiGianDienRa"":""07:00"",
                    ""nguonGopY"":""ZALO"",
                    ""linhVucId"":"""",
                    ""videos"":"""",
                    ""amThanh"":"""",
                    ""hinhAnhs"":[{
                        ""url"":""https://photo-3-baomoi.zadn.vn/w700_r16x9_sm/2020_02_20_194_34028669/aeb98635ac7645281c67.jpg"",
                        ""ten"":""baomoi.jpg""
                    }],
                    ""fileDinhKem"":{

                        ""url"":"""",
                        ""ten"":""""
                    }
                    }";
    public static string getToken()
    {
        string user = "testapi", password = "Gopy@123";
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(user + ":" + password));
    }

    public static void post()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("url");
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string user = "testapi", password = "Gopy@123";
            string userAndPasswordToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(user + ":" + password));

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", userAndPasswordToken);

            var content = new StringContent(
                data,
                System.Text.Encoding.UTF8,
                "application/json"
                );

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = client.PostAsync("api/gopy", content).Result;
            string resultContent = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(resultContent);
        }
    }

    public static void post1()
    {
        try
        {
            string webAddr = url + "api/gopy";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.Headers.Add("Authorization", "Basic " + getToken());
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                Console.WriteLine(responseText);

                //Now you have your response.
                //or false depending on information in the response
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}