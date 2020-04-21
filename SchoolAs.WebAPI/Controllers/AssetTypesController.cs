using Assets.DAL.Context;
using Assets.DAL.DTO;
using Assets.Util.MessageExchange;
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
    public class AssetTypesController : ApiController
    {
        public ResponseList<AssetTypeDto> GetAssetsTypes()
        {
            ResponseList<AssetTypeDto> response = new ResponseList<AssetTypeDto>();
            AssetContext assetContext = new AssetContext();
            response.Items = assetContext.GetAssetsTypes().ToList();
            return response;
        }
    }
}