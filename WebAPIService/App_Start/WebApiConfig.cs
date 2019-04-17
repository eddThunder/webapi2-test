using AutoMapper;
using BusinessLayer.Dto;
using DataAccessLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPIService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // AutoMapperInitialization();
        }

        //private static void AutoMapperInitialization()
        //{
        //    //Map to Entity to Dto
        //    Mapper.Initialize(mapper => {

        //        mapper.CreateMap<Roles, RoleDto>()
        //            .ForMember(from => from.IdRole, to => to.MapFrom(src => src.Id))
        //            .ForMember(from => from.RoleName, to => to.MapFrom(src => src.RoleName));


        //        mapper.CreateMap<Users, UserDto>()
        //        .ForMember(from => from.Roles, to => to.MapFrom(src => src.UsersRoles));
        //    });
        //}

    }


}
