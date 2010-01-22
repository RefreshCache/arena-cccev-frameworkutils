/**********************************************************************
* Description:	Basic application log entity object
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	7/15/2008
*
* $Workfile: AppLog.cs $
* $Revision: 2 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/AppLog.cs   2   2009-09-15 09:17:32-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/AppLog.cs $
*  
*  Revision: 2   Date: 2009-09-15 16:17:32Z   User: JasonO 
*  Optimizing for performance. Adding Compiled Query functionality to Linq 
*  statements. 
*  
*  Revision: 1   Date: 2009-07-15 18:16:05Z   User: JasonO 
**********************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using Arena.Custom.Cccev.DataUtils;
using Arena.DataLib;

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    [Table(Name = "cust_cccev_applog")]
    public class AppLog
    {
        private static readonly string CONNECTION = new SqlDbConnection().GetArenaConnectionString(ConfigurationManager.ConnectionStrings["Arena"].ToString());

        [Column(Name = "applog_id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int? AppLogID { get; set; }

        [Column(Name = "type_luid")]
        public int TypeLuid { get; set; }

        [Column(Name = "date")]
        public DateTime Date { get; set; }

        [Column(Name = "text")]
        public string Text { get; set; }

        public AppLog()
        {
            TypeLuid = Constants.NULL_INT;
            Date = Constants.NULL_DATE;
            Text = Constants.NULL_STRING;
        }

        public AppLog(int id)
        {
            if (!LoadByID(id, this))
            {
                throw new ArgumentException(string.Format("AppLog with ID of {0} not found!", id));
            }
        }

        public int Save()
        {
            Save(this);
            return AppLogID.Value;
        }

        public static bool LoadByID(int id, AppLog appLog)
        {
            if (appLog != null)
            {
                using (var context = new AppLogContext(CONNECTION))
                {
                    var data = AppLogCompiledQuery.GetAppLogByID(context, id).FirstOrDefault();

                    if (data != null)
                    {
                        appLog = new AppLog
                                     {
                                         AppLogID = data.AppLogID,
                                         TypeLuid = data.TypeLuid,
                                         Date = data.Date,
                                         Text = data.Text
                                     };
                        
                        return appLog.AppLogID.HasValue;
                    }
                }
            }

            return false;
        }

        public static List<AppLog> LoadByType(int typeID)
        {
            using (var context = new AppLogContext(CONNECTION))
            {
                return AppLogCompiledQuery.GetAppLogByType(context, typeID).ToList();
            }
        }

        private static void Save(AppLog appLog)
        {
            using (var context = new AppLogContext(CONNECTION))
            {
                if (!appLog.AppLogID.HasValue)
                {
                    context.GetTable<AppLog>().InsertOnSubmit(appLog);
                }

                context.SubmitChanges();
            }
        }
    }

    public class AppLogContext : DataContext
    {
        public AppLogContext(string connection) : base(connection)
        {
        }
    }

    public class AppLogCompiledQuery
    {
        public static Func<DataContext, int, IQueryable<AppLog>> GetAppLogByID =
            CompiledQuery.Compile((DataContext db, int id) => from al in db.GetTable<AppLog>()
                                                              where al.AppLogID == id
                                                              select al);

        public static Func<DataContext, int, IQueryable<AppLog>> GetAppLogByType =
            CompiledQuery.Compile((DataContext db, int typeID) => from al in db.GetTable<AppLog>()
                                                                  where al.TypeLuid == typeID
                                                                  select al);
    }
}