using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RamsoftBD.Models;
using System;

[assembly: OwinStartupAttribute(typeof(RamsoftBD.Startup))]
namespace RamsoftBD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           
        }

        }
    
}
