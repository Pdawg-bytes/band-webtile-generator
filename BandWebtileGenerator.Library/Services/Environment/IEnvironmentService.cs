using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandWebtileGenerator.Library.Services.Environment
{
    public interface IEnvironmentService
    {
        /// <summary>
        /// The username of the user currently using the app.
        /// </summary>
        public string UserName { get; }
    }
}
