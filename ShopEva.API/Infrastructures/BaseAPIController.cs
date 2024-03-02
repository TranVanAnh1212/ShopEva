using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopEva.Models.Model;
using ShopEva.Services.IServices;
using System.Diagnostics;
using System.Net;

namespace ShopEva.API.Infrastructures
{
    public class BaseAPIController : ControllerBase
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private IErrorService _errorService;

        public BaseAPIController(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreatedHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> func)
        {
            HttpResponseMessage responseMessage = null;
            try
            {
                responseMessage = func.Invoke();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(ex);
                logger.Error(ex);
                responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbex)
            {
                LogError(dbex);
                logger.Error(dbex);
                responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                logger.Error(ex);
                responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return responseMessage;

        }

        private void LogError(Exception ex)
        {
            try
            {
                Error err = new Error();
                err.ID = Guid.NewGuid();
                err.CreatedDate = DateTime.Now;
                err.StackTrace = ex.StackTrace;
                err.Message = ex.Message;

                _errorService.Add(err);
                _errorService.SaveChanged();
            }
            catch (Exception exc)
            {
                logger.Error(exc);
            }
        }

        protected async Task<HttpResponseMessage> CreatedHttpResponseAsync(HttpRequestMessage requestMessage, Func<Task<HttpResponseMessage>> func)
        {
            HttpResponseMessage responseMessage = null;
            try
            {
                responseMessage = await func.Invoke();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                logger.Error(ex);
                await LogErrorAsync(ex);
                responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbex)
            {
                await LogErrorAsync(dbex);
                responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbex.InnerException.Message);
            }
            catch (Exception ex)
            {
                await LogErrorAsync(ex);
                responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return responseMessage;

        }

        private async Task LogErrorAsync(Exception ex)
        {
            try
            {
                Error err = new Error();
                err.CreatedDate = DateTime.Now;
                err.StackTrace = ex.StackTrace;
                err.Message = ex.Message;

                _errorService.Add(err);
                _errorService.SaveChanged();
            }
            catch
            {

            }
        }
    }
}
