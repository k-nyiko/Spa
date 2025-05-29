using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string StaffNotes { get; set; } = string.Empty;  //Have an Id so cannot have a null note
        public string Tag { get; set; } //Follow up , preferences, vip or anything
    }
}