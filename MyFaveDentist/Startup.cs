﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFaveDentist.Startup))]
namespace MyFaveDentist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
