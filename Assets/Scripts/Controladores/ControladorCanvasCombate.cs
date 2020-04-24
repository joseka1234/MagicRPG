using UnityEngine;
using TMPro;

public class ControladorCanvasCombate : ControladorCanvas
{
    public GameObject Botones;
    public GameObject Mensajes;

    void Start()
    {
        this.Mensajes.SetActive(false);
        this.Botones.SetActive(false);
    }

    public void ToggleBotones()
    {
        this.Botones.SetActive(!this.Botones.activeSelf);
    }

    public void ToggleMensajes()
    {
        this.Mensajes.SetActive(!this.Mensajes.activeSelf);
    }

    public void SetMensaje(string _Mensaje)
    {
        this.Mensajes.GetComponentInChildren<TextMeshProUGUI>().SetText(_Mensaje);
    }

}
