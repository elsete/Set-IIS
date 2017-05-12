using Microsoft.Web.Administration;
using SetIIS.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SetIIS.Util
{
    public static class IIS
    {
        #region Public Methods

        public static List<Application> GetApplications()
        {
            List<Application> lstReturn = new List<Application>();

            using (ServerManager iisManager = new ServerManager())
            {
                foreach (Site site in iisManager.Sites)
                {
                    foreach (Application app in site.Applications)
                    {
                        if (app.Path.Length > 1)
                        {
                            string sAppName = Path.GetFileName(app.Path);
                            if (!string.IsNullOrEmpty(sAppName))
                            {
                                lstReturn.Add(app);
                            }
                        }
                    }
                }
            }

            return lstReturn;
        }

        public static string SaveChanges(Config oConfig)
        {
            string sReturn = string.Empty;

            try
            {
                Branch oBranch = oConfig.GetLastBranch();
                if (null != oBranch)
                {
                    using (ServerManager iisManager = new ServerManager())
                    {
                        foreach (Site site in iisManager.Sites)
                        {
                            foreach (Application app in site.Applications)
                            {
                                string sSite = Path.GetFileName(app.Path);
                                if (!string.IsNullOrEmpty(sSite))
                                {
                                    IISSite oSite = oBranch.GetSite(Path.GetFileName(sSite));
                                    if (null != oSite)
                                    {
                                        VirtualDirectory oVirtualDirectory = app.VirtualDirectories.Where(vDir => vDir.Path == "/").Single();
                                        if (null != oVirtualDirectory)
                                        {
                                            oVirtualDirectory.PhysicalPath = oSite.Path;
                                        }
                                    }
                                }
                            }
                        }

                        iisManager.CommitChanges();
                    }
                }
                else {
                    sReturn = "Seleccionar Branch";
                }
            }
            catch (Exception Ex)
            {
                sReturn = Ex.Message;
            }

            return sReturn;
        }

        public static void Reset()
        {
            try
            {
                Process iisReset = new Process();
                iisReset.StartInfo.CreateNoWindow = true;
                iisReset.StartInfo.FileName = "iisreset.exe";
                iisReset.StartInfo.RedirectStandardOutput = true;
                iisReset.StartInfo.UseShellExecute = false;
                iisReset.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                iisReset.Start();
                iisReset.WaitForExit();
            }
            catch(Exception Ex)
            {

            }
        }

        #endregion
    }
}
