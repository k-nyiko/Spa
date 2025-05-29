using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.NoteDTO
{
    public class NoteRequestDTO
    {
        public string StaffNotes { get; set; } = string.Empty;  //Have an Id so cannot have a null note
        public string Tag { get; set; } //Follow up , preferences, vip or anything
    }
}