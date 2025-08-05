namespace GSMARK_V2.Models
{
    public class TMPROD
    {
        public string CO_PROD {  get; set; }
        public string? CO_ITEM_REFE {  get; set; }
        public string? DE_ITEM_ORIG {  get; set; }
        public string? DE_PROD { get; set; }
        public decimal IM_PREC_UNIT { get; set; }
        public string CO_USUA_CREA {  get; set; }
        public DateTime? FE_USUA_CREA {  set; get; }
        public string CO_USUA_MODI {  get; set; }
        public DateTime? FE_USUA_MODI {  set; get; }
        public string? CO_BARRA { get; set; }

        public string? DE_ITEM {  get; set; } //Atributo de la tabla TMITEM

    }
}
