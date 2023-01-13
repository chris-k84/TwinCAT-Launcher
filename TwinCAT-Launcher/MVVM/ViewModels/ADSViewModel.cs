using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinCAT_Launcher.Core;
using TwinCAT_Launcher.MVVM.Models;

namespace TwinCAT_Launcher.MVVM.ViewModels
{
    class ADSViewModel
    {
        private AdsHandler AdsHandler;
        public List<XmlNode> Routes { get; set; }
        public XmlNode Route { get; set; }

        public RelayCommand ScanAdsServersCommand;
        public RelayCommand AddRouteCommand;

        public ADSViewModel(ISystemManager systemManager)
        {
            AdsHandler = new AdsHandler(systemManager);
            ScanAdsServersCommand = new RelayCommand(ScanAdsServers);
            AddRouteCommand = new RelayCommand(CreateRoute);
        }

        public void ScanAdsServers(object parameter)
        {
            Routes = AdsHandler.ScanADSDevices();
        }

        public void CreateRoute(object parameter) 
        {
            string route = AdsHandler.CreateRouteString(Route);
            AdsHandler.CreateRoute(route);
        }
    }
}
