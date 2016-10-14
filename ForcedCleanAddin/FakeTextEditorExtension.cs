using MonoDevelop.Ide.Editor.Extension;
using System;

namespace ForcedCleanAddin
{
    public class FakeTextEditorExtension:TextEditorExtension
    {
        private IDisposable disposable;
        public FakeTextEditorExtension()
        {
            disposable=AutoForcedCleaner.Current.Subscribe();
        }
    }
}