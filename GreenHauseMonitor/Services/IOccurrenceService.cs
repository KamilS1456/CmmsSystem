using Cmms.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;

namespace Cmms.Services
{
    public interface IOccurrenceService
    {
        int Create(OccurrenceDto restaurantDto);
        List<OccurrenceDto> GetAll();
        OccurrenceDto GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateOccurrenceDto OccurrenceDto);
    }
}