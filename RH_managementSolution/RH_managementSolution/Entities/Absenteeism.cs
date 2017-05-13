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
    [GwinEntity(Localizable = true,DisplayMember ="authorized")]
    [Menu(Group = "Configuration")]
    public class Absenteeism:BaseEntity
    {

        [EntryForm]
        [DataGrid]
        public bool authorized { get; set; }
        

        [EntryForm]
        [DataGrid]
        [Relationship(Relation =RelationshipAttribute.Relations.ManyToOne)]
        public Staff staff { get; set; }
    }
}
