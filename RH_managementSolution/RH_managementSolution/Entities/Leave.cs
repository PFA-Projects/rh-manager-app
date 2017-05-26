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
    [GwinEntity(Localizable = true, DisplayMember = "staff", isMaleName = true)]
    [Menu(Group = "LeaveManagement")]
    public class Leave : BaseEntity
    {
        [EntryForm(Ordre = 2,GroupeBox ="Leave",isRequired =true)]
        [DataGrid]
        [Filter(isValeurFiltreVide = true)]
        [Relationship(Relation =RelationshipAttribute.Relations.ManyToOne)]
        public LeaveAsk leaveAsk { get; set; }
        
        [EntryForm (Ordre =1, GroupeBox = "Leave",isRequired =true)]
        [DataGrid]
        [Filter(isValeurFiltreVide = true)]
        [Relationship(Relation =RelationshipAttribute.Relations.ManyToOne)]
        public Staff staff { get; set; }
    }
}
