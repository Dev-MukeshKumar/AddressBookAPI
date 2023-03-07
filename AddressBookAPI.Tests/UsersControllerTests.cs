using AddressBookAPI.Context;
using AddressBookAPI.Controllers;
using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Helpers;
using AddressBookAPI.Helpers.Security.Hashing;
using AddressBookAPI.Services.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Validations;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Xunit;

namespace AddressBookAPI.Tests
{
    public class UsersControllerTests
    {
         public class UserSeedDataFixture : IDisposable
        {
            public AddressBookDbContext appDbContext { get; private set; }

            public UserSeedDataFixture()
            {
                DbContextOptions<AddressBookDbContext> dbContextOptions = new DbContextOptionsBuilder<AddressBookDbContext>().UseInMemoryDatabase(databaseName: "AuthenticationMBusDB").Options;
                appDbContext = new AddressBookDbContext(dbContextOptions);

                PasswordHasher passwordHasher = new PasswordHasher();

                appDbContext.Database.EnsureCreated();

                #region Seeding user data
                var userDataList = new List<User>()
                {
                    new User()
                    {
                        Id = new Guid("30e82623-f675-4f1f-2542-08da90bf8efd"),
                        UserName = "mukesh@example.com",
                        FirstName = "Mukesh",
                        LastName = "Kumar",
                        Hash = passwordHasher.HashPassword("mukesh@123")
                    },
                    new User()
                    {
                        Id = new Guid("4b3c0212-f1eb-4433-bce1-eaaf8a5159c2"),
                        UserName = "madhav@example.com",
                        FirstName = "Madhav",
                        LastName = "Kumar",
                        Hash = passwordHasher.HashPassword("madhav@123")
                    },
                };
                appDbContext.Users.AddRange(userDataList);
                #endregion

                appDbContext.SaveChanges();
            }

            public void Dispose()
            {
                appDbContext.Database.EnsureDeleted();
                appDbContext.Dispose();
            }
        }

        public class UsersControllerTests : IClassFixture<UserSeedDataFixture>
        {

            UserSeedDataFixture fixture;

            public UsersControllerTests(UserSeedDataFixture fixture)
            {
                this.fixture = fixture;
            }

            private AddressBookDbContext GetMockDB()
            {
                return fixture.appDbContext;
            }

            private UsersController GetController()
            {
                var appDbContext = GetMockDB();

                IOptions<AppSettings> appSettings = Options.Create(new AppSettings
                {
                    ExpirationInMinutes = "1440",
                    Secret = "this is a secret"
                });

                PasswordHasher passwordHasher = new PasswordHasher();
                UnitOfWork unitOfWork = new UnitOfWork(appDbContext);
                BusRepository busRepository = new BusRepository(appDbContext);
                TicketRepository ticketRepository = new TicketRepository(appDbContext);
                UserRepository userRepository = new UserRepository(appDbContext);
                OwnerRepository ownerRepository = new OwnerRepository(appDbContext);
                UserServices usersService = new UserServices(userRepository, unitOfWork, passwordHasher, busRepository, ticketRepository);
                OwnerServices ownersService = new OwnerServices(ownerRepository, unitOfWork, passwordHasher, busRepository, ticketRepository);

                MapperConfiguration config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new UsersProfile());
                    cfg.AddProfile(new BusesProfile());
                    cfg.AddProfile(new TicketsProfile());
                    cfg.AddProfile(new OwnersProfile());
                });
                IMapper mapper = new Mapper(config);

                AuthenticateService authenticateService = new AuthenticateService(usersService, appSettings, ownersService, mapper);
                AuthenticationController authenticationController = new AuthenticationController(authenticateService, mapper);

                return authenticationController;
            }
        }
}

