using MOL.EFDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public partial class MOL_UnifiedNumber_Repository
    {
        public List<MOL_UnifiedNumber> GetUnifiedNumberListByRepresentitiveIDNO(long idNo)
        {
            // When new security model is applied, this implementation should be change.  It should get unififed Numbers from table UserRoleEntity.

            List<MOL_UnifiedNumber> lstUnifiedNumber;

            // AND IsVerified = 1
            // LEFT JOIN to determine whether the user is unified number user.
            //  on estAgent.FK_AgentTypeId equals 1L

            lstUnifiedNumber = (
                                from userEstab in Context.MOL_VwUserEstablishments
                                join estb in Context.MOL_Establishment on userEstab.PK_EstablishmentId equals estb.PK_EstablishmentId
                                join unifiedNumber in Context.MOL_UnifiedNumber on estb.FK_UnifiedNumberId equals unifiedNumber.PK_UnifiedNumberId
                                join estAgent in Context.MOL_EstablishmentAgent on userEstab.PK_AuthorizationId.Value equals estAgent.PK_EstablishmentAgentId into inner
                                from estAgent in inner.DefaultIfEmpty()
#pragma warning disable CS0472 // The result of the expression is always 'false' since a value of type 'long' is never equal to 'null' of type 'long?'
                                where userEstab.PK_AuthorizationId != null && userEstab.AuthorizedIdNo == idNo.ToString() && userEstab.IsVerified.Value && ((estAgent.PK_EstablishmentAgentId == null && userEstab.AuthorizedType == 1) || (estAgent.FK_AgentTypeId == 1 && userEstab.AuthorizedType == 2 && estAgent.FK_UnifiedNumberId == estb.FK_UnifiedNumberId))
#pragma warning restore CS0472 // The result of the expression is always 'false' since a value of type 'long' is never equal to 'null' of type 'long?'
                                select unifiedNumber)
                    .Distinct<MOL_UnifiedNumber>().ToList<MOL_UnifiedNumber>();

            return lstUnifiedNumber;
        }


        public List<MOL_UnifiedNumber> GetAllUnifiedNumbersByRepresentitiveIDNO(long idNo)
        {
            // When new security model is applied, this implementation should be change.  It should get unififed Numbers from table UserRoleEntity.
            List<MOL_UnifiedNumber> lstUnifiedNumber;
            lstUnifiedNumber = (
                                from userEstab in Context.MOL_VwUserEstablishments
                                join estb in Context.MOL_Establishment on userEstab.PK_EstablishmentId equals estb.PK_EstablishmentId
                                join unifiedNumber in Context.MOL_UnifiedNumber on estb.FK_UnifiedNumberId equals unifiedNumber.PK_UnifiedNumberId
                                join estAgent in Context.MOL_EstablishmentAgent on userEstab.PK_AuthorizationId.Value equals estAgent.PK_EstablishmentAgentId into inner
                                from estAgent in inner.DefaultIfEmpty()
                                where userEstab.PK_AuthorizationId != null && userEstab.AuthorizedIdNo == idNo.ToString() && userEstab.IsVerified.Value
                                && (
                                (userEstab.AuthorizedType == 1)
                                || (estAgent.FK_AgentTypeId == 1 && userEstab.AuthorizedType == 2 && estAgent.FK_UnifiedNumberId == estb.FK_UnifiedNumberId)
                                || (estAgent.FK_AgentTypeId == 1 && userEstab.AuthorizedType == 6 && estAgent.FK_UnifiedNumberId == estb.FK_UnifiedNumberId)
                                )
                                select unifiedNumber)
                    .Distinct<MOL_UnifiedNumber>().ToList<MOL_UnifiedNumber>();
            return lstUnifiedNumber;
        }
        
        public class RepEstablishment
        {
            public int LaborOffice { get; set; }
            public long SequenceNumber { get; set; }
            public string Name { get; set; }
            public int Size { get; set; }
            public bool IsMain { get; set; }
            public string CommercialRecord { get; set; }
            public string MunicipalLicense { get; set; }
            public string OtherLicense { get; set; }
            public string OwnerIdNo { get; set; }
            public string SevenHundredNo { get; set; }
            public int MainLaborOffice { get; set; }
            public long MainSequenceNumber { get; set; }
            public string MainEstablishmentName { get; set; }
        }
    }
}
