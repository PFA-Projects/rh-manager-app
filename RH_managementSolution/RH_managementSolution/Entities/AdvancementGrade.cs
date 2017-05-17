using App.Gwin.Attributes;
using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_managementSolution.Entities
{
    [GwinEntity(Localizable = true, DisplayMember = "authorized")]
    [Menu(Group = "Staff")]
    public class AdvancementGrade : BaseEntity
    {
        [EntryForm(GroupeBox = "AdvancementScales")]
        [DataGrid(WidthColonne = 100)]
        public Staff staff { get; set; }

        [EntryForm(GroupeBox = "AdvancementScales")]
        [DataGrid(WidthColonne = 100)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        [Filter(isValeurFiltreVide = true)]
        public StaffGrade grade { get; set; }

        [EntryForm(GroupeBox = "AdvancementScales")]
        [DataGrid(WidthColonne = 100)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        [Filter(isValeurFiltreVide = true)]
        public DateTime advancementDate { get; set; }
    }
}
