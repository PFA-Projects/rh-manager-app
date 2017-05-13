using App.Gwin.Entities;
using App.Gwin.Entities.Secrurity.Autorizations;
using RH_managementSolution.BAL;

namespace App.Gwin.Application.BAL.Security
{
    /// <summary>
    /// [Bug] this class use TestModelContext and Not ModelContext of Application
    /// </summary>
    public class RoleBAO : BaseBLO<Role>
    {

        public override void ApplyBusinessRolesAfterValuesChanged(object sender, BaseEntity entity)
        {

            Role role = entity as Role;
            string field_name = (string) sender;

            switch (field_name)
            {
                // Business Role : the role name mut be UperCase
                case nameof(role.Name): 
                    {
                        role.Name.Current = role.Name.Current.ToUpper();
                    }
                    break;
            }
        }
    }
}
