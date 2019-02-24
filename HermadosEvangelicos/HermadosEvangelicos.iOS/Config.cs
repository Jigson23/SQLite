using System;

using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(HermadosEvangelicos.iOS.Config))]

namespace HermadosEvangelicos.iOS
{
    class Config : IConfig
    {
        private string directorioDB;
        private ISQLitePlatform platform;
        public string DirectorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(directorioDB))
                {
                    var directorio = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    directorioDB = System.IO.Path.Combine(directorio, "..", "Library");
                }
                return directorioDB;
            }
        }

        public ISQLitePlatform Platform
        {
            get
            {
                if (platform==null)
                {
                    platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return platform;
            }
        }
    }
}