using CodeGeneratorConnectedService.ViewModels;
using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGeneratorConnectedService
{
    class Wizard : ConnectedServiceWizard
    {
        private readonly ConnectedServiceProviderContext context;

        public Wizard(ConnectedServiceProviderContext context)
        {
            this.context = context;
            Pages.Add(new JsonDetailsWizardPage(context));

            foreach (var page in Pages)
            {
                page.PropertyChanged += this.OnPagePropertyChanged;
            }
        }

        private void OnPagePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.IsFinishEnabled = Pages.All(page => !page.HasErrors);
            this.IsNextEnabled = false;
        }

        public override Task<ConnectedServiceInstance> GetFinishedServiceInstanceAsync()
        {
            var instance = new Instance();
            instance.JSONPath = Pages.OfType<JsonDetailsWizardPage>().FirstOrDefault()?.JsonPath;
            return Task.FromResult<ConnectedServiceInstance>(instance);
        }
    }
}
