using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.NoteDTO.ReviewDTO
{
    public class UpdateReviewDTO
    {
        public string Comment { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
    }
}