using App.Gwin.Attributes;
using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_managementSolution.Entities
{
    [GwinEntity(Localizable = true, DisplayMember = "leaveCategory", isMaleName = false)]
    [Menu(Group = "LeaveManagement")]
    [ManagementForm(Width = 900)]
    public class LeaveAsk : BaseEntity
    {
        [EntryForm(GroupeBox = "leaveCategory", isRequired = true, WidthControl = 120)]
        [DataGrid(WidthColonne = 150)]
        [Filter(isValeurFiltreVide = true)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public virtual LeaveCategory leaveCategory { get; set; }

        [EntryForm(GroupeBox = "staff", isRequired = true, WidthControl = 120)]
        [DataGrid]
        [Filter(isValeurFiltreVide = true)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public virtual Staff staff { get; set; }

        [EntryForm(GroupeBox = "Dates", isRequired = true, WidthControl = 120)]
        [DataGrid]
        public DateTime startDate { get; set; }

        [EntryForm(GroupeBox = "Dates", isRequired = true, WidthControl = 120)]
        [DataGrid]
        public DateTime endDate { get; set; }

        [NotMapped]
        [DataGrid]
        [EntryForm]
        public int nbDaysWanted { get; set; }

    }
}
