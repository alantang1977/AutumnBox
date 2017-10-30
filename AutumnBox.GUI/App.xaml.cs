/* =============================================================================*\
*
* Filename: App.xaml.cs
* Description: 
*
* Version: 1.0
* Created: 7/31/2017 05:34:44(UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/
using AutumnBox.Basic.Devices;
using AutumnBox.Shared.CstmDebug;
using System.Windows;

namespace AutumnBox.GUI
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        internal static StartWindow OwnerWindow { get { return (Current.MainWindow as StartWindow); } }
        internal static DeviceBasicInfo SelectedDevice = new DeviceBasicInfo() { Status = DeviceStatus.NO_DEVICE };
        internal static DevicesMonitor DevicesListener = new DevicesMonitor();//设备监听器
        protected override void OnStartup(StartupEventArgs e)
        {
            Logger.T("OnStartup");
            Helper.SystemHelper.GCer.Start();
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Helper.SystemHelper.AppExit();
        }
    }
}
