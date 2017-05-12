using App.Gwin.Attributes;
using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_managementSolution.Entities
{
    [GwinEntity(Localizable = true, DisplayMember = "reason")]
    [Menu(Group = "managements")]
    public class LeaveAsk:BaseEntity
    {
        [EntryForm]
        [DataGrid]
        [Filter]
        public LeaveCategory leaveCategory { get; set; }

        [EntryForm]
        [DataGrid]
        [Filter]
        public Staff staff { get; set; }

        //[EntryForm]
        //[DataGrid]
        //[Filter]
        //public int countDays { get; set; }

    }
}
