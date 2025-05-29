using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.NoteDTO
{
    public class CreateNoteDTO
    {
        public int NoteId { get; set; }
        public string StaffNotes { get; set; } = string.Empty;  
        public string Tag { get; set; }
    }
}