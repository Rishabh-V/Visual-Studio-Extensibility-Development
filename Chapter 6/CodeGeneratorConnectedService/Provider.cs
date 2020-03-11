using Microsoft.VisualStudio.ConnectedServices;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace CodeGeneratorConnectedService
{
    [ConnectedServiceProviderExport(Constants.ProviderId, SupportsUpdate = true)]
    public class Provider : ConnectedServiceProvider
    {
        public Provider()
        {
            this.Category = Constants.Category;
            this.CreatedBy = Constants.CreatedBy;
            this.Description = Constants.Description;
            this.DescriptiveName = Constants.Name;
            this.Icon = new BitmapImage() { UriSource = new Uri("GenerateFile.png", UriKind.Relative) };
            this.Id = Constants.ProviderId;
            this.Name = Constants.Name;
            this.SupportsUpdate = true;
            this.Version = Assembly.GetExecutingAssembly().GetName().Version;
        }
                     
        public override Task<ConnectedServiceConfigurator> CreateConfiguratorAsync(ConnectedServiceProviderContext context)
        {
            return Task.FromResult<ConnectedServiceConfigurator>(new Wizard(context));
        }
    }
}
