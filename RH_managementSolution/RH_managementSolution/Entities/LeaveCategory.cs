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
    [GwinEntity(DisplayMember = "NameOfLeaveCategory", Localizable = true, isMaleName = false)]
    [Menu(Group = "LeaveManagement")]
    [ManagementForm(Width = 800)]
    public class LeaveCategory : BaseEntity
    {
        public LeaveCategory()
        {
            this.Description = new LocalizedString();
            this.NameOfLeaveCategory = new LocalizedString();
        }

        [EntryForm(GroupeBox = "LeaveCategory", WidthControl = 200, isRequired = true)]
        [DataGrid(WidthColonne = 150, Ordre = 1)]
        [Filter]
        public LocalizedString NameOfLeaveCategory { get; set; }

        [EntryForm(MultiLine = true, NumberLine = 5, WidthControl = 250, GroupeBox = "LeaveCategory")]
        [DataGrid(WidthColonne = 200, Ordre = 2)]
        public LocalizedString Description { get; set; }


        [EntryForm(GroupeBox = "LeaveCategory", WidthControl = 100, isRequired = true)]
        [DataGrid(WidthColonne = 150, Ordre = 3)]
        public int nbDays { get; set; }
    }
}
