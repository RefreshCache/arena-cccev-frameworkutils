/**********************************************************************
* Description:	TBD
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	TBD
*
* $Workfile: DynamicDropDownList.cs $
* $Revision: 4 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/UI/DynamicDropDownList.cs   4   2010-01-11 14:36:25-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/UI/DynamicDropDownList.cs $
*  
*  Revision: 4   Date: 2010-01-11 21:36:25Z   User: JasonO 
*  
*  Revision: 3   Date: 2009-07-21 01:02:11Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-07-15 18:16:05Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-07-07 20:40:59Z   User: JasonO 
**********************************************************************/

using System.Web.UI.WebControls;
using Arena.Custom.Cccev.DataUtils;
using Arena.Custom.Cccev.FrameworkUtils.Entity;

namespace Arena.Custom.Cccev.FrameworkUtils.UI
{
    public class DynamicDropDownList : DropDownList, IDynamicValue
    {
        public const string DEFAULT_SELECT_ITEM_TEXT = "-- Select --";
        public static readonly string DEFAULT_SELECT_ITEM_VALUE = Constants.NULL_INT.ToString();

        public string Value
        {
            get { return base.SelectedValue; }
        }

        public static ListItem GetDefaultSelectItem()
        {
            return new ListItem(DEFAULT_SELECT_ITEM_TEXT, DEFAULT_SELECT_ITEM_VALUE);
        }
    }
}
