using System.Data;
using System.Data.SqlClient;

namespace MOL.EFDAL
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class EFUnitTest
    {
        private MOLEFEntities _context;

        [TestInitialize]
        public void Setup()
        {
            _context = new MOLEFEntities();
        }

        [TestMethod]
        public void GetEstablishmentRunawayRequests()
        {
            Assert.AreEqual(86, _context.SP_CUST_GetEstablishmentRunawayRequests(1751112, new DateTime(2013, 9, 1)));
        }

        [TestMethod]
        public void GetLaborerLatestStatusByIdAndDate()
        {
            Assert.AreEqual(1, _context.GetLaborerLatestStatusByIdAndDate(new DateTime(2016, 9, 1), "2303934430").Count);
        }

        [TestMethod]
        public void SP_CUST_MOL_Sec_Privilege_GetAuthorizedUserServices()
        {
            Assert.AreEqual(1, _context.SP_CUST_MOL_Sec_Privilege_GetAuthorizedUserServices(userId: 12619959, establishmentId: 1225760, serviceId: null, privilegeId: null, authorizationLevel: null).Count);
        }

        [TestMethod]
        public void GetEstablishment_Bills()
        {
            Assert.AreEqual(1, _context.GetEstablishment_Bills(establishmentId: 2598104).Count);
        }

        [TestMethod]
        public void SP_CUST_GetPendingNICVisasCountByEstablishmentID()
        {
            Assert.AreEqual(2, _context.SP_CUST_GetPendingNICVisasCountByEstablishmentID(establishmentId: 4233));
        }


        [TestMethod]
        public void SP_MOL_RunAwayCancelRequest_Insert()
        {
            SqlParameter result = new SqlParameter
            {
                ParameterName = "@Result",
                Direction = ParameterDirection.Output,
                DbType = DbType.Int32
            };

            Assert.AreEqual(-1, _context.SP_MOL_RunAwayCancelRequest_Insert(851828, "2342625338", "1006809956", 2219033, result));
            Assert.AreEqual(0, result.Value);
        }


        [TestMethod]
        public void usp_MOL_IstikdamRequestRejectionReason_Insert()
        {
            SqlParameter result = new SqlParameter
            {
                ParameterName = "@IstikdamRequestRejectionReasonId",
                Direction = ParameterDirection.Output,
                DbType = DbType.Int32
            };

            Assert.AreEqual(1, _context.usp_MOL_IstikdamRequestRejectionReason_Insert(1, 1, result));
            Assert.AreEqual(5, result.Value);
        }
    }
}
