using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shablon
{
    internal class Settings
    {
        public Settings() : base() { }

        public string? LoadDataPath { get; set; }
        public string? ResultFolderPath { get; set; }

        public string? TemplateFile { get; set; }

        public string? FileNamePrefix { get; set; }
    }
}
