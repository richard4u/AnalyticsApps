﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1.Request;

namespace WemaAnalyticsAPI.Services
{
    public interface ICardsService
    {
        Task<dynamic> GetCardIssuanceByCluster(CardIssuanceRequest reportRequest);
        Task<dynamic> GetCardIssuanceByClusterCards(CardIssuanceCardsRequest cardsRequest);
    }
}