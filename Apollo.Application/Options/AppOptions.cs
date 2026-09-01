using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apollo.Application.Options
{
    public class AppOptions
    {
        public const string SectionName = "App";

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Environment { get; set; } = string.Empty;
    }
}
