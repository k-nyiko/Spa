using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.NoteDTO
{
    public class UpdateNoteDTO
    {
        // public int NoteId { get; set; } 
        //We don't update the note it must remain as it is
        public string StaffNotes { get; set; } = string.Empty;  //Have an Id so cannot have a null note
        public string Tag { get; set; } //Follow up , preferences, vip or anything
    }
}