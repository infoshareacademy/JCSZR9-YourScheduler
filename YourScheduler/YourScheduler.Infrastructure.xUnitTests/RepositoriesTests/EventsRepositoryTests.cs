using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.Infrastructure.xUnitTests.RepositoriesTests
{
    public class EventsRepositoryTests
    {

        [Fact]
        public async Task EventRepository_AddEvent_ReturnAddedEventById()
        {
            //Assign
            var context = ContextGenerator.Generate();
            var repository = new EventsRepository(context);
            Event eventBase = new Event
            {
                EventId = 1,
                Name = "Piłkarze",
                Description = "Bardzo lubimy grać w piłkę nożną",
                Date = DateTime.MaxValue,
                IsOpen = true,
                administratorId = 1,
                PicturePath = "/Pictures/pilkarz.jpg"


            };



            //Act
            await repository.AddEventAsync(eventBase);
            await repository.SaveDataAsync();
            var eventReturned = await repository.GetEventByIdAsync(1);
            //Assert
            eventReturned.EventId.Should().Be(1);



        }

        [Fact]
        public async Task AddEvent_CheckIfListEventsIsNotEmpty()
        {
            //Assign
            var context = ContextGenerator.Generate();
            var repository = new EventsRepository(context);
            Event eventBase = new Event
            {
                Name = "Piłkarze",
                Description = "Bardzo lubimy grać w piłkę nożną",
                administratorId = 1,
                Date = DateTime.MaxValue,
                EventId = 1,
                IsOpen = true,
                PicturePath = "/Pictures/pilkarz.jpg"
            };


            // Act
            await repository.AddEventAsync(eventBase);
            await repository.SaveDataAsync();
            var teamReturned = await repository.GetAvailableEventsAsync(1);

            //Assert
            teamReturned.Should().NotBeNullOrEmpty();
        }
    }
}

