using Cmms.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;

namespace Cmms.Services
{
    public interface IEquipmentSetService
    {
        int Create(EquipmentSetDto equipmentSetDto);
        List<EquipmentSetDto> GetAll();
        EquipmentSetDto GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateEquipmentSetDto equipmentSet);
    }
}