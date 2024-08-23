using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.Entity
{
    public class MenuEntity
    {
        public int MenuId { get; set; }

        public string MenuHeader { get; set; }

        public string targetView { get; set; }

        public string MenuIcon { get; set; }

        public int Index { get; set; }

        public bool MenuType { get; set; }

        public int State { get; set; }
    }
}
