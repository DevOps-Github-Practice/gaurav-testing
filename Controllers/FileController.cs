using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_V5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public FileController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();



        //}


        [HttpGet]
        public BETenant Get(string tenantName)
        {
            var result = GetTenantInfo(tenantName);
            return result;
        }

        //[HttpGet]
        //public string Get(string tenantName)
        //{
        //    //var rng = new Random();
        //    //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    //{
        //    //    Date = DateTime.Now.AddDays(index),
        //    //    TemperatureC = rng.Next(-20, 55),
        //    //    Summary = Summaries[rng.Next(Summaries.Length)]
        //    //})
        //    //.ToArray();


        //    return Directory.GetCurrentDirectory();



        //}


        //[HttpGet]
        //private BETenant GetTenantInfo(string TenantName)
        //{
        //    BETenant oTenant = null;
        //    DataSet ds = new DataSet();

        //    System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
        //    string codeBase = System.IO.Path.GetDirectoryName(ass.CodeBase);
        //    System.Uri uri = new Uri(codeBase);
        //    string XMLDirectoryPath = uri.LocalPath.Replace(@"\bin", "").Replace(@"\Debug", "").Replace(@"\net6.0", "");
        //    XMLDirectoryPath = XMLDirectoryPath + @"\Tenant.xml";
        //    ds.ReadXml(XMLDirectoryPath);

        //    if (ds == null || ds.Tables.Count <= 0)
        //    {
        //        return oTenant;
        //    }
        //    ds.Tables[0].CaseSensitive = false;

        //    var T = ds.Tables[0].Select("ClientName='" + TenantName.ToUpper() + "'");

        //    if (T != null && T.Count() > 0)
        //    {
        //        oTenant = new BETenant()
        //        {
        //            ApplicationHostName = T[0]["ApplicationHostName"].ToString(),
        //            ClientID = int.Parse(T[0]["ClientID"].ToString()),
        //            ClientName = T[0]["ClientName"].ToString(),
        //            DatabaseInstanceIP = T[0]["DatabaseInstanceIP"].ToString(),
        //            DatabaseName = T[0]["DatabaseInstanceName"].ToString(),
        //            TenantID = int.Parse(T[0]["ClientDeploymentID"].ToString()),
        //            XMLfilepath = XMLDirectoryPath,
        //            HBMReportDatabaseInstanceIP = T[0]["HBMReportDatabaseInstanceIP"].ToString(),
        //            HBMReportDatabaseInstanceName = T[0]["HBMReportDatabaseInstanceName"].ToString(),
        //            DataUtilityDatabaseInstanceName = T[0]["DataUtilityDatabaseInstanceName"].ToString(),
        //            DataUtilityDatabaseInstanceIP = T[0]["DataUtilityDatabaseInstanceIP"].ToString(),
        //            ADSDatabaseInstanceName = T[0]["ADSDatabaseInstanceName"].ToString(),
        //            ADSDatabaseInstanceIP = T[0]["ADSDatabaseInstanceIP"].ToString(),
        //            ClientMultiLanguage = T[0]["ClientMultiLanguage"].ToString().ToUpper() == "TRUE" ? true : false
        //        };
        //        // oTenant.DatabaseConnectionString = @"Server=" + T[0]["DatabaseInstanceIP"].ToString() + ";Trusted_Connection=True;database=" + T[0]["DatabaseInstanceName"].ToString() + "; Min Pool Size=10;Max Pool Size=500;MultipleActiveResultSets=True;");
        //        oTenant.DatabaseConnectionString = @"Server=" + T[0]["DatabaseInstanceIP"].ToString() + ";Trusted_Connection=True;database=" + T[0]["DatabaseInstanceName"].ToString() + "; Min Pool Size=10;Max Pool Size=500;MultipleActiveResultSets=True;";
        //        oTenant.HBMReportDatabaseConnectionString = @"Server=" + T[0]["HBMReportDatabaseInstanceIP"].ToString() + ";Trusted_Connection=True;database=" + T[0]["HBMReportDatabaseInstanceName"].ToString() + "; Min Pool Size=10;Max Pool Size=500;MultipleActiveResultSets=True;";
        //        oTenant.DataUtilityDatabaseConnectionString = @"Server=" + T[0]["DataUtilityDatabaseInstanceIP"].ToString() + ";Trusted_Connection=True;database=" + T[0]["DataUtilityDatabaseInstanceName"].ToString() + "; Min Pool Size=10;Max Pool Size=500;MultipleActiveResultSets=True;";
        //        oTenant.ADSDatabaseConnectionString = @"Server=" + T[0]["ADSDatabaseInstanceIP"].ToString() + ";Trusted_Connection=True;database=" + T[0]["ADSDatabaseInstanceName"].ToString() + "; Min Pool Size=10;Max Pool Size=500;MultipleActiveResultSets=True;";
        //    }
        //    return oTenant;
        //}

        [HttpGet]
        private BETenant GetTenantInfo(string TenantName)
        {
            BETenant oTenant = null;
            DataSet ds = new DataSet();

            //System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            //string codeBase = System.IO.Path.GetDirectoryName(ass.CodeBase);

            //var path = Path.Combine(Directory.GetCurrentDirectory(), "\\fileName.txt");

            



            //System.Uri uri = new Uri(codeBase);
            var XMLDirectoryPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"Tenant.xml");
            ds.ReadXml(XMLDirectoryPath);

            if (ds == null || ds.Tables.Count <= 0)
            {
                return oTenant;
            }
            ds.Tables[0].CaseSensitive = false;

            var T = ds.Tables[0].Select("ClientName='" + TenantName.ToUpper() + "'");

            if (T != null && T.Count() > 0)
            {
                oTenant = new BETenant()
                {
                    ApplicationHostName = T[0]["ApplicationHostName"].ToString(),
                    ClientID = int.Parse(T[0]["ClientID"].ToString()),
                    ClientName = T[0]["ClientName"].ToString(),
                    DatabaseInstanceIP = T[0]["DatabaseInstanceIP"].ToString(),
                    DatabaseName = T[0]["DatabaseInstanceName"].ToString(),
                    TenantID = int.Parse(T[0]["ClientDeploymentID"].ToString()),
                    XMLfilepath = XMLDirectoryPath,
                    HBMReportDatabaseInstanceIP = T[0]["HBMReportDatabaseInstanceIP"].ToString(),
                    HBMReportDatabaseInstanceName = T[0]["HBMReportDatabaseInstanceName"].ToString(),
                    DataUtilityDatabaseInstanceName = T[0]["DataUtilityDatabaseInstanceName"].ToString(),
                    DataUtilityDatabaseInstanceIP = T[0]["DataUtilityDatabaseInstanceIP"].ToString(),
                    ADSDatabaseInstanceName = T[0]["ADSDatabaseInstanceName"].ToString(),
                    ADSDatabaseInstanceIP = T[0]["ADSDatabaseInstanceIP"].ToString(),
                    ClientMultiLanguage = T[0]["ClientMultiLanguage"].ToString().ToUpper() == "TRUE" ? true : false
                };
                // oTenant.DatabaseConnectionString = @"Server=" + T[0]["DatabaseInstanceIP"].ToString() + ";Trusted_Connection=True;database=" + T[0]["DatabaseInstanceName"].ToString() + "; Min Pool Size=10;Max Pool Size=500;MultipleActiveResultSets=True;");
                oTenant.DatabaseConnectionString = @"Server=" + T[0]["DatabaseInstanceIP"].ToString() + ";Trusted_Connection=True;database=" + T[0]["DatabaseInstanceName"].ToString() + "; Min Pool Size=10;Max Pool Size=500;MultipleActiveResultSets=True;";
                oTenant.HBMReportDatabaseConnectionString = @"Server=" + T[0]["HBMReportDatabaseInstanceIP"].ToString() + ";Trusted_Connection=True;database=" + T[0]["HBMReportDatabaseInstanceName"].ToString() + "; Min Pool Size=10;Max Pool Size=500;MultipleActiveResultSets=True;";
                oTenant.DataUtilityDatabaseConnectionString = @"Server=" + T[0]["DataUtilityDatabaseInstanceIP"].ToString() + ";Trusted_Connection=True;database=" + T[0]["DataUtilityDatabaseInstanceName"].ToString() + "; Min Pool Size=10;Max Pool Size=500;MultipleActiveResultSets=True;";
                oTenant.ADSDatabaseConnectionString = @"Server=" + T[0]["ADSDatabaseInstanceIP"].ToString() + ";Trusted_Connection=True;database=" + T[0]["ADSDatabaseInstanceName"].ToString() + "; Min Pool Size=10;Max Pool Size=500;MultipleActiveResultSets=True;";
            }
            return oTenant;
        }
    }

    public class BETenant
    {
        public string ApplicationHostName { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string DatabaseInstanceIP { get; set; }
        public string DatabaseName { get; set; }
        public int TenantID { get; set; }
        public string XMLfilepath { get; set; }
        public bool ClientMultiLanguage { get; set; }
        public string HBMReportDatabaseInstanceIP { get; set; }
        public string HBMReportDatabaseInstanceName { get; set; }
        public string DataUtilityDatabaseInstanceName { get; set; } = "";
        public string DataUtilityDatabaseInstanceIP { get; set; } = "";
        public string ADSDatabaseInstanceName { get; set; } = "";
        public string ADSDatabaseInstanceIP { get; set; } = "";

        public string DatabaseConnectionString { get; set; } = "";
        public string HBMReportDatabaseConnectionString { get; set; } = "";
        public string DataUtilityDatabaseConnectionString { get; set; } = "";
        public string ADSDatabaseConnectionString { get; set; } = "";
    }
}
