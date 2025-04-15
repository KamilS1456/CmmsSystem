
//using Cmms.Domain.Entities;
//using Cmms.Core.EntitieDbCOntext;
//using Microsoft.AspNetCore.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Cmms
//{
//    public class CmmSSeeder
//    {
//        private readonly CmmsDbContext _dbContext;
//        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
//        public CmmSSeeder(CmmsDbContext dbContext,  IPasswordHasher<IdentityUser> passwordHasher)
//        {
//            _dbContext = dbContext;
//            _passwordHasher = passwordHasher;
//        }
//        public void Seed()
//        {
//            if (_dbContext.Database.CanConnect())
//            {
//                if (true)
//                {

//                    if (!_dbContext.Addresses.Any())
//                    {
//                        var addressesList = GetAddressesList();
//                        _dbContext.Addresses.AddRange(addressesList);
//                        _dbContext.SaveChanges();
//                    }
                    

//                    //if (!_dbContext.Roles.Any())//todoo
//                    //{
//                    //    var roleList = GetRoleList();
//                    //    _dbContext.Roles.AddRange(roleList);
//                    //    _dbContext.SaveChanges();
//                    //}

//                    if (!_dbContext.Suppliers.Any())
//                    {
//                        var suppliersList = GetSupplierList();
//                        _dbContext.Suppliers.AddRange(suppliersList);
//                        _dbContext.SaveChanges();
//                    }

//                    if (!_dbContext.Users.Any())
//                    {
//                        var usersList = GetUsersList();
//                        _dbContext.Users.AddRange(usersList);
//                        _dbContext.SaveChanges();
//                    }
//                    if (!_dbContext.QuestTypes.Any())
//                    {
//                        var questTypeList = GetQuestTypeList();
//                        _dbContext.QuestTypes.AddRange(questTypeList);
//                        _dbContext.SaveChanges();
//                    }
//                    if (!_dbContext.Quests.Any())
//                    {
//                        var questsList = GetQuestsList();
//                        _dbContext.Quests.AddRange(questsList);
//                        _dbContext.SaveChanges();
//                    }
//                    if (!_dbContext.QuestToUsers.Any())
//                    {
//                        var questToUsersList = GetQuestToUsersList();
//                        _dbContext.QuestToUsers.AddRange(questToUsersList);
//                        _dbContext.SaveChanges();
//                    }
//                    if (!_dbContext.Equipments.Any())
//                    {
//                        var equipmentList = GetEquipmentList();
//                        _dbContext.Equipments.AddRange(equipmentList);
//                        _dbContext.SaveChanges();
//                    }

//                    if (!_dbContext.EquipmentSets.Any())
//                    {
//                        var equipmentSetList = GetEquipmentSetList();
//                        _dbContext.EquipmentSets.AddRange(equipmentSetList);
//                        _dbContext.SaveChanges();
//                    }

//                    if (!_dbContext.EquipmentSetToEquipments.Any())
//                    {
//                        var equipmentSeToEquipmenttList = GetEquipmentSetToEquipmentList();
//                        _dbContext.EquipmentSetToEquipments.AddRange(equipmentSeToEquipmenttList);
//                        _dbContext.SaveChanges();
//                    }

//                    if (!_dbContext.Orders.Any())
//                    {
//                        var orderstList = GetOrderList();
//                        _dbContext.Orders.AddRange(orderstList);
//                        _dbContext.SaveChanges();
//                    }



//                    if (!_dbContext.QuestToEquipments.Any())
//                    {
//                        var questToEquipmentsList = GetQuestToEquipmentsList();
//                        _dbContext.QuestToEquipments.AddRange(questToEquipmentsList);
//                        _dbContext.SaveChanges();
//                    }

//                    if (!_dbContext.OccurrenceTypes.Any())
//                    {
//                        var occurrenceTypesList = GetOccurrenceTypesList();
//                        _dbContext.OccurrenceTypes.AddRange(occurrenceTypesList);
//                        _dbContext.SaveChanges();
//                    }

//                    if (!_dbContext.Occurrences.Any())
//                    {
//                        var occurrencesList = GetOccurrencesList();
//                        _dbContext.Occurrences.AddRange(occurrencesList);
//                        _dbContext.SaveChanges();
//                    }                    
//                }
//            }
//        }

//        private IEnumerable<Supplier> GetSupplierList()
//        {
//            var suppliers = new List<Supplier>()
//            {
//                new Supplier() { Name = "Suplier1"
//                }
//            };
//            return suppliers;

