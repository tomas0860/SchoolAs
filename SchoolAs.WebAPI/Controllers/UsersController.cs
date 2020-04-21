using Assets.DAL.Context;
using Assets.DAL.DTO;
using Assets.Util.MessageExchange;
using Assets.Util.Satellite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace Assets.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private const string MESSAGE_RESOURCE = "Assets.Util.Resources.LanguageWebAPI";
        private static string MODULE = "WebAPI.SawController.{0}"; // Pass method name.

        public Response<UserDto> Get(long UserId)
        {
            Response<UserDto> response = new Response<UserDto>();
            try
            {
                AssetContext assetContext = new AssetContext();
                var User = assetContext.GetUserById(UserId);

                if (User != null)
                {
                    response.Item = User;
                    response.Code = OperationCode.ResponseCode.SUCCESS;
                    response.MessageList.Add(MessageResource.GetInstance().GetText("SawDAL_GetSuccess", MESSAGE_RESOURCE));
                }
                else
                {
                    response.Code = OperationCode.ResponseCode.NO_FOUND;
                    response.NotFoundList.Add(MessageResource.GetInstance().GetText("SawDAL_GetNotExisting", MESSAGE_RESOURCE));
                }
            }
            catch (Exception ex)
            {
                response.Item = null;
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SawIL_GetInvalid", MESSAGE_RESOURCE));
            }

            return response;
        }

        public ResponseList<UserDto> Get([FromUri]SearchRequest<UserCriteriaDto> request)
        {
            ResponseList<UserDto> response = new ResponseList<UserDto>();

            if (request == null)
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SawDAL_GetListNull", MESSAGE_RESOURCE));
            }
            else
            {
                int? count = null;
                if (request.CountTotal) count = 0;
                AssetContext assetContext = new AssetContext();

                var Users = assetContext.GetUsers(request.Criteria, request.Page, request.Take, ref count);

                if (Users.Any())
                {
                    response.Items = Users.ToList();
                    response.TotalItems = response.Items.Count;
                    response.Count = request.CountTotal ? count.Value : 0;
                    response.Code = OperationCode.ResponseCode.SUCCESS;
                    response.MessageList.Add(MessageResource.GetInstance().GetText("SawDAL_GetListSuccess", MESSAGE_RESOURCE));
                }
                else
                {
                    response.Code = OperationCode.ResponseCode.SUCCESS;
                    response.MessageList.Add(MessageResource.GetInstance().GetText("SawDAL_GetListEmpty", MESSAGE_RESOURCE));
                }
            }

            return response;
        }

        public Response<UserDto> Post(UserDto UserDto)
        {
            Response<UserDto> response = new Response<UserDto>();
            try
            {
                AssetContext assetContext = new AssetContext();
                response.Item = assetContext.SaveUser(UserDto);
                // Configure the Success response.
                response.Code = OperationCode.ResponseCode.SUCCESS;
                response.MessageList.Add(MessageResource.GetInstance().GetText("SawDAL_UpdateSuccess", MESSAGE_RESOURCE));
            }
            catch (Exception ex)
            {
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SawDAL_UpdateInvalid", MESSAGE_RESOURCE));
            }

            return response;
        }

        public Response<UserDto> Put(UserDto UserDto)
        {
            Response<UserDto> response = new Response<UserDto>();
            try
            {
                AssetContext assetContext = new AssetContext();
                response.Item = assetContext.SaveUser(UserDto);
                // Configure the Success response.
                response.Code = OperationCode.ResponseCode.SUCCESS;
                response.MessageList.Add(MessageResource.GetInstance().GetText("SawDAL_UpdateSuccess", MESSAGE_RESOURCE));
            }
            catch (Exception ex)
            {
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SawDAL_UpdateInvalid", MESSAGE_RESOURCE));
            }

            return response;
        }
    }
}