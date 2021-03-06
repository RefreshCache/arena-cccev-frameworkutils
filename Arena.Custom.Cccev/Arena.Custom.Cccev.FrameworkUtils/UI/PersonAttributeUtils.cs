﻿/**********************************************************************
* Description:	TBD
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created:	TBD
*
* $Workfile: PersonAttributeUtils.cs $
* $Revision: 9 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/UI/PersonAttributeUtils.cs   9   2009-09-21 08:37:52-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.FrameworkUtils/UI/PersonAttributeUtils.cs $
*  
*  Revision: 9   Date: 2009-09-21 15:37:52Z   User: JasonO 
*  Adding attribute security. 
*  
*  Revision: 8   Date: 2009-08-31 21:40:27Z   User: JasonO 
*  
*  Revision: 7   Date: 2009-07-21 01:02:11Z   User: JasonO 
*  
*  Revision: 6   Date: 2009-07-17 00:28:59Z   User: JasonO 
*  
*  Revision: 5   Date: 2009-07-15 18:16:05Z   User: JasonO 
*  
*  Revision: 4   Date: 2009-07-08 18:29:58Z   User: JasonO 
*  
*  Revision: 3   Date: 2009-07-07 20:40:59Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-07-06 22:21:11Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-06-30 16:34:01Z   User: JasonO 
*  
*  Revision: 2   Date: 2009-06-25 18:20:17Z   User: JasonO 
*  
*  Revision: 1   Date: 2009-06-25 17:34:22Z   User: JasonO 
**********************************************************************/

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arena.Core;
using Arena.Custom.Cccev.DataUtils;
using Arena.Enums;
using Arena.Security;

namespace Arena.Custom.Cccev.FrameworkUtils.UI
{
    public static class PersonAttributeUtils
    {
        /// <summary>
        /// This (factory) method will create controls based on the given PersonAttribute object and add them to the
        /// container control that's passed in.  This allows the dynamic control to participate in ViewState.
        /// </summary>
        /// <param name="attribute"><see cref="Arena.Core.PersonAttribute">PersonAttribute</see> to represent</param>
        /// <param name="cssClass">CSS class to append to the dynamic control</param>
        /// <param name="parentContainer">Parent Control to add the control to</param>
        /// <param name="setValue">Boolean indicating whether or not to set the value of the control</param>
        /// <param name="enabled">Boolean indicating whether the control will be enabled</param>
        public static void CreateControl(PersonAttribute attribute, string cssClass, Control parentContainer, bool setValue, bool enabled)
        {
            if (attribute.Visible && attribute.Permissions.Allowed(OperationType.View, ArenaContext.Current.User))
            {
                bool canEdit = (enabled && attribute.Permissions.Allowed(OperationType.Edit, ArenaContext.Current.User));

                switch (attribute.AttributeType)
                {
                    case DataType.Currency:
                    case DataType.Decimal:
                        CreateTextBox(attribute, cssClass, parentContainer, setValue, canEdit, attribute.ToString());
                        break;
                    case DataType.Int:
                        CreateTextBox(attribute, cssClass, parentContainer, setValue, canEdit, attribute.ToString());
                        break;
                    case DataType.DateTime:
                        CreateDateTextBox(attribute, cssClass, parentContainer, canEdit, enabled);
                        break;
                    case DataType.String:
                    case DataType.Guid:
                    case DataType.Url:
                        CreateTextBox(attribute, cssClass, parentContainer, canEdit, enabled, attribute.ToString());
                        break;
                    case DataType.Lookup:
                        CreateDropDownList(attribute, cssClass, parentContainer, canEdit, enabled);
                        break;
                    case DataType.YesNo:
                        CreateCheckBox(attribute, cssClass, parentContainer, canEdit, enabled);
                        break;
                    case DataType.Document:
                        CreateDocumentPicker(attribute, cssClass, parentContainer, canEdit, enabled);
                        break;
                    default:
                        break;
                }

                if (attribute.Required)
                {
                    CreateValidator(attribute, cssClass, parentContainer);
                }
            }
        }

