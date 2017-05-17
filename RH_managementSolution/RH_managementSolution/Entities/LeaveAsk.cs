using App.Gwin.Attributes;
using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_managementSolution.Entities
{
    [GwinEntity(Localizable = true, DisplayMember = "Description")]
    [Menu(Group = "LeaveManagement")]
    public class LeaveAsk : BaseEntity
    {
        [EntryForm(GroupeBox = "leaveCategory",isRequired =true)]
        [DataGrid]
        [Filter(isValeurFiltreVide = true)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public LeaveCategory leaveCategory { get; set; }

        [EntryForm(GroupeBox = "staff", isRequired =true)]
        [DataGrid]
        [Filter(isValeurFiltreVide = true)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public Staff staff { get; set; }

        [EntryForm(GroupeBox = "Dates",isRequired =true)]
        [DataGrid]
        [Filter]
        public DateTime startDate { get; set; }

        [EntryForm(GroupeBox = "Dates",isRequired =true)]
        [DataGrid]
        [Filter]
        public DateTime endDate { get; set; }

    }
}
