using System;
using Gtk;

namespace ForcedCleanAddin
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class ForcedCleanSettingWidget : Gtk.Bin
    {
        public CheckButton AutoCleanCheckButton => autoCleanCheckButton;

        public ForcedCleanSettingWidget()
        {
            this.Build();
        }
    }
}