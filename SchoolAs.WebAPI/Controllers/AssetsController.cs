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
    public class AssetsController : ApiController
    {
        private const string MESSAGE_RESOURCE = "Assets.Util.Resources.LanguageWebAPI";
        private static string MODULE = "WebAPI.SawController.{0}"; // Pass method name.

        public Response<AssetDto> Get(long assetId)
        {
            Response<AssetDto> response = new Response<AssetDto>();
            try
            {
                AssetContext assetContext = new AssetContext();
                var asset = assetContext.GetAssetById(assetId);

                if (asset != null)
                {
                    response.Item = asset;
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

        public ResponseList<AssetDto> Get([FromUri]SearchRequest<AssetCriteriaDto> request)
        {
            ResponseList<AssetDto> response = new ResponseList<AssetDto>();

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

                var assets = assetContext.GetAssets(request.Criteria, request.Page, request.Take, ref count);

                if (assets.Any())
                {
                    response.Items = assets.ToList();
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

        public Response<AssetDto> Post(AssetDto assetDto)
        {
            Response<AssetDto> response = new Response<AssetDto>();
            try
            {
                AssetContext assetContext = new AssetContext();
                response.Item = assetContext.SaveAsset(assetDto);
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

        public Response<AssetDto> Put(AssetDto assetDto)
        {
            Response<AssetDto> response = new Response<AssetDto>();
            try
            {
                AssetContext assetContext = new AssetContext();
                response.Item = assetContext.SaveAsset(assetDto);
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

        public Response<bool> DeleteAsset(int assetId)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                AssetContext assetContext = new AssetContext();
                var wasDeleted = assetContext.DeleteAsset(assetId);
                if (wasDeleted)
                {
                    response.Item = true;
                    response.Code = OperationCode.ResponseCode.SUCCESS;
                    response.MessageList.Add(MessageResource.GetInstance().GetText("SawDAL_DeleteSuccess", MESSAGE_RESOURCE));
                }
                else
                {
                    response.Code = OperationCode.ResponseCode.ERROR;
                    response.ErrorList.Add(MessageResource.GetInstance().GetText("SawDAL_DeleteInvalid", MESSAGE_RESOURCE));
                }
            }
            catch (Exception ex)
            {
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SawDAL_DeleteInvalid", MESSAGE_RESOURCE));
            }
            return response;
        }

        public ResponseList<AssetDto> GetAssetsByAssignedId(long assignedId)
        {
            ResponseList<AssetDto> response = new ResponseList<AssetDto>();
            AssetContext assetContext = new AssetContext();
            response.Items = assetContext.GetAssets().ToList();
            return response;
        }


    }
}