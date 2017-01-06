
using ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Api.Models.ViewModels
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public string NavigationPath { get; set; }
        public MenuViewModel()
        {

        }
        public MenuViewModel(Menu menu)
        {
            this.Id = menu.Id;
            this.IsActive = menu.Status.GetValueOrDefault();
            this.Name = menu.MenuName;
            this.NavigationPath=menu.NavigationPath;
            this.Order = menu.Orderby.GetValueOrDefault();
            this.ParentId = menu.ParentId.GetValueOrDefault();
        }
    }
}