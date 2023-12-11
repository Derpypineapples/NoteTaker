using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NoteTaker.Models
{
    public class Note
    {
        public int NoteID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string Slug => Name.Replace(' ', '-');
    }
}