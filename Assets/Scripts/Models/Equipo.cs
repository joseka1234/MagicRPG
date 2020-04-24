[System.Serializable]
public enum TipoEquipo
{
    Arma, Cabeza, Cuerpo, Brazos, Piernas, Pies
}

[System.Serializable]
public class Equipo : Objeto
{
    public TipoEquipo TipoEquipo;
    public string Caracteristicas;

    public Equipo(string _Nombre, string _Descripcion, Estadisticas _Incrementos,
                    TipoEquipo _TipoEquipo, string _Caracteristicas)
                    :base (_Nombre, _Descripcion, _Incrementos)
    {
        this.TipoEquipo = _TipoEquipo;
        this.Caracteristicas = _Caracteristicas;
    }
}
