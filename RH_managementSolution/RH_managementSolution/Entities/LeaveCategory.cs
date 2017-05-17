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
    [Menu(Group = "LeaveManagement")]
    public class LeaveCategory:BaseEntity
    {
        public LeaveCategory()
        {
            this.Description = new LocalizedString();
            this.NameOfLeaveCategory = new LocalizedString();
        }

        [EntryForm(GroupeBox ="LeaveCategory",isRequired =true)]
        [DataGrid]
        [Filter]
        public LocalizedString NameOfLeaveCategory { get; set; }

        [EntryForm(MultiLine = true, NumberLine = 5,WidthControl =500, GroupeBox = "LeaveCategory")]
        [DataGrid]
        public LocalizedString Description { get; set; }
    }
}
