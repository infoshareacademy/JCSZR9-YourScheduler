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
        };

        var result = _eventMapper.EventDtoToEventMap(eventDto);

        result.Should().NotBeNull();
        result.Name.Should().Be(eventDto.Name);
        result.Description.Should().Be(eventDto.Description);
        result.Date.Should().Be(eventDto.Date);
    }

    [Fact]
    public void EventToEventDtoMapp_CheckCorrectnessMapping()
    {
        Event eventFromDataBase = new Event()
        {
            Name = "Heniek",
            Description = "Pływamy",
            Date = DateTime.MinValue,
        };

        var result = _eventMapper.EventToEventDtoMapp(eventFromDataBase);

        result.Should().NotBeNull();
        result.Name.Should().Be(eventFromDataBase.Name);
        result.Description.Should().Be(eventFromDataBase.Description);
        result.Date.Should().Be(eventFromDataBase.Date);
    }
}
