using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PalabrasApp.Shared
{
    public class Palabra
    {
        [Required]
        public string SpanishWord { get; set; }
        [Required]
        public string EnglishWord { get; set; }
    }
}
