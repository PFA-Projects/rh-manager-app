using App.Gwin.Components.Manager.EntryForms.PLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Gwin;
using RH_managementSolution.Entities;
using App.Gwin.Fields;

namespace RH_managementSolution.BAL
{
    public class StaffPLO : IGwinPLO
    {
        public void FormAfterInit(BaseEntryForm EntryForm)
        {
             EntryForm.Fields[nameof(Staff.grade)].Enabled=false; 
        }

        public void FormBeforInit(BaseEntryForm EntryForm)
        {

        }

        public void ValidatingFiled(BaseEntryForm EntryForm, object sender)
        {
        }

        public void ValueChanged(BaseEntryForm EntryForm, object sender)
        {
            
        }
    }
}

