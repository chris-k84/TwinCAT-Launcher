using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT_Launcher.Core;
using TwinCAT_Launcher.MVVM.Models;

namespace TwinCAT_Launcher.MVVM.ViewModels
{
    class ADSViewModel
    {
        private string _routes { get; set; }
        private AdsHandler AdsHandler;
        public string Routes { get; set; }

        public RelayCommand ScanAdsServersCommand;
        public RelayCommand AddRouteCommand;

        public ADSViewModel()
        {
            AdsHandler = new AdsHandler();
            ScanAdsServersCommand = new RelayCommand(ScanAdsServers);
        }

        public void ScanAdsServers(object parameter)
        {
            Routes = AdsHandler.ScanADSDevices();
        }
    }
}
