using System;
using System.Collections.Generic;

namespace PackSlipApp.ViewModel
{
    public class DropdownViewModel
    {
        public List<Dropdown> Boxtypes { get; set; } = new List<Dropdown>();
    }

    public class Dropdown
    {
        public string Boxtype { get; set; }
    }
}
