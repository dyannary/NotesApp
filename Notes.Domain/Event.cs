using Notes.DataTransferObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain
{
    internal class Event
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
