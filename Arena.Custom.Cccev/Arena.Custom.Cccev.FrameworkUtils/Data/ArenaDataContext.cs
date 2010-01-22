/**********************************************************************
* Description:  Allows for Linq to SQL integration with Arena Database
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/9/2009
*
* $Workfile: ArenaDataContext.cs $
* $Revision: 3 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/ArenaDataContext.cs   3   2009-12-22 11:07:27-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/ArenaDataContext.cs $
*  
*  Revision: 3   Date: 2009-12-22 18:07:27Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-12-09 20:54:46Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-12-09 20:52:47Z   User: JasonO 
*  Adding ArenaDataContext 
**********************************************************************/

using System.Configuration;
using System.Data.Linq;
using Arena.DataLib;

namespace Arena.Custom.Cccev.FrameworkUtils.Data
{
    public class ArenaDataContext : DataContext
    {
        public static readonly string CONNECTION_STRING = new SqlDbConnection().GetArenaConnectionString(
            ConfigurationManager.ConnectionStrings["Arena"].ToString());

        public ArenaDataContext() : this(CONNECTION_STRING) { }

        public ArenaDataContext(string connectionString) : base(connectionString) { }
    }
}
