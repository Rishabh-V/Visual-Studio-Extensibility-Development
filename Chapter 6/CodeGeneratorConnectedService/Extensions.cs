using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGeneratorConnectedService
{
    public static class Extensions
    {
        public static Project GetProject(this IVsHierarchy projectHierarchy)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            int result = projectHierarchy.GetProperty(VSConstants.VSITEMID_ROOT, (int)__VSHPROPID.VSHPROPID_ExtObject, out object projectObject);
            ErrorHandler.ThrowOnFailure(result);
            return (Project)projectObject;
        }

        public static string GetNameSpace(this Project project)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            return project.Properties.Item(Constants.DefaultNamespace).Value.ToString();
        }

        public static string GetServiceFolderPath(this Project project, string rootFolder)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            var servicePath = project.ProjectItems.Item(rootFolder).ProjectItems.Item(1).Properties.Item(Constants.FullPath).Value.ToString();
            return servicePath;
        }
    }
}
