using BandWebtileGenerator.Library.Services.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BandWebtileGenerator.Services.Environment
{
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentService() { }

        public string UserName
        {
            get => WindowsIdentity.GetCurrent().Name?.Split('\\')?[1];
        }
    }
}
