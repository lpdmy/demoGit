using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachMate.Domain;

namespace TeachMate.Services.SearchModuleService
{
    public interface ISearchModuleService
    {
        Task<List<LearningModule>> SearchLearningModuleByTitle(string title);
    }
}
