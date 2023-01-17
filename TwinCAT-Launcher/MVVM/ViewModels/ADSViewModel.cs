using Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TwinCAT_Launcher.Core;
using TwinCAT_Launcher.MVVM.Models;

namespace TwinCAT_Launcher.MVVM.ViewModels
{
    class ADSViewModel
    {
        private AdsHandler AdsHandler = new AdsHandler();
        public List<XmlNode> Routes { get; set; }
        public ObservableCollection<Root> Roots { get; set; }   
        public XmlNode Route { get; set; }
        public RelayCommand ScanAdsServersCommand { get; set; }
        public RelayCommand AddRouteCommand { get; set; }
        private ISystemManager _systemManager;
        public ISystemManager SystemManager
        {
            get { return _systemManager; }
            set
            {
                _systemManager = value; 
                AdsHandler.systemManager = value;
            }
        }

        public ADSViewModel()
        {
            Routes = new List<XmlNode>();
            Roots = new ObservableCollection<Root>();
            ScanAdsServersCommand = new RelayCommand(ScanAdsServers);
            AddRouteCommand = new RelayCommand(CreateRoute);
        }
        public void ScanAdsServers(object parameter)
        {
            Routes = AdsHandler.ScanADSDevices();
            foreach (XmlNode node in Routes)
            {
                string id = node["Name"].InnerText;
                string name = node["NetId"].InnerText;
                Roots.Add(new Root { Name = id, NetId = name });
            }
        }
        public void CreateRoute(object parameter) 
        {
            string route = AdsHandler.CreateRouteString(Route);
            AdsHandler.CreateRoute(route);
        }

 
        [XmlRoot(ElementName = "Root")]
        public class Root
        {

            [XmlElement(ElementName = "Name")]
            public string Name { get; set; }

            [XmlElement(ElementName = "NetId")]
            public string NetId { get; set; }

            [XmlElement(ElementName = "IpAddr")]
            public string IpAddr { get; set; }

            [XmlElement(ElementName = "Version")]
            public DateTime Version { get; set; }

            [XmlElement(ElementName = "OS")]
            public string OS { get; set; }
        }
    }
}
