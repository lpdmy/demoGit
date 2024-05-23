using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachMate.Domain;

namespace TeachMate.Services.SearchModuleService
{
    public class SearchModuleService : ISearchModuleService
    {
        private readonly DataContext _context;

        public SearchModuleService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<LearningModule>> SearchLearningModuleByTitle(string title)
        {
            var listModules = await _context.LearningModules.Where(q => q.Title.Contains(title)).ToListAsync();
            return listModules;
        }
    }
}
