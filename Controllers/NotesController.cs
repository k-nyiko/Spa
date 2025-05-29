using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.NoteDTO;
using api.Interfaces;
using api.Mappers;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/Notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _notesRepo;
        public NotesController(INoteRepository notesRepo)
        {
            _notesRepo = notesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> gettAllNotes()
        {
            var notes = await _notesRepo.getAllNotes();
            //var nt = notes.Select(n => n.ToNoteDTO());
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var note = await _notesRepo.GetById(id);
            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NoteRequestDTO noteDto)
        {
            var notes = noteDto.NewNote();
            await _notesRepo.CreateNote(notes);

            return CreatedAtAction(nameof(GetByID), new { id = notes.NoteId }, notes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote([FromRoute] int id, [FromBody] UpdateNoteDTO updatedNote)
        {
            var note = await _notesRepo.UpdateNote(id, updatedNote);
            if (note == null)
            {
                return NotFound();
            }

            note.StaffNotes = updatedNote.StaffNotes;
            note.Tag = updatedNote.StaffNotes;

            return Ok(note);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var note = await _notesRepo.DeleteNote(id);
            if (note == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}