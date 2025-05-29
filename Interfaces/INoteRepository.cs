using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.NoteDTO;
using api.Models;

namespace api.Interfaces
{
    public interface INoteRepository
    {
        //Note Interface the implementation will be on the repository folder
        Task<List<Note>> getAllNotes();
        Task<Note?> GetById(int id);
        Task<Note> CreateNote(Note notesModel);
        Task<Note?> UpdateNote(int id,UpdateNoteDTO NoteDTO);
        Task<Note?> DeleteNote(int id);
    }
}