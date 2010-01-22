/**********************************************************************
* Description:  Helper class to abstract certain aspects of Core.Person from Arena Database
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/9/2009
*
* $Workfile: PersonUtils.cs $
* $Revision: 4 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Util/PersonUtils.cs   4   2010-01-11 14:36:25-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Util/PersonUtils.cs $
*  
*  Revision: 4   Date: 2010-01-11 21:36:25Z   User: JasonO 
*  
*  Revision: 3   Date: 2010-01-11 21:29:11Z   User: JasonO 
*  
*  Revision: 2   Date: 2010-01-11 21:22:56Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-12-10 00:12:32Z   User: JasonO 
**********************************************************************/

using System;
using System.Reflection;
using Arena.Core;
using Arena.Custom.Cccev.FrameworkUtils.Entity;

namespace Arena.Custom.Cccev.FrameworkUtils.Util
{
    public class PersonUtils : ConfigurationBase
    {
        public const string CURRENT_PERSON_KEY = "Cccev.FrameworkUtils.CurrentPerson";

        public static Person GetCurrentPerson()
        {
            string[] repositoryPath = GetConfigurationPath(CURRENT_PERSON_KEY);
            Assembly assembly = Assembly.Load(repositoryPath[0].Trim());

            if (assembly == null)
            {
                return null;
            }

            Type type = assembly.GetType(repositoryPath[1].Trim());
            var factory = (IPersonFactory) Activator.CreateInstance(type);
            return factory.GetCurrentPerson();
        }
    }
}
