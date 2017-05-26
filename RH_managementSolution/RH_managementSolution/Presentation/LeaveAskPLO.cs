using App.Gwin.Components.Manager.EntryForms.PLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Gwin;
using App.Gwin.Fields;
using RH_managementSolution.Entities;

namespace RH_managementSolution.Presentation
{
    public class LeaveAskPLO : IGwinPLO
    {
        public void FormAfterInit(BaseEntryForm EntryForm)
        {
        }

        public void FormBeforInit(BaseEntryForm EntryForm)
        {
        }

        public void ValidatingFiled(BaseEntryForm EntryForm, object sender)
        {
        }

        public void ValueChanged(BaseEntryForm EntryForm, object sender)
        {
            BaseField field = sender as BaseField;

            switch (field.Name)
            {
                case nameof(LeaveAsk.leaveCategory):
                    {
                        //ComboBoxField leavecatfield = field as ComboBoxField;
                        //ManyToOneField Stafffield = EntryForm.Fields[nameof(LeaveAsk.staff)] as ManyToOneField;
                        //Staff staff = Stafffield.SelectedItem as Staff;
                        //Int32Filed nbdays = EntryForm.Fields[nameof(LeaveAsk.nbDaysWanted)] as Int32Filed;

                        ManyToOneField leavecatfield = EntryForm.Fields[nameof(LeaveAsk.leaveCategory)] as ManyToOneField;
                        LeaveCategory leavecategory = leavecatfield.SelectedItem as LeaveCategory;
                        ManyToOneField stafffield = EntryForm.Fields[nameof(LeaveAsk.staff)] as ManyToOneField;
                        Staff staff = stafffield.SelectedItem as Staff;
                        Int32Filed nbdays = EntryForm.Fields[nameof(LeaveAsk.nbDaysWanted)] as Int32Filed;

                        if (leavecategory.Reference== "Administrativeleave")
                        {
                            staff.nbTotalDaysAdmin = staff.nbTotalDaysAdmin - nbdays;
                        }


                    }
                    break;
            }
        }
    }
}
