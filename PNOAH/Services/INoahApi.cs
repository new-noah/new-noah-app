// itelenkov
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
    }
}
