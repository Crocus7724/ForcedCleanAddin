# ForcedCleanAddin

Xamarin Studioでbin/objをフォルダごと削除する拡張機能です。

## How to install
https://github.com/Crocus7724/ForcedCleanAddin/releases から最新版のForcedCleanAddin.dllをダウンロードしてください。  

ダウンロードが完了したらForcedCleanAddin.dllを

/Applications/Xamarin Studio.app/Contents/Resources/lib/monodevelop/AddIns (macOSのばあい)

に入れます。

そしてソリューションをXamarin Studioで開いたとき  
 
 * Force Clean
 * Force Clean All
 
が表示されれば成功です。
 
## How to use
メインメニューのビルド欄にある`Forced Clean`と`Forced Clean All`を選択します。

* `Forced Clean`を選択すると現在テキストエディタで開いているプロジェクトを対象にbin/objフォルダを消去します。

* `Forced Clean All`を選択すると現在Xamarin Studioで開いている全プロジェクトを対象にbin/objフォルダを消去します。

## LICENSE
MIT License.
