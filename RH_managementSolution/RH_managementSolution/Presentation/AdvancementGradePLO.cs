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
    public class AdvancementGradePLO : IGwinPLO
    {
        public void FormAfterInit(BaseEntryForm EntryForm)
        {
            EntryForm.Fields[nameof(AdvancementGrade.grade)].Hide();
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
                case nameof(AdvancementGrade.gradecategory):
                    {
                        ManyToOneField gradecatfield = field as ManyToOneField;
                        GradeCategory gradecategory = gradecatfield.SelectedItem as GradeCategory;
                        if (gradecategory != null)
                        {
                            EntryForm.Fields[nameof(AdvancementGrade.grade)].Show();
                            ManyToOneField gradefield = EntryForm.Fields[nameof(AdvancementGrade.grade)] as ManyToOneField;
                            List<StaffGrade> ls = gradecategory.grades;
                            gradefield.DataSource = ls;
                        }
                    }
                    break;
            }
        }
    }
}
