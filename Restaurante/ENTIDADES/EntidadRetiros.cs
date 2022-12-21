namespace ENTIDADES
{
    public class EntidadRetiros
    {
        public EntidadRetiros()
        {
        }

        public EntidadRetiros(int iDRetiros, string retiros, string fechaMovimiento, int fKIDProd)
        {
            _IDRetiros = iDRetiros;
            _Retiros = retiros;
            _FechaMovimiento = fechaMovimiento;
            _FKIDProd = fKIDProd;
        }

        public int _IDRetiros { get; set; }
        public string _Retiros { get; set; }
        public string _FechaMovimiento { get; set; }
        public int _FKIDProd { get; set; }
    }
}
