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
    [Menu(Group = "AbseenteismManagement")]
    public class Absenteeism:BaseEntity
    {

        [EntryForm(isRequired =true,GroupeBox = "Authorization")]
        [DataGrid]
        public bool authorized { get; set; }
        

        [EntryForm(isRequired =true, GroupeBox = "Staffs")]
        [DataGrid]
        [Relationship(Relation =RelationshipAttribute.Relations.ManyToOne)]

        [Filter(isValeurFiltreVide=true)]
        public Staff staff { get; set; }


        [EntryForm(isRequired = true,GroupeBox ="Dates")]
        [DataGrid]
        public DateTime startDate { get; set; }

        
        [EntryForm(isRequired = true, GroupeBox = "Dates")]
        [DataGrid]
        public DateTime endDate { get; set; }
    }
}
