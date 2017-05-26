using App.Gwin.Attributes;
using App.Gwin.Entities;
using RH_managementSolution.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_managementSolution.Entities
{
    [GwinEntity(Localizable = true, DisplayMember = "advancementDate", isMaleName = true)]
    [Menu(Group = "Staff")]
    [PresentationLogic(TypePLO = typeof(AdvancementGradePLO))]
    public class AdvancementGrade : BaseEntity
    {
        [EntryForm(GroupeBox = "AdvancementScales", isRequired = true)]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        [Filter(isValeurFiltreVide = true)]
        public GradeCategory gradecategory { get; set; }

        [EntryForm(GroupeBox = "AdvancementScales", isRequired = true)]
        [DataGrid(WidthColonne = 100)]
        [Filter(isValeurFiltreVide = true)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public Staff staff { get; set; }

        [EntryForm(GroupeBox = "AdvancementScales", isRequired = true)]
        [DataGrid(WidthColonne = 100)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        [Filter(isValeurFiltreVide = true)]
        public StaffGrade grade { get; set; }

        [EntryForm(GroupeBox = "AdvancementScales", isRequired = true)]
        [DataGrid(WidthColonne = 100)]
        public DateTime advancementDate { get; set; }
    }
}
