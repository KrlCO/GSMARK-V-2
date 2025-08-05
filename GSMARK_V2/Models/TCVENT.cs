namespace GSMARK_V2.Models
{
    public class TCVENT
    {
        public string CO_SEDE { get; set; }
        public int CO_LINE_NEGO { get; set; }
        public string NU_SECU { get; set; }
        public string CO_VEND { get; set; }
        public DateTime? FE_VENT { get; set; }
        public int CA_TOTA_VENT { get; set; }
        public decimal IM_TOTA_VENT { get; set; }
        public string? TI_LIQI_REFE { get; set; }
        public string? NU_LIQI_REFE { get; set; }
        public string? CO_USUA_CREA { get; set; }
        public DateTime FE_USUA_CREA { get; set; }
        public string? CO_USUA_MODI { get; set; }
        public DateTime FE_USUA_MODI { get; set; }
        public byte? NU_TURN { get; set; }

    }
}
