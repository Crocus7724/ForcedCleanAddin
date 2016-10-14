using System;
using MonoDevelop.Components;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui.Dialogs;

namespace ForcedCleanAddin
{
    public class ForcedCleanSettingPanel : OptionsPanel
    {
        private ForcedCleanSettingWidget _widget;

        public override Control CreatePanelWidget()
        {
            _widget = new ForcedCleanSettingWidget();

            _widget.AutoCleanCheckButton.Active = PropertyService.Get<bool>(ForcedCleanConst.AutoFlagKey);

            _widget.Show();

            return _widget;
        }

        public override void ApplyChanges()
        {
            PropertyService.Set(ForcedCleanConst.AutoFlagKey, _widget.AutoCleanCheckButton.Active);
        }


        public override void Dispose()
        {
            _widget?.Dispose();
        }
    }
}