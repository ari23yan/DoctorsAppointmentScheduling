using DoctorsAppointmentScheduling.Application.Services.Interfaces;
using DoctorsAppointmentScheduling.Domain.Dtos.Common.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentScheduling.Application.Utilities
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]

    public class PermissionCheckerAttribute : ActionFilterAttribute
    {
        public string Permission { get; set; }

        public PermissionCheckerAttribute()
        {
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new JsonResult(new ResponseDto<bool>
                {
                    IsSuccessFull = false,
                    Data = false,
                    Message = "User is not Authenticated.",
                    Status = "Unauthorized"
                })
                { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            var userRole = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole == null || !Int64.TryParse(userRole, out var userRoleId))
            {
                context.Result = new ForbidResult();
                return;
            }

            var userService = context.HttpContext.RequestServices.GetService<IUserService>();
            if (userService == null)
            {
                context.Result = new JsonResult(new ResponseDto<bool>
                {
                    IsSuccessFull = false,
                    Data = false,
                    Message = "User service not available.",
                    Status = "Internal Server Error"
                })
                { StatusCode = StatusCodes.Status500InternalServerError };
                return;
            }
            bool hasPermission = await userService.CheckUserHavePermission(userRoleId, Int64.Parse(Permission));
            if (!hasPermission)
            {
                context.Result = new JsonResult(new ResponseDto<bool>
                {
                    IsSuccessFull = false,
                    Data = false,
                    Message = "Permission denied.",
                    Status = "Forbidden"
                })
                { StatusCode = StatusCodes.Status403Forbidden };
                return;
            }

            await next();
        }
    }
}