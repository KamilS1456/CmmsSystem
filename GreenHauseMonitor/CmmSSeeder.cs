using Cmms.EntitieDbCOntext;
using Cmms.Entities;
using Cmms.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms
{
    public class CmmSSeeder
    {
        private readonly CmmsDbContext _dbContext;
        public CmmSSeeder(CmmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurantList = GetRestaurantList();
                    _dbContext.Restaurants.AddRange(restaurantList);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Roles.Any())
                {
                    var roleList = GetRoleList();
                    _dbContext.Roles.AddRange(roleList);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Settings.Any())
                {
                    var settingList = GetSettingList();
                    _dbContext.Settings.AddRange(settingList);             

                    foreach (var setting in settingList)
                    {
                        if (setting.ValueType == SettingDictionary.SettingType.Boolean && _dbContext.SettingValueBools.Where(w => w.SettingId == setting.Id).Count() == 0) {
                            var settingValueBool = new SettingValueBool()
                            {
                                RoleId = _dbContext.Roles.First().Id,
                                SettingId = setting.Id,
                                UserId = _dbContext.Users.First().Id,
                                Value = false,
                            };


                            _dbContext.SettingValueBools.Add(settingValueBool);
                        }
                    }
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurantList()
        {
            var restaurants = new List<Restaurant>(){
               new Restaurant(){
                   Name = "Kfc",
                   Category = "fast Food",
                   Description = "OPis1",
                   ContactEmail = "contact1@kfc.com",
                   HasDelivery = true,
                   Dishes = new List<Dish>()
                   {
                       new Dish()
                       {
                           Name = "Chicken Wings",
                           Price = 5.30M,
                       },
                       new Dish()
                       {
                           Name = "Qurito",
                           Price = 15.80M,
                       }
                   },
                   Address = new Address()
                   {
                        City = "Krakow",
                        Street = "Dluga 4",
                        PostalCode = "32-015"
                   }
               },
                new Restaurant(){
                   Name = "MC",
                   Category = "fast Food",
                   Description = "OPis1",
                   ContactEmail = "contact1@kfc.com",
                   HasDelivery = true,
                   Dishes = new List<Dish>()
                   {
                       new Dish()
                       {
                           Name = "MCChickec",
                           Price = 8.30M,
                       },
                       new Dish()
                       {
                           Name = "Wiśmack",
                           Price = 13.80M,
                       }
                   },
                    Address = new Address()
                   {
                        City = "Warszawa",
                        Street = "Krótka 4",
                        PostalCode = "32-015"
                   }
               }
            };

            return restaurants;
        }

        private IEnumerable<Role> GetRoleList()
        {
            var roles = new List<Role>(){
              new Role(){
                Name = "Admin"
              },
              new Role(){
                Name = "Menager"
              },
              new Role(){
                Name = "User"
              }
            };

            return roles;
        }

        private IEnumerable<Setting> GetSettingList()
        {
            var settings = new List<Setting>(){
              new Setting(){
                Name = "Testowe ustawienie pozwolenia pobrania restauracji po id",
                CodeName = SettingCodeName.AllowGetingRestaurantByID,
                Description = "Testowe ustawienie pozwolenia pobrania restauracji po id",
                ValueType = SettingDictionary.SettingType.Boolean
              }
            };

            return settings;
        }
    }
}
