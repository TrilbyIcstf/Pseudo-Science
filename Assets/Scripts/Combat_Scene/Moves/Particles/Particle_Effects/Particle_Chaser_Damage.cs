using UnityEngine;

public class Particle_Chaser_Damage : Particle_Chaser
{
    private int target;
    private Target targetType;
    [SerializeField] private Color damageColor;

    public void ParticleInitialize(Vector2 goal, int target, Target targetType, float startSpeed, float startAccel, Vector2 startDirection, float startTurnSpeed, float targetDist, BarChangeDetails barDetails, float lifeSpan, Particle_Controller_Dad papa)
    {
        papa.RegisterTempDamage(gameObject, barDetails, target, targetType);

        this.target = target;
        this.targetType = targetType;
        base.ParticleInitialize(goal, startSpeed, startAccel, startDirection, startTurnSpeed, targetDist, lifeSpan, papa);
    }

    protected override void ParticleDestroy()
    {
        float angle = (Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg) - 90;
        if (angle < 0)
        {
            angle += 360;
        }
        father.SendAnimation(new AnimDetails(CombatAnimation.ColorFlash, targetType, target, null, damageColor));
        
        father.ApplyTempDamage(gameObject, target, targetType);
        if (onDestroyParticleSystem != null)
        {
            GameObject particleSystem = Instantiate(onDestroyParticleSystem, transform.position, Quaternion.identity);
        }

        father.RemoveParticle(gameObject);
        Destroy(gameObject);
    }
}
