/**********************************************************************
* Description:  Encapsulates extended funcitonality to load groups of people
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 8/25/2011
*
* $Workfile: PersonCollectionExtension.cs $
* $Revision: 2 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/PersonCollectionExtension.cs   2   2011-11-02 13:41:43-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/Entity/PersonCollectionExtension.cs $
*  
*  Revision: 2   Date: 2011-11-02 20:41:43Z   User: JasonO 
*  Adding well known Guid for Facebook Opt Out setting. 
*  
*  Revision: 1   Date: 2011-08-26 00:13:29Z   User: JasonO 
*  Stubbing out basic functionality to fetch a person from db by facebook id. 
**********************************************************************/

using System;
using Arena.Core;
using Arena.Custom.Cccev.FrameworkUtils.Data;
using Arena.Custom.Cccev.FrameworkUtils.FrameworkConstants;
using Arena.DataLayer.Core;

namespace Arena.Custom.Cccev.FrameworkUtils.Entity
{
    public static class PersonCollectionExtension
    {
        public static void LoadByFacebookIdAndAttributeGuid(this PersonCollection personCollection, string facebookID, Guid attributeGuid)
        {
            using (var reader = new PersonData().FindByFacebookIdAndAttributeGuid(facebookID, SystemGuids.FACEBOOK_USER_ID_ATTRIBUTE))
            {
                while (reader.Read())
                {
                    personCollection.Add(new Person(reader));
                }
            }
        }
    }
}
