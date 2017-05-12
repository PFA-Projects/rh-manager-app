using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_managementSolution.Entities
{
    [GwinEntity(DisplayMember = "NameOfLeaveCategory", Localizable = true)]
    [Menu(Group = "managements")]
    public class LeaveCategory:BaseEntity
    {
        public LeaveCategory()
        {
            this.Description = new LocalizedString();
            this.NameOfLeaveCategory = new LocalizedString();
            this.CountDays = new LocalizedString();
        }

        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString NameOfLeaveCategory { get; set; }

        [EntryForm]
        [DataGrid]
        public LocalizedString Description { get; set; }


        public LocalizedString CountDays { get; set; }
    }
}
