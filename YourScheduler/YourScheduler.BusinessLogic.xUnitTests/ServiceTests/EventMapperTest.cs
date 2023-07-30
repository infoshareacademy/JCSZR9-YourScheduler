using YourScheduler.BusinessLogic.Mapppers;
using Xunit;
using YourScheduler.BusinessLogic.Models.DTOs;
using FluentAssertions;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.xUnitTests.ServiceTests;

public class EventMapperTest
{
    private readonly EventMapper _eventMapper;

    public EventMapperTest()
    {
        _eventMapper = new EventMapper();
    }

    [Fact]
    public void EventDtoToEventMapp_CheckCorrectnesMapping()
    {
        EventDto eventDto = new EventDto()
        {
            Name = "Heniek",
            Description = "Pływamy",
            Date = DateTime.MinValue,
            Isopen = true,
            AdministratorId = 2,
        };

        var result = _eventMapper.EventDtoToEventMap(eventDto);

        result.Should().NotBeNull();
        result.Name.Should().Be(eventDto.Name);
        result.Description.Should().Be(eventDto.Description);
        result.Date.Should().Be(eventDto.Date);
        result.IsOpen.Should().BeTrue();
        result.administratorId.Should().Be(eventDto.AdministratorId);
    }

    [Fact]
    public void EventDtoWithIdToEventMapp_CheckCorrectnesMapping()
    {
        EventDto eventDto = new EventDto()
        {
            Id = 1,
            Name = "Heniek",
            Description = "Pływamy",
            Date = DateTime.MinValue,
            Isopen = true,
            AdministratorId = 2,
        };

        var result = _eventMapper.EventDtoWithIdToEventMap(eventDto);

        result.Should().NotBeNull();
        result.EventId.Should().Be(eventDto.Id);
        result.Name.Should().Be(eventDto.Name);
        result.Description.Should().Be(eventDto.Description);
        result.Date.Should().Be(eventDto.Date);
        result.IsOpen.Should().BeTrue();
        result.administratorId.Should().Be(eventDto.AdministratorId);
    }

    [Fact]
    public void EventToEventDtoMapp_CheckCorrectnessMapping()
    {
        Event eventFromDataBase = new Event()
        {
            EventId = 1,
            Name = "Heniek",
            Description = "Pływamy",
            Date = DateTime.MinValue,
            IsOpen = true,
            administratorId = 2,
        };

        var result = _eventMapper.EventToEventDtoMapp(eventFromDataBase);

        result.Should().NotBeNull();
        result.Id.Should().Be(eventFromDataBase.EventId);
        result.Name.Should().Be(eventFromDataBase.Name);
        result.Description.Should().Be(eventFromDataBase.Description);
        result.Date.Should().Be(eventFromDataBase.Date);
        result.Isopen.Should().BeTrue();
        result.AdministratorId.Should().Be(eventFromDataBase.administratorId);
    }
}
