/**********************************************************************
* Description:  Abstracts retrieval of data access repository from application
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/8/2009
*
* $Workfile: RepositoryFactory.cs $
* $Revision: 2 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Util/RepositoryFactory.cs   2   2010-01-11 14:22:56-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Util/RepositoryFactory.cs $
*  
*  Revision: 2   Date: 2010-01-11 21:22:56Z   User: JasonO 
*  
*  Revision: 1   Date: 2010-01-04 22:16:37Z   User: JasonO 
*  Moving more generic logic to framework utils 
*  
*  Revision: 4   Date: 2009-12-30 17:35:42Z   User: JasonO 

**********************************************************************/

using System;
using System.Data.Linq;
using System.Reflection;
using Arena.Custom.Cccev.FrameworkUtils.Application;

namespace Arena.Custom.Cccev.FrameworkUtils.Util
{
    /// <summary>
    /// Class to manage instantiation of Repository objects at runtime.
    /// </summary>
    public class RepositoryFactory : ConfigurationBase
    {
        /// <summary>
        /// Will attempt to instantiate a Repository object given the configuration key.
        /// </summary>
        /// <typeparam name="T">Type of repository interface to instantiate</typeparam>
        /// <param name="key">Configuration key to query against</param>
        /// <returns>Repository object</returns>
        public static T GetRepository<T>(string key)
        {
            string[] repositoryPath = GetConfigurationPath(key);
            Assembly assembly = Assembly.Load(repositoryPath[0].Trim());
            Type type = assembly.GetType(repositoryPath[1].Trim());
            return (T) Activator.CreateInstance(type);
        }

        /// <summary>
        /// Will attempt to instantiate a Repository object given the configuration key and
        /// associate a DataContext to it.
        /// </summary>
        /// <typeparam name="T">Type of repository interface to instantiate</typeparam>
        /// <param name="key">Configuration key to query against</param>
        /// <param name="dataContext">DataContext to associate with the Repository</param>
        /// <returns>Repository object</returns>
        public static T GetRepository<T>(string key, DataContext dataContext)
        {
            string[] repositoryPath = GetConfigurationPath(key);
            Assembly assembly = Assembly.Load(repositoryPath[0].Trim());
            Type type = assembly.GetType(repositoryPath[1].Trim());
            return (T) Activator.CreateInstance(type, dataContext);
        }
    }
}
