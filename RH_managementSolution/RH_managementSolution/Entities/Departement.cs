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
    [GwinEntity(DisplayMember = "name", Localizable = true)]
    [Menu(Group = "Staff")]
    public class Departement:BaseEntity
    {
        [DataGrid]
        [Filter]
        [EntryForm(isRequired =true,GroupeBox ="Deepartement")]
        public LocalizedString name { get; set; }

        [DataGrid]
        [Filter]
        [EntryForm(WidthControl = 500, MultiLine = true, NumberLine = 5, GroupeBox = "Deepartement")]
        public LocalizedString Description { get; set; }
    }
}
