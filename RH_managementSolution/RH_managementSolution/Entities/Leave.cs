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
    [GwinEntity(Localizable = true, DisplayMember = "Reference")]
    [Menu(Group = "Configuration")]
    public class Leave : BaseEntity
    {
        [EntryForm(Ordre = 2)]
        [DataGrid]
        [Relationship(Relation =RelationshipAttribute.Relations.ManyToOne)]
        public LeaveAsk leaveAsk { get; set; }

        [Filter]
        [EntryForm (Ordre =1)]
        [DataGrid]
        [Relationship(Relation =RelationshipAttribute.Relations.ManyToOne)]
        public Staff staff { get; set; }
    }
}
