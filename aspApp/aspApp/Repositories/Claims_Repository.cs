using aspApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspApp.Repositories
{
    public class Claims_Repository : Repository<Claims>
    {
        public IEnumerable<Claims> GetClaimsDontHaveBy_IdRol_List(int idrol_value)
        {
            Claims_Repository claims_Repository = new Claims_Repository();
            RolClaims_Repository rolClaims_Repository = new RolClaims_Repository();

            List<Rolclaims> result_rollist = rolClaims_Repository.GetRolclaimsBy_IdRol(idrol_value).ToList();
            List<Claims> result_rolclaimshave = new List<Claims>();
            List<Claims> result_allclaims = GetAll().ToList();

            if (result_rollist != null)
            {
                foreach (var item in result_rollist)
                {
                    Claims _claims = new Claims()
                    {
                        Id = item.IdClaims
                    };

                    result_rolclaimshave.Add(_claims);
                }

                foreach (var item in result_rolclaimshave)
                {
                    result_allclaims.RemoveAll(x => x.Id == item.Id);
                }
            }

            //List<Claims> result_claims_minus_rolclaims = result_allclaims.Except(result_rolclaimshave).Concat(result_rolclaimshave.Except(result_allclaims)).ToList();
            //List<Claims> result_claims_minus_rolclaims = result_allclaims.RemoveAll(result_rolclaimshave.ForEach(x => x.Id ));

            //return claims_Repository.GetAll();
            //return result_claims_minus_rolclaims;
            return result_allclaims;
        }
    }
}