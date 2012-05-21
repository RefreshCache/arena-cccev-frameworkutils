/**********************************************************************
* Description:  Encapsulates common data access functionality for Person
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 8/25/2011
*
* $Workfile: PersonDataExtension.cs $
* $Revision: 1 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/PersonDataExtension.cs   1   2011-08-25 17:13:29-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Data/PersonDataExtension.cs $
*  
*  Revision: 1   Date: 2011-08-26 00:13:29Z   User: JasonO 
*  Stubbing out basic functionality to fetch a person from db by facebook id. 
**********************************************************************/

using System;
using System.Collections;
using System.Data.SqlClient;
using Arena.DataLayer.Core;

namespace Arena.Custom.Cccev.FrameworkUtils.Data
{
    public static class PersonDataExtension
    {
        public static SqlDataReader FindByFacebookIdAndAttributeGuid(this PersonData personData, string facebookID, Guid attributeGuid)
        {
            var list = new ArrayList();
            list.Add(new SqlParameter("@FacebookID", facebookID));
            list.Add(new SqlParameter("@AttributeGuid", attributeGuid));

            try
            {
                return personData.ExecuteSqlDataReader("cust_cccev_core_getPersonListByFacebookIdAndAttributeGuid", list);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