//        }
//        private IEnumerable<Order> GetOrderList()
//        {
//            var orders = new List<Order>()
//            {
//                new Order() { Name = "Order1", SupplierId = _dbContext.Suppliers.First().Id
//                }
//            };
//            return orders;

//        }

//        private IEnumerable<Address> GetAddressesList()
//        {
//            var adrdresses = new List<Address>()
//            {
//                new Address() {City = "Łapczyca",PostalCode = "32-744",Street = "Kalinowa"
//                }
//            };
//            return adrdresses;

//        }

//        //private IEnumerable<Role> GetRoleList()
//        //{
//        //    var roles = new List<Role>(){
//        //      new Role(){
//        //        Name = "Admin"
//        //      },
//        //      new Role(){
//        //        Name = "Menager"
//        //      },
//        //      new Role(){
//        //        Name = "User"
//        //      }
//        //    };

//        //    return roles;
//        //}

//        private IEnumerable<IdentityUser> GetUsersList()
//        {
//            var users = new List<IdentityUser>()
//            { 
//            new IdentityUser(){
//                UserName = "1",
//                Email = "1@.com"       
//            }
            
//            };
//            return users;


//        }

//        private IEnumerable<QuestType> GetQuestTypeList() 
//        {
//            var questTypes = new List<QuestType>()
//            {
//                new QuestType(){
//                    Name = "qt1",
//                    DefaultPriority = 1,
//                    CreationDateTime = DateTime.Now,
//                    LastModifyDateTime = DateTime.Now
//                },
//                new QuestType(){
//                    Name = "qt2",
//                    DefaultPriority = 2,
//                    CreationDateTime = DateTime.Now,
//                    LastModifyDateTime = DateTime.Now
//                },
//                 new QuestType(){
//                    Name = "qt3",
//                    DefaultPriority = 3,
//                    CreationDateTime = DateTime.Now,
//                    LastModifyDateTime = DateTime.Now
//                }
//            };
//            return questTypes;
//        }

//        private IEnumerable<Quest> GetQuestsList()
//        {
//            var users = _dbContext.Users.OrderBy(o => o.Id);
//            var types = _dbContext.QuestTypes.OrderBy(o => o.Id);
//            var quests = new List<Quest>()
//            {
//                new Quest(){
//                    Name = "q1",
//                    Description = "q1",
//                    Priority = 0,
//                    QuestTypeId = types.First().Id,
//                    CreatedByUserId = int.Parse(users.First().Id),
//                    LastModifyByUserId = users.First().Id,
//                    DeadLineDataTime = new DateTime(2024,02,20),
//                    CreationDateTime = DateTime.Now,
//                    LastModifyDateTime = DateTime.Now
//                },
//                new Quest(){
//                    Name = "q2",
//                    Description = "q2",
//                    Priority = 1,
//                    QuestTypeId = types.Last().Id,
//                    CreatedByUserId = users.Last().Id,
//                    LastModifyByUserId = users.Last().Id,
//                    DeadLineDataTime = new DateTime(2024,02,20),
//                    CreationDateTime = DateTime.Now,
//                    LastModifyDateTime = DateTime.Now
//                },
//                 new Quest(){
//                    Name = "q3",
//                    Description = "q3",
//                    Priority = 2,
//                    QuestTypeId = types.First().Id,
//                    CreatedByUserId = users.Last().Id,
//                    LastModifyByUserId = users.Last().Id,
//                    DeadLineDataTime = new DateTime(2024,02,20),
//                    CreationDateTime = DateTime.Now,
//                    LastModifyDateTime = DateTime.Now
//                }
//            };
//            return quests;
//        }
//        private IEnumerable<EquipmentSet> GetEquipmentSetList()
//        {
//            var equipmentSets = new List<EquipmentSet>()
//            {
//                new EquipmentSet() { Name = "EquipmentSet1",Description = "EquipmentSet1_Description"
//                }
//            };
//            return equipmentSets;

//        }
//        private IEnumerable<EquipmentSetToEquipment> GetEquipmentSetToEquipmentList()
//        {
//            var equipmentSetToEquipments = new List<EquipmentSetToEquipment>();

//            var eqSet = _dbContext.EquipmentSets.First();
//            foreach (var item in _dbContext.Equipments)
//            {
//                equipmentSetToEquipments.Add(new EquipmentSetToEquipment() { EquipmentID = item.Id, EquipmentSetID = eqSet.Id });

