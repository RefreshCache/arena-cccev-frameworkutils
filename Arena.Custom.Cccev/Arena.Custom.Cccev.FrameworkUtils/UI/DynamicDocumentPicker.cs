/**********************************************************************
* Description:	TBD
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	TBD
*
* $Workfile: DynamicDocumentPicker.cs $
* $Revision: 2 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/UI/DynamicDocumentPicker.cs   2   2010-01-11 14:36:25-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/UI/DynamicDocumentPicker.cs $
*  
*  Revision: 2   Date: 2010-01-11 21:36:25Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-07-07 20:40:59Z   User: JasonO 
**********************************************************************/

using Arena.Custom.Cccev.FrameworkUtils.Entity;
using Arena.Portal.UI;

namespace Arena.Custom.Cccev.FrameworkUtils.UI
{
    public class DynamicDocumentPicker : DocumentPicker, IDynamicValue
    {
        public string Value
        {
            get { return DocumentID.ToString(); }
        }
    }
}
