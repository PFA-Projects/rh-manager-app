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
    [GwinEntity(Localizable = true,DisplayMember = "Reference")]
    [Menu(Group = "managements")]
    public class Leave:BaseEntity
    {

       public LeaveAsk leaveAsk { get; set; }
    }
}
