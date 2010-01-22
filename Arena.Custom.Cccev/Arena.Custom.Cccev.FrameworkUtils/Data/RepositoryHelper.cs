/**********************************************************************
* Description:  Abstracting DataContext from Repositories
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/22/2009
*
* $Workfile: RepositoryHelper.cs $
* $Revision: 4 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/RepositoryHelper.cs   4   2010-01-11 14:36:25-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/RepositoryHelper.cs $
*  
*  Revision: 4   Date: 2010-01-11 21:36:25Z   User: JasonO 
*  
*  Revision: 3   Date: 2010-01-11 21:22:56Z   User: JasonO 
*  
*  Revision: 2   Date: 2010-01-04 22:18:11Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-12-22 18:07:26Z   User: JasonO 
**********************************************************************/

using System;
using System.Data.Linq;
using System.Reflection;
using Arena.Custom.Cccev.FrameworkUtils.Util;

namespace Arena.Custom.Cccev.FrameworkUtils.Data
{
    public class RepositoryHelper : ConfigurationBase
    {
        private const string DATA_CONTEXT_KEY = "Cccev.FrameworkUtils.DataContext";

        /// <summary>
        /// Will attemtp to load the current DataContext type.
        /// </summary>
        /// <returns>Linq to SQL DataContext</returns>
        public static DataContext GetDataContext()
        {
            string[] repositoryPath = GetConfigurationPath(DATA_CONTEXT_KEY);
            Assembly assembly = Assembly.Load(repositoryPath[0].Trim());

            if (assembly == null)
            {
                return null;
            }

            Type type = assembly.GetType(repositoryPath[1].Trim());
            return (DataContext) Activator.CreateInstance(type);
        }
    }
}
