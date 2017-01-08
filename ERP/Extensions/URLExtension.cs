using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ERP.Extensions
{
    public class URLExtension
    {
        public List<ERPArea> GetURLData()
        {
            var list = GetSubClasses<Controller>();

            // Get all controllers with their actions
            var getAllcontrollers = (from item in list
                                     let name = item.Name
                                     where !item.Name.StartsWith("T4MVC_") // I'm using T4MVC
                                     select new ERPController()
                                     {
                                         Name = name.Replace("Controller", ""),
                                         Namespace = item.Namespace,
                                         ERPActions = GetListOfAction(item)
                                     }).ToList();

            // Now we will get all areas that has been registered in route collection
            var allAvailableAreas = RouteTable.Routes.OfType<Route>()
                .Where(d => d.DataTokens != null && d.DataTokens.ContainsKey("area"))
                .Select(
                    r =>
                        new ERPArea
                        {
                            Name = r.DataTokens["area"].ToString(),
                            Namespace = r.DataTokens["Namespaces"] as IList<string>,
                        }).ToList()
                .Distinct().ToList();


            // Add a new area for default controllers
            allAvailableAreas.Insert(0, new ERPArea()
            {
                Name = "Main",
                Namespace = new List<string>()
            {
                typeof (ERP.Controllers.HomeController).Namespace
            }
            });


            foreach (var area in allAvailableAreas)
            {
                var temp = new List<ERPController>();
                foreach (var item in area.Namespace)
                {
                    if (item.Contains(".*"))
                    {
                        var z=item.Replace(".*","");
                        temp.AddRange(getAllcontrollers.Where(x => x.Namespace.Contains(z)).ToList());
                    }
                    else
                    {
                        temp.AddRange(getAllcontrollers.Where(x => x.Namespace == item).ToList());
                    }
                }
                area.ERPControllers = temp;
            }
            return allAvailableAreas;
        }

        void GetListOfAllAreas()
        {

            var areaNames = RouteTable.Routes.OfType<Route>()
        .Where(d => d.DataTokens != null && d.DataTokens.ContainsKey("area"))
        .Select(r => r.DataTokens["area"]).ToArray();
        }
        void GetListOfControllers()
        {
            Assembly asm = Assembly.GetExecutingAssembly();// GetAssembly(typeof(ERP.MvcApplication));

            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
        }


        private static List<Type> GetSubClasses<T>()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }

        private IEnumerable<ERPAction> GetListOfAction(Type controller)
        {
            var navItems = new List<ERPAction>();

            // Get a descriptor of this controller
            ReflectedControllerDescriptor controllerDesc = new ReflectedControllerDescriptor(controller);

            // Look at each action in the controller
            foreach (ActionDescriptor action in controllerDesc.GetCanonicalActions())
            {
                bool validAction = true;
                bool isHttpPost = false;

                // Get any attributes (filters) on the action
                object[] attributes = action.GetCustomAttributes(false);

                // Look at each attribute
                foreach (object filter in attributes)
                {
                    // Can we navigate to the action?
                    if (filter is ChildActionOnlyAttribute)
                    {
                        validAction = false;
                        break;
                    }
                    if (filter is HttpPostAttribute)
                    {
                        isHttpPost = true;
                    }

                }

                // Add the action to the list if it's "valid"
                if (validAction)
                    navItems.Add(new ERPAction()
                    {
                        Name = action.ActionName,
                        IsHttpPost = isHttpPost
                    });
            }
            return navItems;
        }

        public class ERPAction
        {
            public string Name { get; set; }

            public bool IsHttpPost { get; set; }
        }

        public class ERPController
        {
            public string Name { get; set; }

            public string Namespace { get; set; }

            public IEnumerable<ERPAction> ERPActions { get; set; }
        }

        public class ERPArea
        {
            public string Name { get; set; }

            public IEnumerable<string> Namespace { get; set; }

            public IEnumerable<ERPController> ERPControllers { get; set; }
        }
    }


}