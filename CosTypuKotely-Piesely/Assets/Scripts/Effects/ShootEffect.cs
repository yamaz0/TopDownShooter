using UnityEngine;

[System.Serializable]
public class ShootEffect : Effect
{
    [SerializeField]
    private ParticleSystem ps;
    [SerializeField]
    private Animator anim;

    public override void EndEffect()
    {
        ps.gameObject.SetActive(false);
        anim.gameObject.SetActive(false);
    }

    public override void StartEffect()
    {
        ps.gameObject.SetActive(true);
        anim.gameObject.SetActive(true);
        ps.Play();
        anim.Play(0);
    }
}
