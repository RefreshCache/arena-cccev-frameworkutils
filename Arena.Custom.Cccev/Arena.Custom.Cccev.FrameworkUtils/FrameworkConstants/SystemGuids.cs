/**********************************************************************
* Description:	TBD
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	TBD
*
* $Workfile: SystemGuids.cs $
* $Revision: 9 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/FrameworkConstants/SystemGuids.cs   9   2012-05-21 14:26:52-07:00   nicka $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/FrameworkConstants/SystemGuids.cs $
*  
*  Revision: 9   Date: 2012-05-21 21:26:52Z   User: nicka 
*  Changes for smart phone checkin by coordinates 
*  http://redmine.refreshcache.com/issues/463 
*  
*  Revision: 8   Date: 2011-11-02 20:41:43Z   User: JasonO 
*  Adding well known Guid for Facebook Opt Out setting. 
*  
*  Revision: 7   Date: 2010-05-20 02:12:51Z   User: nicka 
*  Added Facebook attrib, Web Preference attrib and attrib group 
*  
*  Revision: 6   Date: 2010-01-20 22:43:00Z   User: JasonO 
*  
*  Revision: 5   Date: 2009-12-15 21:42:40Z   User: JasonO 
*  
*  Revision: 4   Date: 2009-11-25 20:46:55Z   User: JasonO 
*  Adding ability level guid to list. 
*  
*  Revision: 3   Date: 2009-07-15 18:16:05Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-06-22 21:34:43Z   User: JasonO 
**********************************************************************/

using System;

namespace Arena.Custom.Cccev.FrameworkUtils.FrameworkConstants
{
    public static class SystemGuids
    {
        /// <summary>
        /// Attribute Group Guids
        /// </summary>
        public static readonly Guid WEB_PREFS_ATTRIBUTE_GROUP = new Guid("579a7002-5727-4564-bd99-ac0f2fc9b8aa");

        /// <summary>
        /// Attribute Guids
        /// </summary>
        public static readonly Guid FACEBOOK_USER_ID_ATTRIBUTE = new Guid("FEC1BE61-00B1-448D-8E91-B9BE7B283C4A");
        public static readonly Guid FACEBOOK_OPT_OUT_ATTRIBUTE = new Guid("20554957-A37A-498D-8592-92AA52B95AF4");
        public static readonly Guid WEB_PREFS_NEWS_TOPICS_ATTRIBUTE = new Guid("fe55cffb-5225-4908-9ea2-954354487558");

        /// <summary>
        /// Lookup Guids
        /// </summary>
        public static readonly Guid HR_PERSON_HISTORY_LOOKUP = new Guid("0ce29fde-6e6e-4ebe-8725-e839dafd3851");
        public static readonly Guid CHECKIN_APP_LOG_TYPE_LOOKUP = new Guid("2A33F0EA-10F8-416C-B341-AEB7D0C08190");

        /// <summary>
        /// Lookup Type Guids
        /// </summary>
        public static readonly Guid APP_LOG_TYPE_LOOKUP_TYPE = new Guid("b79dbfb8-a7ee-407d-9d5a-b851cd60cfe1");
        public static readonly Guid ABILITY_LEVEL_LOOKUP_TYPE = new Guid("b242694f-13dd-4eb9-9d03-6b58e62f11ec");
        public static readonly Guid CAMPUS_LOOKUP_TYPE = new Guid("FB0AC12E-630C-4792-BF9E-32442D7FEA62");
        public static readonly Guid CHECKIN_PRINT_PROVIDER_LOOKUP_TYPE = new Guid("420221aa-8c79-435b-b884-fa3f6855d0d1");
        public const string CHECKIN_PRINT_PROVIDER_LOOKUP_TYPE_STRING = "420221aa-8c79-435b-b884-fa3f6855d0d1";
		public static readonly Guid CHECKIN_KIOSK_COORDS_LOOKUP_TYPE = new Guid( "D1C5F10A-ADB6-43BA-8296-09F5702A66AD" );
    }
}