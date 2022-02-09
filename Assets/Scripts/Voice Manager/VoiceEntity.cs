using UnityEngine;

[CreateAssetMenu()]
public class VoiceEntity : ScriptableObject
{
    public enum VOICE_CHOOSEN { MALE, FEMALE }
    public VOICE_CHOOSEN voiceChoosen = VOICE_CHOOSEN.MALE;
}