//            }
//            return equipmentSetToEquipments;

//        }
//        private IEnumerable<Equipment> GetEquipmentList()
//        {
//            var equipments = new List<Equipment>()
//            {
//                new Equipment(){
//                    Name = "e1",
//                    Condition = Cmms.Domain.Dictionary.Dictionary.EquipmentCondition.Operating,
//                    Model = "m1",
//                    LastServiceDateTime = new DateTime(2024,1,1),
//                    CreatedByUserId = _dbContext.Users.OrderBy(o => o.Id).First().Id,
//                    LastModifyByUserId = _dbContext.Users.OrderBy(o => o.Id).First().Id,
//                    CreationDateTime = DateTime.Now,
//                    LastModifyDateTime = DateTime.Now,
//                    SN = "sn1"
//                },
//                new Equipment(){
//                    Name = "e2",
//                    Condition = Cmms.Domain.Dictionary.Dictionary.EquipmentCondition.Foulty,
//                    Model = "m2",
//                    CreatedByUserId = _dbContext.Users.OrderBy(o => o.Id).Last().Id,
//                    LastModifyByUserId = _dbContext.Users.OrderBy(o => o.Id).Last().Id,
//                    CreationDateTime = DateTime.Now,
//                    LastModifyDateTime = DateTime.Now,
//                    SN = "sn2"
//                },
//                 new Equipment(){
//                    Name = "e3",
//                    Condition = Cmms.Domain.Dictionary.Dictionary.EquipmentCondition.Operating,
//                    Model = "m2",
//                    CreatedByUserId = _dbContext.Users.OrderBy(o => o.Id).Last().Id,
//                    LastModifyByUserId = _dbContext.Users.OrderBy(o => o.Id).Last().Id,
//                    CreationDateTime = DateTime.Now,
//                    LastModifyDateTime = DateTime.Now,
//                    SN = "sn3"
//                }
//            };
//            return equipments;
//        }
//        private IEnumerable<QuestToUser> GetQuestToUsersList()
//        {
//            var questToUsers = new List<QuestToUser>()
//           { new QuestToUser(){
//               QuestId = _dbContext.Quests.OrderBy(o => o.Id).First().Id,
//               UserId = _dbContext.Users.OrderBy(o => o.Id).Last().Id,
//           }
//           };
//            return questToUsers;
//        }

//        private IEnumerable<QuestToEquipment> GetQuestToEquipmentsList()
//        {
//            var questToEquipments = new List<QuestToEquipment>()
//           { new QuestToEquipment(){
//               QuestId = _dbContext.Quests.OrderBy(o => o.Id).First().Id,
//               EquipmentId = _dbContext.Equipments.OrderBy(o => o.Id).Last().Id               
//           }
//           };
//            return questToEquipments;
//        }

//        private IEnumerable<OccurrenceType> GetOccurrenceTypesList()
//        {
//            var occurrenceTypeList = new List<OccurrenceType>()
//           { 
//               new OccurrenceType(){
//               Name = "Przeglad",
//               DefaultPriority = 1
//           },
//            new OccurrenceType(){
//               Name = "Konserwacja",
//               DefaultPriority = 2,
//           },
//            new OccurrenceType(){
//               Name = "Awaria",
//               DefaultPriority = 3
//           }                
//           };
//            return occurrenceTypeList;
//        }

//        private IEnumerable<Occurrence> GetOccurrencesList()
//        {
//            var occurrences = new List<Occurrence>()
//           { new Occurrence(){
//               Description = "D1",               
//               EquipmentId = _dbContext.Equipments.OrderBy(o => o.Id).Last().Id,
//               OccurrenceTypeId = _dbContext.OccurrenceTypes.First().Id,
//               Priority = 1,
//           },
//           new Occurrence(){
//               Description = "D2",
//               EquipmentId = _dbContext.Equipments.OrderBy(o => o.Id).Last().Id,
//               OccurrenceTypeId = _dbContext.OccurrenceTypes.First().Id,
//               Priority = 2,
//           },
//           new Occurrence(){
//               Description = "D3",
//               EquipmentId = _dbContext.Equipments.OrderBy(o => o.Id).Last().Id,
//               OccurrenceTypeId = _dbContext.OccurrenceTypes.OrderBy(o => o.Id).Last().Id,
//               Priority = 3,
//           }
//           };
//            return occurrences;
//        }      
//    }
//}
