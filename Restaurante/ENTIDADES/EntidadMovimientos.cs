namespace ENTIDADES
{
    public class EntidadMovimientos
    {
        public EntidadMovimientos()
        {
        }

        public EntidadMovimientos(int iDMovimientos, string ingreso, string fechaMovimiento, int fKID)
        {
            _IDMovimientos = iDMovimientos;
            _Ingreso = ingreso;
            _FechaMovimiento = fechaMovimiento;
            _FKID = fKID;
        }

        public int _IDMovimientos { get; set; }
        public string _Ingreso { get; set; }
        public string _FechaMovimiento { get; set; }
        public int _FKID { get; set; }
    }
}
