using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;

namespace SchoolAs.Util.Satellite
{
    public class MessageResource
    {
        #region ATTRIBUTES

        // Default Language.
        private static string enUS = "en-US";

        // Singleton instance.
        private volatile static MessageResource messageResource;

        #endregion ATTRIBUTES


        private MessageResource()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(enUS);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(enUS);
        }



        public static MessageResource GetInstance()
        {
            object lockingObject = new object();

            if (messageResource == null)
            {
                lock (lockingObject)
                {
                    if (messageResource == null)
                    {
                        messageResource = new MessageResource();
                    }
                }
            }

            return messageResource;
        }


        public string GetText(string key, string baseName)
        {
            try
            {
                ResourceManager resourceManager = new System.Resources.ResourceManager(baseName, Assembly.GetExecutingAssembly());
                
                return (resourceManager == null) ? "" : resourceManager.GetString(key);
            }
            catch
            {
                return "";
            }
        }
    }
}
