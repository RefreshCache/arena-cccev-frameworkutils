/**********************************************************************
* Description: 
* Created By:   Nick Airdo @ Central Christian Church of the East Valley
* Date Created:	05/03/2009 17:42:02
*
* $Workfile: SqlDataExtension.cs $
* $Revision: 1 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/SqlDataExtension.cs   1   2010-07-21 15:19:20-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/SqlDataExtension.cs $
*  
*  Revision: 1   Date: 2010-07-21 22:19:20Z   User: JasonO 
*  Refactoring generic arena-specific code into FrameworkUtils assembly. 
*  
*  Revision: 2   Date: 2010-01-27 22:00:24Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-05-04 17:40:32Z   User: nicka 
**********************************************************************/

using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using Arena.DataLib;
using System.Collections;

namespace Arena.Custom.Cccev.FrameworkUtils.Data
{
	public static class SqlDataExtension
	{
		/// <summary>
		/// A public version of Arena's ExecuteSqlDataReader class.
		/// </summary>
		/// <param name="sqlData"></param>
		/// <param name="storedProcedure"></param>
		/// <param name="list"></param>
		/// <returns></returns>
		public static SqlDataReader ExecuteSqlDataReader( this SqlData sqlData, string storedProcedure, ArrayList list )
		{
			SqlDataReader reader;
			SqlConnection dbConnection = new SqlDbConnection().GetDbConnection();
			SqlCommand command = new SqlCommand( storedProcedure, dbConnection );
			command.CommandTimeout = 360;
			command.CommandType = CommandType.StoredProcedure;

			for ( int i = 0; i <= ( list.Count - 1 ); i++ )
			{
				command.Parameters.Add( (SqlParameter)list[ i ] );
			}

			try
			{
				dbConnection.Open();
				reader = command.ExecuteReader( CommandBehavior.CloseConnection );
			}
			catch ( SqlException exception )
			{
				throw exception;
			}
			return reader;
		}

        /// <summary>
        /// A public version of Arena's SqlData ExecuteDataTable method
        /// </summary>
        /// <param name="sqlData"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(this SqlData sqlData, string storedProcedureName, ArrayList paramList)
        {
            DataTable table;
            SqlConnection dbConnection = new SqlDbConnection().GetDbConnection();
            SqlCommand selectCommand = new SqlCommand
            {
                CommandTimeout = 360
            };
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            string dataSetName = ((MethodInfo)new StackTrace().GetFrame(1).GetMethod()).Name.ToString();
            DataSet dataSet = new DataSet(dataSetName);
            selectCommand.Connection = dbConnection;
            selectCommand.CommandText = storedProcedureName;
            selectCommand.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i <= (paramList.Count - 1); i++)
            {
                selectCommand.Parameters.Add((SqlParameter)paramList[i]);
            }

            try
            {
                dbConnection.Open();
                adapter.Fill(dataSet, dataSetName);
                dbConnection.Close();
                table = dataSet.Tables[0];
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            finally
            {
                dbConnection = null;
                selectCommand = null;
                adapter = null;
            }
            return table;
        }
	}
}
