using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwagApp2.DataStores
{
    public class ApplicationUserService : IApplicationUserService
    {
        public string DisplayName
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("DisplayName"))
                {
                    return (string) Application.Current.Properties["DisplayName"];
                }
                return null;
            }
            set => Application.Current.Properties["DisplayName"] = value;
        }

        public string Name
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("Name"))
                {
                    return (string)Application.Current.Properties["Name"];
                }
                return null;
            }
            set => Application.Current.Properties["Name"] = value;
        }

        public async Task SaveUserDataAsync()
        {
            await Application.Current.SavePropertiesAsync();
        }
    }
}
