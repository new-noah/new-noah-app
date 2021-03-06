﻿// itelenkov
// /Users/itelenkov/Projects/PNOAH/PNOAH/Services
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PNOAH.Models;

using Refit;

namespace PNOAH.Services
{
    public interface INoahApi
    {
        #region Animals

        [Get("/get_images")]
        Task<List<AnimalModel>> GetAnimals();

        #endregion

        #region User Payments
        [Get("/get_contract_balance")]
        Task<ContractModel> GetContractBalance();
        [Get("/get_user_balance")]
        Task<UserModel> GetUserBalance();
        [Get("/pay")]
        Task<PayResponse> Pay();
        #endregion
    }
}
