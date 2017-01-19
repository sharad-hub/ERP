using ERP.Entities;
using ERP.Extensions;
using ERP.Services;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Areas.Administration.Controllers
{
    public class MastersController : BaseController
    {
        ICityService _cityService;
        IStateService _stateService;
        ICountryService _countryService;
        IZoneService _zoneService;
        IUnitOfWorkAsync _unitOfWorkAsync;
        public MastersController(ICityService cityService, IStateService stateService,
            ICountryService countryService, IZoneService zoneService,IUnitOfWorkAsync unitOfWorkAsync)
        {
            _cityService = cityService;
            _zoneService = zoneService;
            _countryService = countryService;
            _stateService = stateService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }
        // GET: Administration/Masters
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCountry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCountry(Country model)
        {
            _countryService.Insert(model);
            _unitOfWorkAsync.SaveChanges();
            Success(string.Format("<b>Country ({0})</b> was successfully added to the database.", model.CountryName), true);
            return View();
        }

        public ActionResult CreateZone()
        {
            var countries = _countryService.Queryable().Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.ID.ToString()
            }).ToList();
            ViewBag.Countries = countries;
            return View();
        }
        [HttpPost]
        public ActionResult CreateZone(Zone model)
        {
            _zoneService.Insert(model);
            _unitOfWorkAsync.SaveChanges();
            var countries = _countryService.Queryable().Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.ID.ToString()
            }).ToList();
            ViewBag.Countries = countries;
            Success(string.Format("<b>Zone({0})</b> was successfully added to the database.", model.ZoneName), true);
            return View();
        }

        public ActionResult CreateState()
        {
            var countries = _countryService.Queryable().Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.ID.ToString()
            }).ToList();
            ViewBag.Countries = countries;

                   
            return View();
        }
        [HttpPost]
        public ActionResult CreateState(State model)
        {
            _stateService.Insert(model);
            _unitOfWorkAsync.SaveChanges();
            var countries = _countryService.Queryable().Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.ID.ToString()
            }).ToList();
            ViewBag.Countries = countries;
            Success(string.Format("<b>State ({0})</b> was successfully added to the database.", model.StateName), true);
            return View();
        }

        public ActionResult CreateCity()
        {
            var countries = _countryService.Queryable().Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.ID.ToString()
            }).ToList();
            ViewBag.Countries = countries;          
      

            var states = _zoneService.Queryable().Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Text = x.ZoneName,
                Value = x.ZoneId.ToString()
            }).ToList();
            ViewBag.States = states;
          
          
            return View();
        }
        [HttpPost]
        public ActionResult CreateCity(City model)
        {

            _cityService.Insert(model);
            _unitOfWorkAsync.SaveChanges();

            var countries = _countryService.Queryable().Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.ID.ToString()
            }).ToList();
            ViewBag.Countries = countries;
            Success(string.Format("<b>City ({0})</b> was successfully added to the database.", model.CityName), true);
            return View();
        }

        #region Cascading dropdowns

        [HttpPost]
        public ActionResult GetZones(int countryId)
        {
            List<SelectListItem> zones = new List<SelectListItem>();          
              zones = _zoneService.Queryable().Where(x => x.CountryId == countryId).Select(x => new SelectListItem
                {
                    Value = x.ZoneId.ToString(),
                    Text = x.ZoneName
                }).ToList();            
            return Json(zones, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetStates(int countryId,int zoneId)
        {
            List<SelectListItem> states = new List<SelectListItem>();
            states = _stateService.Queryable().Where(x => x.ZoneId == zoneId).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.StateName
            }).ToList();
            return Json(states, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetCities(int zoneId,int stateID)
        {
            List<SelectListItem> cities = new List<SelectListItem>();
            cities = _cityService.Queryable().Where(x => x.StateId == stateID).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.CityName
            }).ToList();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}