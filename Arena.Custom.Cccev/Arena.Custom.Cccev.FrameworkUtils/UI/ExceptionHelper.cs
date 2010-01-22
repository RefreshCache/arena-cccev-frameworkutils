/**********************************************************************
* Description:  Abstracts creation of error lists for exception handling
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/15/2009
*
* $Workfile: ExceptionHelper.cs $
* $Revision: 1 $
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/UI/ExceptionHelper.cs   1   2009-12-15 16:52:57-07:00   JasonO $
*
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/UI/ExceptionHelper.cs $
*  
*  Revision: 1   Date: 2009-12-15 23:52:57Z   User: JasonO 
**********************************************************************/

using System.Collections.Generic;
using System.Text;

namespace Arena.Custom.Cccev.FrameworkUtils.UI
{
    public static class ExceptionHelper
    {
        /// <summary>
        /// Returns HTML that represents a list of errors.
        /// </summary>
        /// <param name="errors">Collection of exception messages</param>
        /// <returns>HTML describing errors</returns>
        public static string GetErrorList(IEnumerable<string> errors)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<div class=\"errors\">");
            html.AppendLine("<span class=\"errorText\">Please correct the following errors:</span>");
            html.AppendLine("<ul>");

            foreach (string s in errors)
            {
                html.AppendLine(string.Format("<li class=\"errorText\">{0}</li>", s));
            }

            html.AppendLine("</ul>");
            html.AppendLine("</div>");
            return html.ToString();
        }
    }
}
