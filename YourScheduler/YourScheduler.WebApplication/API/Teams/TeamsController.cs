using global::YourScheduler.Infrastructure.Entities;
using global::YourScheduler.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace YourScheduler.WebApplication.API.Teams
{
    [ApiController]
        [Route("api/[controller]")]
        public class EventController : ControllerBase
        {
            private readonly IEventsRepository _eventsRespistory;
            public EventController(IEventsRepository eventsRepository)
            {
                _eventsRespistory = eventsRepository;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Event>>> GetAllEventsAsync(int userId)
            {
                try
                {
                    return Ok(_eventsRespistory.GetAvailableEventsAsync(userId));
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error retrieving data from the database");
                }
            }
            [HttpGet("{id:int}")]
            public async Task<ActionResult<Event>> GetEventByIdAsync(int userId)
            {
                try
                {
                    var retrievedEvent = _eventsRespistory.GetEventByIdAsync(userId);

                    if (retrievedEvent is null)
                    {
                        return NotFound();
                    }

                    return Ok(retrievedEvent);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error retrieving data from the database");
                }

            }
            [HttpPost]
            public async Task<ActionResult> AddEventAsync(Event eventToBeAdded)
            {
                try
                {
                    _eventsRespistory.AddEventAsync(eventToBeAdded);
                    var createdEvent =_eventsRespistory.GetEventByIdAsync(eventToBeAdded.EventId);

                    string uri = Url.Action("GetEventByIdAsync", new { id = createdEvent.Result.EventId });
                    return Created(uri, createdEvent);
                }
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error adding data to the database");
                }
            }
        }
    }



