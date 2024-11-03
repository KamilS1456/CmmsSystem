using Cmms.EntitieDbCOntext;
using Cmms.Entities;
using Cmms.Entities.Settings;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms
{
    public class CmmSSeeder
    {
        private readonly CmmsDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        public CmmSSeeder(CmmsDbContext dbContext,  IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (true)
                {

                    if (!_dbContext.Addresses.Any())
                    {
                        var addressesList = GetAddressesList();
                        _dbContext.Addresses.AddRange(addressesList);
                        _dbContext.SaveChanges();
                    }
                    
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

                    if (!_dbContext.Suppliers.Any())
                    {
                        var suppliersList = GetSupplierList();
                        _dbContext.Suppliers.AddRange(suppliersList);
                        _dbContext.SaveChanges();
                    }

                    if (!_dbContext.Users.Any())
                    {
                        var usersList = GetUsersList();
                        _dbContext.Users.AddRange(usersList);
                        _dbContext.SaveChanges();
                    }
                    if (!_dbContext.QuestTypes.Any())
                    {
                        var questTypeList = GetQuestTypeList();
                        _dbContext.QuestTypes.AddRange(questTypeList);
                        _dbContext.SaveChanges();
                    }
                    if (!_dbContext.Quests.Any())
                    {
                        var questsList = GetQuestsList();
                        _dbContext.Quests.AddRange(questsList);
                        _dbContext.SaveChanges();
                    }
                    if (!_dbContext.QuestToUsers.Any())
                    {
                        var questToUsersList = GetQuestToUsersList();
                        _dbContext.QuestToUsers.AddRange(questToUsersList);
                        _dbContext.SaveChanges();
                    }
                    if (!_dbContext.Equipments.Any())
                    {
                        var equipmentList = GetEquipmentList();
                        _dbContext.Equipments.AddRange(equipmentList);
                        _dbContext.SaveChanges();
                    }
                    if (!_dbContext.EquipmentToEquipments.Any())
                    {
                        var equipmentList = GetEquipmentToEquipmentList();
                        _dbContext.EquipmentToEquipments.AddRange(equipmentList);
                        _dbContext.SaveChanges();
                    }

                    if (!_dbContext.EquipmentSets.Any())
                    {
                        var equipmentSetList = GetEquipmentSetList();
                        _dbContext.EquipmentSets.AddRange(equipmentSetList);
                        _dbContext.SaveChanges();
                    }

                    if (!_dbContext.EquipmentSetToEquipments.Any())
                    {
                        var equipmentSeToEquipmenttList = GetEquipmentSetToEquipmentList();
                        _dbContext.EquipmentSetToEquipments.AddRange(equipmentSeToEquipmenttList);
                        _dbContext.SaveChanges();
                    }

                    if (!_dbContext.Orders.Any())
                    {
                        var orderstList = GetOrderList();
                        _dbContext.Orders.AddRange(orderstList);
                        _dbContext.SaveChanges();
                    }



                    if (!_dbContext.QuestToEquipments.Any())
                    {
                        var questToEquipmentsList = GetQuestToEquipmentsList();
                        _dbContext.QuestToEquipments.AddRange(questToEquipmentsList);
                        _dbContext.SaveChanges();
                    }

                    if (!_dbContext.OccurrenceTypes.Any())
                    {
                        var occurrenceTypesList = GetOccurrenceTypesList();
                        _dbContext.OccurrenceTypes.AddRange(occurrenceTypesList);
                        _dbContext.SaveChanges();
                    }

                    if (!_dbContext.Occurrences.Any())
                    {
                        var occurrencesList = GetOccurrencesList();
                        _dbContext.Occurrences.AddRange(occurrencesList);
                        _dbContext.SaveChanges();
                    }

                    if (!_dbContext.Settings.Any())
                    {
                        var settingList = GetSettingList();
                        _dbContext.Settings.AddRange(settingList);
                        _dbContext.SaveChanges();
                        foreach (var setting in settingList)
                        {
                            if (setting.ValueType == SettingDictionary.SettingType.Boolean && _dbContext.SettingValueBools.Where(w => w.SettingId == setting.Id).Count() == 0)
                            {
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
        }

        private IEnumerable<Supplier> GetSupplierList()
        {
            var suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Suplier1"
                }
            };
            return suppliers;

        }
        private IEnumerable<Order> GetOrderList()
        {
            var orders = new List<Order>()
            {
                new Order() { Name = "Order1", SupplierId = _dbContext.Suppliers.First().Id
                }
            };
            return orders;

        }

        private IEnumerable<Address> GetAddressesList()
        {
            var adrdresses = new List<Address>()
            {
                new Address() {City = "Łapczyca",PostalCode = "32-744",Street = "Kalinowa"
                }
            };
            return adrdresses;

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

        private IEnumerable<User> GetUsersList()
        {
            var users = new List<User>()
            { 
            new User(){
                FirstName = "1",
                LastName = "1",
                Email = "1@.com",
                Nationality = "1",
                DateOfBirth = new DateTime(1997,1,1),
                RoleId = _dbContext.Roles.OrderBy(o => o.Id).First(f => f.Name == "Admin").Id             
            },
            new User(){
                FirstName = "2",
                LastName = "2",
                Email = "2@.com",
                Nationality = "2",
                DateOfBirth = new DateTime(1997,1,1),
                RoleId = _dbContext.Roles.OrderBy(o => o.Id).First(f => f.Name == "Menager").Id
            },
            new User(){
                FirstName = "3",
                LastName = "3",
                Email = "3@.com",
                Nationality = "3",
                DateOfBirth = new DateTime(1997,1,1),
                RoleId = _dbContext.Roles.OrderBy(o => o.Id).First(f => f.Name == "User").Id,
            }            
            };
            for (int i = 1; i <= users.Count; i++)
            {
                var user = users[i-1];
                user.PasswordHash = _passwordHasher.HashPassword(user, i.ToString());
                user.CreationDateTime = DateTime.Now;
                user.LastModifyDateTime = DateTime.Now;
            }
            return users;


        }

        private IEnumerable<QuestType> GetQuestTypeList() 
        {
            var questTypes = new List<QuestType>()
            {
                new QuestType(){
                    Name = "qt1",
                    DefaultPriority = 1,
                    CreationDateTime = DateTime.Now,
                    LastModifyDateTime = DateTime.Now
                },
                new QuestType(){
                    Name = "qt2",
                    DefaultPriority = 2,
                    CreationDateTime = DateTime.Now,
                    LastModifyDateTime = DateTime.Now
                },
                 new QuestType(){
                    Name = "qt3",
                    DefaultPriority = 3,
                    CreationDateTime = DateTime.Now,
                    LastModifyDateTime = DateTime.Now
                }
            };
            return questTypes;
        }

        private IEnumerable<Quest> GetQuestsList()
        {
            var users = _dbContext.Users.OrderBy(o => o.Id);
            var types = _dbContext.QuestTypes.OrderBy(o => o.Id);
            var quests = new List<Quest>()
            {
                new Quest(){
                    Name = "q1",
                    Description = "q1",
                    Priority = 0,
                    QuestTypeId = types.First().Id,
                    CreatedByUserId = users.First().Id,
                    LastModifyByUserId = users.First().Id,
                    DeadLineDataTime = new DateTime(2024,02,20),
                    CreationDateTime = DateTime.Now,
                    LastModifyDateTime = DateTime.Now
                },
                new Quest(){
                    Name = "q2",
                    Description = "q2",
                    Priority = 1,
                    QuestTypeId = types.Last().Id,
                    CreatedByUserId = users.Last().Id,
                    LastModifyByUserId = users.Last().Id,
                    DeadLineDataTime = new DateTime(2024,02,20),
                    CreationDateTime = DateTime.Now,
                    LastModifyDateTime = DateTime.Now
                },
                 new Quest(){
                    Name = "q3",
                    Description = "q3",
                    Priority = 2,
                    QuestTypeId = types.First().Id,
                    CreatedByUserId = users.Last().Id,
                    LastModifyByUserId = users.Last().Id,
                    DeadLineDataTime = new DateTime(2024,02,20),
                    CreationDateTime = DateTime.Now,
                    LastModifyDateTime = DateTime.Now
                }
            };
            return quests;
        }
        private IEnumerable<EquipmentSet> GetEquipmentSetList()
        {
            var equipmentSets = new List<EquipmentSet>()
            {
                new EquipmentSet() { Name = "EquipmentSet1",Description = "EquipmentSet1_Description"
                }
            };
            return equipmentSets;

        }
        private IEnumerable<EquipmentSetToEquipment> GetEquipmentSetToEquipmentList()
        {
            var equipmentSetToEquipments = new List<EquipmentSetToEquipment>();

            var eqSet = _dbContext.EquipmentSets.First();
            foreach (var item in _dbContext.Equipments)
            {
                equipmentSetToEquipments.Add(new EquipmentSetToEquipment() { EquipmentID = item.Id, EquipmentSetID = eqSet.Id });

            }
            return equipmentSetToEquipments;

        }
        private IEnumerable<Equipment> GetEquipmentList()
        {
            var equipments = new List<Equipment>()
            {
                new Equipment(){
                    Name = "e1",
                    Condition = Cmms.Dictionary.Dictionary.EquipmentCondition.Operating,
                    Model = "m1",
                    LastServiceDateTime = new DateTime(2024,1,1),
                    CreatedByUserId = _dbContext.Users.OrderBy(o => o.Id).First().Id,
                    LastModifyByUserId = _dbContext.Users.OrderBy(o => o.Id).First().Id,
                    CreationDateTime = DateTime.Now,
                    LastModifyDateTime = DateTime.Now,
                    SN = "sn1"
                },
                new Equipment(){
                    Name = "e2",
                    Condition = Cmms.Dictionary.Dictionary.EquipmentCondition.Foulty,
                    Model = "m2",
                    CreatedByUserId = _dbContext.Users.OrderBy(o => o.Id).Last().Id,
                    LastModifyByUserId = _dbContext.Users.OrderBy(o => o.Id).Last().Id,
                    CreationDateTime = DateTime.Now,
                    LastModifyDateTime = DateTime.Now,
                    SN = "sn2"
                },
                 new Equipment(){
                    Name = "e3",
                    Condition = Cmms.Dictionary.Dictionary.EquipmentCondition.Operating,
                    Model = "m2",
                    CreatedByUserId = _dbContext.Users.OrderBy(o => o.Id).Last().Id,
                    LastModifyByUserId = _dbContext.Users.OrderBy(o => o.Id).Last().Id,
                    CreationDateTime = DateTime.Now,
                    LastModifyDateTime = DateTime.Now,
                    SN = "sn3"
                }
            };
            return equipments;
        }

        private IEnumerable<EquipmentToEquipment> GetEquipmentToEquipmentList()
        {
            var equipmentToEquipents = new List<EquipmentToEquipment>();
            var prevEqID = 0;
            foreach (var item in _dbContext.Equipments)
            {
                if (prevEqID != 0) { 
                    equipmentToEquipents.Add(new EquipmentToEquipment() { PrimalEquipmentId = prevEqID, InnerEquipmentId = item.Id });
                }
                prevEqID = item.Id;
            }            
            return equipmentToEquipents;
        }

        private IEnumerable<QuestToUser> GetQuestToUsersList()
        {
            var questToUsers = new List<QuestToUser>()
           { new QuestToUser(){
               QuestId = _dbContext.Quests.OrderBy(o => o.Id).First().Id,
               UserId = _dbContext.Users.OrderBy(o => o.Id).Last().Id,
           }
           };
            return questToUsers;
        }

        private IEnumerable<QuestToEquipment> GetQuestToEquipmentsList()
        {
            var questToEquipments = new List<QuestToEquipment>()
           { new QuestToEquipment(){
               QuestId = _dbContext.Quests.OrderBy(o => o.Id).First().Id,
               EquipmentId = _dbContext.Equipments.OrderBy(o => o.Id).Last().Id               
           }
           };
            return questToEquipments;
        }

        private IEnumerable<OccurrenceType> GetOccurrenceTypesList()
        {
            var occurrenceTypeList = new List<OccurrenceType>()
           { 
               new OccurrenceType(){
               Name = "Przeglad",
               DefaultPriority = 1
           },
            new OccurrenceType(){
               Name = "Konserwacja",
               DefaultPriority = 2,
           },
            new OccurrenceType(){
               Name = "Awaria",
               DefaultPriority = 3
           }                
           };
            return occurrenceTypeList;
        }

        private IEnumerable<Occurrence> GetOccurrencesList()
        {
            var occurrences = new List<Occurrence>()
           { new Occurrence(){
               Description = "D1",               
               EquipmentId = _dbContext.Equipments.OrderBy(o => o.Id).Last().Id,
               OccurrenceTypeId = _dbContext.OccurrenceTypes.First().Id,
               Priority = 1,
           },
           new Occurrence(){
               Description = "D2",
               EquipmentId = _dbContext.Equipments.OrderBy(o => o.Id).Last().Id,
               OccurrenceTypeId = _dbContext.OccurrenceTypes.First().Id,
               Priority = 2,
           },
           new Occurrence(){
               Description = "D3",
               EquipmentId = _dbContext.Equipments.OrderBy(o => o.Id).Last().Id,
               OccurrenceTypeId = _dbContext.OccurrenceTypes.OrderBy(o => o.Id).Last().Id,
               Priority = 3,
           }
           };
            return occurrences;
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
