[System.Serializable]
public enum TipoEquipo
{
    Arma, Cabeza, Cuerpo, Brazos, Piernas, Pies
}

[System.Serializable]
public class Equipo
{
    public string Nombre;
    public string Descripcion;
    public TipoEquipo TipoEquipo;
    public Stats ModificadoresStats;
    public string OtrasCaracteristicas;

    public Equipo(string _Nombre, string _Descripcion, TipoEquipo _TipoEquipo, Stats _ModificadoresStats, string _OtrasCaracteristicas)
    {
        this.Nombre = _Nombre;
        this.Descripcion = _Descripcion;
        this.TipoEquipo = _TipoEquipo;
        this.ModificadoresStats = _ModificadoresStats;
        this.OtrasCaracteristicas = _OtrasCaracteristicas;
    }
}
