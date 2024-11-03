using Cmms.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;

namespace Cmms.Services
{
    public interface IEquipmentService
    {
        int Create(EquipmentDto restaurantDto);
        List<EquipmentDto> GetAll();
        EquipmentDto GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateEquipmentDto equipmentDto);
    }
}