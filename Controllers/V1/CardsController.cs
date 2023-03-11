using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.Services;

namespace WemaAnalyticsAPI.Controllers.V1
{
    public class CardsController : Controller
    {
        private readonly ICardsService _cardsService;
        public CardsController(ICardsService cardsService)
        {
            _cardsService = cardsService;
        }

        [HttpGet(ApiRoutes.Reports.CardIssuanceByCluster.GetAll)]
        public async Task<IActionResult> GetCardIssuanceByCluster(
          CardIssuanceRequest reportRequest)
        {
            var data = await _cardsService.GetCardIssuanceByCluster(reportRequest);
            return new OkObjectResult(data);
        }

        [HttpGet(ApiRoutes.Reports.CardIssuanceByCluster.GetCards)]
        public async Task<IActionResult> GetCardIssuanceByClusterCards(
            CardIssuanceCardsRequest cardsRequest)
        {
            var data = await _cardsService.GetCardIssuanceByClusterCards(cardsRequest);
            return new OkObjectResult(data);
        }
    }

}