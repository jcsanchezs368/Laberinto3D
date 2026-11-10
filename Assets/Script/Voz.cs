using UnityEngine;
using TMPro;
public class Voz : MonoBehaviour, ISpeechToTextListener
{
    public TMP_Text textoVoz;
    void Start()
    {
        SpeechToText.Initialize("es-ES");
    }

    // Este método lo llamamos desde un botón
    public void Escuchar()
    {
        SpeechToText.RequestPermissionAsync(permiso =>
        {
            if (permiso == SpeechToText.Permission.Granted)
                SpeechToText.Start(this);
        });
    }

    public void OnResultReceived(string texto, int? error)
    {
        if (string.IsNullOrEmpty(texto)) return;

        textoVoz.text = "Has dicho: " + texto;

        texto = texto.ToLower();

        if (texto.Contains("salta"))
            Debug.Log("SALTAR");

        if (texto.Contains("dispara"))
            Debug.Log("DISPARAR");
    }

    public void OnReadyForSpeech() { }
    public void OnBeginningOfSpeech() { }
    public void OnVoiceLevelChanged(float nivel) { }
    public void OnPartialResultReceived(string texto)
    {
        textoVoz.text = "Escuchando: " + texto;
    }
}