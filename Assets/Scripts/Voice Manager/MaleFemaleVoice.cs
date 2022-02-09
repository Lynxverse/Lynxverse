using UnityEngine;

public class MaleFemaleVoice : MonoBehaviour
{
    [SerializeField] VoiceEntity voiceEntity;

    public void FemaleVoice() => voiceEntity.voiceChoosen = VoiceEntity.VOICE_CHOOSEN.FEMALE;
    public void MaleVoice() => voiceEntity.voiceChoosen = VoiceEntity.VOICE_CHOOSEN.MALE;
}
