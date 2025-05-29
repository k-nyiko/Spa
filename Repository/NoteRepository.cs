using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.NoteDTO;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _context;
        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Note> CreateNote(Note notesModel)
        {
            await _context.Notes.AddAsync(notesModel);
            await _context.SaveChangesAsync();

            return notesModel;
        }

        public async Task<Note?> DeleteNote(int id)
        {
            var notesModel = await _context.Notes.FirstOrDefaultAsync(n => n.NoteId == id);
            if (notesModel == null)
            {
                return null;
            }

            _context.Notes.Remove(notesModel);
            await _context.SaveChangesAsync();

            return notesModel;
        }

        /// <summary>
        /// Returns all the notes a store staff added
        /// For now return all notes we can implement get by id method if the frontend changes
        /// </summary>
        /// <returns></returns>
        public async Task<List<Note>> getAllNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note?> GetById(int id)
        {
             return await _context.Notes.FindAsync(id);
        }

        public async Task<Note?> UpdateNote(int id, UpdateNoteDTO NoteDTO)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.NoteId == id);
            if (note == null)
            {
                return null;
            }

            note.StaffNotes = NoteDTO.StaffNotes;
            note.Tag = NoteDTO.Tag;

            await _context.SaveChangesAsync();
            return note;
        }
    }
}