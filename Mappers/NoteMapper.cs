using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.NoteDTO;
using api.Models;
using Npgsql.Replication;

namespace api.Mappers
{
    public static class NoteMapper
    {
        public static CreateNoteDTO ToNoteDTO(Note noteModel)
        {
            return new CreateNoteDTO
            {
                NoteId = noteModel.NoteId,
                StaffNotes = noteModel.StaffNotes,
                Tag = noteModel.StaffNotes
            };
        }

        public static Note NewNote(this NoteRequestDTO newNoteDTO)
        {
            return new Note
            {
                StaffNotes = newNoteDTO.StaffNotes,
                Tag = newNoteDTO.Tag
            };
        }
    }
}