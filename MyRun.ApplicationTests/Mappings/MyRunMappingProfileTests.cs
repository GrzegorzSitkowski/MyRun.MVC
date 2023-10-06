using Xunit;
using MyRun.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyRun.Application.ApplicationUser;
using AutoMapper;
using MyRun.Application.Race;
using FluentAssertions;

namespace MyRun.Application.Mappings.Tests
{
    public class MyRunMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapRaceDtoToRace()
        {
            //arange
            var userContext = new Mock<IUserContext>();
            userContext
                   .Setup(c => c.GetCurrentUser())
                   .Returns(new CurrentUser("1", "test@example.com"));

            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new MyRunMappingProfile(userContext.Object)));

            var mapper = configuration.CreateMapper();

            var dto = new RaceDto
            {
                Id = 1,
                Name = "Marathon Poznan",
                Country = "Poland",
                City = "Poznan",
                Number = "5175",
                Place = "1827",
                Distance = "42.197",
                Result = "03:47:56",
                AveragePace = "05:16",
                Date = DateTime.Now,
                Note = "PB"
            };
            //arange

            //act
            var result = mapper.Map<Domain.Entities.Race>(dto);
            //act

            //assert
            result.Should().NotBeNull();
            //assert

        }

        [Fact()]
        public void MappingProfile_ShouldMapRacetoRaceDto()
        {

            //arange
            var userContext = new Mock<IUserContext>();
            userContext
                   .Setup(c => c.GetCurrentUser())
                   .Returns(new CurrentUser("1", "test@example.com"));

            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new MyRunMappingProfile(userContext.Object)));

            var mapper = configuration.CreateMapper();

            var race = new Domain.Entities.Race
            {
                Id = 1,
                CreatedById = "1",
                Name = "Marathon Poznan",
                Country = "Poland",
                City = "Poznan",
                Number = "5175",
                Place = "1827",
                Distance = "42.197",
                Result = "03:47:56",
                AveragePace = "05:16",
                Date = DateTime.Now,
                Note = "PB"
            };
            //arange

            //act
            var result = mapper.Map<RaceDto>(race);
            //act

            //asser
            result.Should().NotBeNull();
            result.IsEditable.Should().BeTrue();
            //asser
        }
    }
}