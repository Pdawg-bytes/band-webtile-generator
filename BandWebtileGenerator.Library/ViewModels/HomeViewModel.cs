using BandWebtileGenerator.Library.Services.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandWebtileGenerator.Library.ViewModels
{
    public class HomeViewModel
    {
        private readonly IEnvironmentService m_envService;

        public HomeViewModel(IEnvironmentService envService) 
        { 
            m_envService = envService;
        }

        public string UserGreeting
        {
            get => $"Hello, {m_envService.UserName}.";
        }
    }
}
