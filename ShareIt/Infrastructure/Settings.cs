using System;
using System.Configuration;
using System.IO;
using System.Net;

namespace ShareIt.Infrastructure
{
    public static class Settings
    {
        public static string SmtpClientHost
        {
            get { return ConfigurationManager.AppSettings["smtp.host"]; }
        }

        public static NetworkCredential ReadCredentials()
        {
            string fileLocation = "";
            try
            {
                fileLocation = ConfigurationManager.AppSettings["smtp.credentials.fileLocation"];
                string[] readAllLines = File.ReadAllLines(fileLocation);
                return new NetworkCredential(readAllLines[0], readAllLines[1]);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException(
                    string.Format("File located at {0} doesn't contain a password", fileLocation));
            }
        }
    }
}