namespace MOL.EFDAL
{
    using System;

    public class GetEstablishment_Bills_Result
    {
        public int? Program_Establishment_Id { get; set; }
        public int? Program_Sequence { get; set; }
        public DateTime? Issued_On { get; set; }
        public decimal? Bill_Number { get; set; }
        public int? Requested_Saudi_Units { get; set; }
        public decimal? Bill_Amount { get; set; }
        public int? Bill_Status_Id { get; set; }
        public string PayStatus { get; set; }
    }
}
