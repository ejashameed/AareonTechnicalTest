using AareonTechnicalTest.RequestHandlers.Notes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Controllers.Notes
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        public IMediator _mediator;

        #region constructor
        public NoteController(IServiceProvider serviceProvider)
        {
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }
        #endregion

        #region CreateNote
        [HttpPost]
        [Route("CreateNote")]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteCommand request)
        {
            var newNote = await _mediator.Send(request);
            return Ok(newNote);
        }
        #endregion

        #region updateNote
        [HttpPatch]
        [Route("UpdateNote")]
        public async Task<IActionResult> UpdateNote([FromBody] UpdateNoteCommand request)
        {
            var updatedNote = await _mediator.Send(request);
            return Ok(updatedNote);
        }
        #endregion
       
        #region DeleteNote
        [HttpDelete]
        [Route("DeleteNote")]
        public async Task<IActionResult> DeleteNote(DeleteNoteCommand request)
        {
            var deletedNote = await _mediator.Send(request);
            return Ok(deletedNote);
        }
        #endregion

        #region GetNotes
        [HttpGet]
        [Route("GetNotes")]
        public async Task<IActionResult> GetNotes([FromQuery] GetNotesQuery request)
        {
            var notes = await _mediator.Send(request);
            return Ok(notes);
        }
        #endregion

    }
}
