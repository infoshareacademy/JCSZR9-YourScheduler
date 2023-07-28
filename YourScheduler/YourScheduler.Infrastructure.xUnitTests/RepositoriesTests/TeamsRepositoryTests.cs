﻿using FluentAssertions;
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
    public class TeamsRepositoryTests
    {
       
        [Fact]
        public async Task TeamRepository_AddTeam_ReturnAddedTeamById()
        {
            //Assign
            var context = ContextGenerator.Generate();
            var repository = new TeamsRepository(context);
            Team team = new Team
            {
                TeamId=1,
                Name="Piłkarze",
                Description="Bardzo lubimy grać w piłkę nożną",
                PicturePath = "/Picures/Pilkarz.jpg"
                
            };
          
            //Act
            await repository.AddTeamAsync(team);
            
            var teamReturned = await repository.GetTeamByIdAsync(1);

            //Assert
            teamReturned.TeamId.Should().Be(1);  
                     
            
        }

        [Fact]
        public async Task AddTeam_CheckIfListTeamsIsNotEmpty()
        {
            //Assign
            var context = ContextGenerator.Generate();
            var repository = new TeamsRepository(context);
            Team team = new Team
            {
                Name = "Piłkarze",
                Description = "Bardzo lubimy grać w piłkę nożną",
                PicturePath="/Picures/Pilkarz.jpg"
            };


            // Act
            await repository.AddTeamAsync(team);
            var teamReturned = await repository.GetAllExistedTeamsAsync();  

            //Assert
            teamReturned.Should().NotBeNullOrEmpty();
        }
    }
}