        /// <summary>
        /// Gets a formatted ID for a person attribute control based on the attribute's type.  The control corresponding to the ID
        /// should be created with the CreateControl() method.
        /// </summary>
        /// <param name="attribute">Arena.Core.PersonAttribute</param>
        /// <returns>Formatted string representing a control ID of the given PersonAttribute</returns>
        public static string GetControlID(PersonAttribute attribute)
        {
            string prefix;

            switch (attribute.AttributeType)
            {
                case DataType.DateTime:
                    prefix = "dtb";
                    break;
                case DataType.Lookup:
                    prefix = "ddl";
                    break;
                case DataType.YesNo:
                    prefix = "cb";
                    break;
                case DataType.Document:
                    prefix = "dp";
                    break;
                default:
                    prefix = "tb";
                    break;
            }

            return string.Format("{0}_{1}", prefix, attribute.AttributeId);
        }

        /// <summary>
        /// Gets an Attribute integer ID value from a the given Control's ID string. It's worth noting that the control should have been
        /// generated by this class' CreateControl() method.
        /// </summary>
        /// <param name="control">Web control to extract ID from</param>
        /// <returns>int value of Attribute ID</returns>
        public static int GetAttributeID(Control control)
        {
            return control.ID.Substring(control.ID.LastIndexOf('_') + 1).ToInt32();
        }

        private static void CreateTextBox(PersonAttribute attribute, string cssClass, Control parentContainer, bool setValue, bool enabled, string value)
        {
            DynamicTextBox tb = new DynamicTextBox();
            parentContainer.Controls.Add(tb);
            tb.ID = GetControlID(attribute);
            tb.CssClass = cssClass;
            tb.Enabled = enabled;

            if (setValue)
            {
                tb.Text = value;
            }
        }

        private static void CreateDateTextBox(PersonAttribute attribute, string cssClass, Control parentContainer, bool setValue, bool enabled)
        {
            DynamicDateTextBox dtb = new DynamicDateTextBox();
            parentContainer.Controls.Add(dtb);
            dtb.ID = GetControlID(attribute);
            dtb.CssClass = cssClass;
            dtb.Enabled = enabled;

            if (setValue)
            {
                dtb.Text = attribute.ToString(true);
            }
        }

        private static void CreateDropDownList(PersonAttribute attribute, string cssClass, Control parentContainer, bool setValue, bool enabled)
        {
            DynamicDropDownList ddl = new DynamicDropDownList();
            parentContainer.Controls.Add(ddl);
            ddl.ID = GetControlID(attribute);
            ddl.CssClass = cssClass;
            ddl.Enabled = enabled;

            LookupCollection lookups = new LookupCollection(int.Parse(attribute.TypeQualifier));
            lookups.LoadDropDownList(ddl);
            ddl.Items.Insert(0, DynamicDropDownList.GetDefaultSelectItem());

            if (setValue)
            {
                ddl.ClearSelection();
                ddl.SelectedValue = attribute.IntValue.ToString();
            }
        }

        private static void CreateCheckBox(PersonAttribute attribute, string cssClass, Control parentContainer, bool setValue, bool enabled)
        {
            DynamicCheckBox cb = new DynamicCheckBox();
            parentContainer.Controls.Add(cb);
            cb.ID = GetControlID(attribute);
            cb.CssClass = cssClass + "_cb";
            cb.Enabled = enabled;
            cb.Text = attribute.AttributeName;
            cb.TextAlign = TextAlign.Left;

            if (setValue)
            {
                cb.Checked = attribute.IntValue != Constants.NULL_INT ? Convert.ToBoolean(attribute.IntValue) : false;
            }
        }

        private static void CreateDocumentPicker(PersonAttribute attribute, string cssClass, Control parentContainer, bool setValue, bool enabled)
        {
            DynamicDocumentPicker dp = new DynamicDocumentPicker();
            parentContainer.Controls.Add(dp);
            dp.ID = GetControlID(attribute);
            dp.AllowRemove = !attribute.Required;
            dp.DocumentTypeID = attribute.TypeQualifier != string.Empty ? int.Parse(attribute.TypeQualifier) : Constants.NULL_INT;
            dp.CssClass = cssClass;
            dp.Enabled = enabled;

            if (setValue)
            {
                dp.DocumentID = attribute.IntValue;
            }
        }

        private static void CreateValidator(PersonAttribute attribute, string cssClass, Control parentContainer)
        {
            RequiredFieldValidator rfv = new RequiredFieldValidator();
            parentContainer.Controls.Add(rfv);
            rfv.CssClass = cssClass + "_validator";
            rfv.ControlToValidate = GetControlID(attribute);
            rfv.ErrorMessage = string.Format("{0} is required.", attribute.AttributeName);
            rfv.SetFocusOnError = true;
            rfv.Text = " *";
            rfv.Display = ValidatorDisplay.Dynamic;
        }
    }
}
