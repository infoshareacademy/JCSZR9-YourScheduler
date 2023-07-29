using YourScheduler.BusinessLogic.Mapppers;
using Xunit;
using YourScheduler.BusinessLogic.Models.DTOs;
using FluentAssertions;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.xUnitTests.ServiceTests
{
    public class TeamMapperTest
    {
        private readonly TeamMapper _teamMapper;

        public TeamMapperTest()
        {
            _teamMapper = new TeamMapper();
        }

        [Fact]
        public void TeamDtoToTeamMap_CheckIfMappingIsCorrect()
        {
            //Arrange
            TeamDto teamDto = new TeamDto()
            {
                Id = 1,
                Name = "Sangria",
                Description = "Test",
                AdministratorId = 2,
            };

            //Act
            var result = _teamMapper.TeamDtoToTeamMap(teamDto);

            //Assert
            result.Should().NotBeNull();
            result.TeamId.Should().Be(teamDto.Id);
            result.Name.Should().Be(teamDto.Name);
            result.Description.Should().Be(teamDto.Description);
            result.AdministratorId.Should().Be(teamDto.AdministratorId);
        }

        [Fact]
        public void TeamToTeamDtoMap_CheckIfMappingIsCorrect()
        {
            //Arrange
            Team teamFromDataBase = new Team()
            {
                TeamId = 1,
                Name = "Sagria",
                Description = "Test",
                AdministratorId = 2,
            };

            //Act
            var result = _teamMapper.TeamToTeamDtoMap(teamFromDataBase);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(teamFromDataBase.TeamId);
            result.Name.Should().Be(teamFromDataBase.Name);
            result.Description.Should().Be(teamFromDataBase.Description);
            result.AdministratorId.Should().Be(teamFromDataBase.AdministratorId);
        }
    }
}
