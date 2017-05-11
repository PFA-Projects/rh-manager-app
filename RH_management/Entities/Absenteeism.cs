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
    [GwinEntity(Localizable = true,DisplayMember ="reason")]
    [Menu(Group = "managements")]
    public class Absenteeism:BaseEntity
    {
        public Absenteeism()
        {
            this.reason = new LocalizedString();
        }
        [EntryForm]
        [DataGrid]
        public bool authorized { get; set; }

        [EntryForm]
        [DataGrid]
        public LocalizedString reason { get; set; }
    }
}
