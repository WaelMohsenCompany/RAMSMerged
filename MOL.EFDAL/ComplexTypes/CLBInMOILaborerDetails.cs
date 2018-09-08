namespace MOL.EFDAL.ComplexTypes
{
    public class CLBInMOILaborerDetails
    {
        public string LaborerName { get { return string.Format("{0} {1} {2} {3}", FirstName, SecondName, ThirdName, FourthName); } }
        public string LaborerIDNumber { get; set; }
        public string LaborerJob { get; set; }
        public string LaborerStatus { get; set; }
        public string EstablishmentName { get; set; }
        public string EstablishmentOwnerIDNumber { get; set; }
        public string Establishment700Number { get; set; }
        public bool IsIndividualEstablishment { get; set; }
        public int EstablishmentLaborOffice { get; set; }
        public long EstablishmentSequenceNumber { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
    }
}
