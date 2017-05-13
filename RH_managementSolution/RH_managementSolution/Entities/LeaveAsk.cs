using App.Gwin.Attributes;
using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_managementSolution.Entities
{
    [GwinEntity(Localizable = true, DisplayMember = "startDate")]
    [Menu(Group = "Configuration")]
    public class LeaveAsk : BaseEntity
    {
        [EntryForm]
        [DataGrid]
        [Filter]
        [Relationship(Relation = RelationshipAttribute.Relations.OneToMany)]
        public LeaveCategory leaveCategory { get; set; }

        [EntryForm]
        [DataGrid]
        [Filter]
        public Staff staff { get; set; }

        [EntryForm]
        [DataGrid]
        [Filter]
        public DateTime startDate { get; set; }

        [EntryForm]
        [DataGrid]
        [Filter]
        public DateTime endDate { get; set; }

    }
}
