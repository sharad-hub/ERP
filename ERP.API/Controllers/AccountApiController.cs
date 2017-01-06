
using ERP.Services;
using ERP.Services.Utilities;
using Repository.Pattern.UnitOfWork;
using ERP.Entities;
using ERP.Entities.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shop.Api.Models;

namespace ERP.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/AccountApi")]
    public class AccountApiController : ApiControllerBase
    {
        private readonly IMembershipService _membershipService;
        private readonly IErrorService _errorService;
        private readonly IUnitOfWorkAsync unitOfWorkAsync;


        public AccountApiController(IMembershipService membershipService,
            IErrorService errorService, IUnitOfWorkAsync unitOfWork)
            : base(errorService)
        {
            _membershipService = membershipService;
            unitOfWorkAsync = unitOfWork;
            _errorService = errorService;
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);

                    if (_userContext.User != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true, userId = _userContext.User.ID });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }
                else
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });

                return response;
            });
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
                else
                {
                    User _user = new Entities.User
                    {
                        Email = user.Email,
                        Username = user.Username                      
                    };
                      _user = _membershipService.CreateUser(_user, user.Password, new int[] { 1 });

                    if (_user != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }

                return response;
            });
        }
    }
}
