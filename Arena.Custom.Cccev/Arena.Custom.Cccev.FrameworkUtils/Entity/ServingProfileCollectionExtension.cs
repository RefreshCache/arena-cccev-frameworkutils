/**********************************************************************
* Description:  Extension methods specific to serving tags
* Created By:   Dallon Feldner @ Central Christian Church of the East Valley
* Date Created: ???
*
* $Workfile: ServingProfileCollectionExtension.cs $
* $Revision: 1 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/ServingProfileCollectionExtension.cs   1   2010-07-21 15:19:20-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/ServingProfileCollectionExtension.cs $
*  
*  Revision: 1   Date: 2010-07-21 22:19:20Z   User: JasonO 
*  Refactoring generic arena-specific code into FrameworkUtils assembly. 
*  
*  Revision: 2   Date: 2010-01-27 22:00:24Z   User: JasonO 
**********************************************************************/

using System.Collections.Generic;
using System.Data.SqlClient;
using Arena.Core;
using Arena.DataLayer.Core;
using Arena.Enums;

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    public static class ServingProfileCollectionExtension
    {
        public static void GetProfileChildren(this ServingProfileCollection profiles, int parentID, int organizationID, ProfileType type)
        {
            SqlDataReader reader = new ProfileData().GetProfileHierarchy(parentID, organizationID, type, -1, string.Empty);
            Dictionary<int, ServingProfile> sps = new Dictionary<int, ServingProfile>();

            while (reader.Read())
            {
                int profileID = (int)reader["profile_id"];

                if (!sps.ContainsKey(profileID))
                {
                    sps.Add(profileID, new ServingProfile(profileID));
                    profiles.Add(sps[profileID]);
                }
            }

            reader.Close();
        }
    }
}
