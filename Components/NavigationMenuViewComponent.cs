using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookStoreRepository repository;

        //set up repository for use when this class is called
        public NavigationMenuViewComponent (IBookStoreRepository r)
        {
            repository = r;
        }

        //return dynamically the categories that are available in the table
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
                );
        }
    }
}
