using System;
using System.Threading.Tasks;
using AnteaNL.CustomerSatisfaction.Common.Exceptions;
using BuildingVitals.WebApi.Helpers;
using Microsoft.AspNetCore.Http;

namespace BuildingVitals.WebApi.Middlewares
{
    public class ExceptionMiddleware : Exception
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (UnauthorizedAccessException e)
            {
                await _next(await httpContext.SetResponse(StatusCodes.Status401Unauthorized, e.Message));
            }
            catch (ForbiddenException e)
            {
                await _next(await httpContext.SetResponse(StatusCodes.Status403Forbidden, e.Message));
            }
            catch (NotFoundException e)
            {
                await _next(await httpContext.SetResponse(StatusCodes.Status404NotFound, e.Message));
            }
            catch (BadRequestException e)
            {
                await _next(await httpContext.SetResponse(StatusCodes.Status400BadRequest, e.Message));
            }
            catch (ConflictException e)
            {
                await _next(await httpContext.SetResponse(StatusCodes.Status409Conflict, e.Message));
            }
            catch (Exception)
            {
                await _next(await httpContext.SetResponse(StatusCodes.Status500InternalServerError, ExceptionMessages.GeneralException));
            }
        }
    }
}
