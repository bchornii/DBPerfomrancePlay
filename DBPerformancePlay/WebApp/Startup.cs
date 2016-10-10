﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

[assembly: OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new RazorViewEngine());
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
		}
	}
}
