using UnityEngine;

namespace MoonlanderCode.Particle
{
    public class Particle_DestroyAfterPlay : MonoBehaviour
    {
        private ParticleSystem _particleSys;

        private void Start(){
            _particleSys = gameObject.GetComponent<ParticleSystem>();
        }

        private void Update(){
            if(!_particleSys.IsAlive()) Destroy(gameObject);
        }
    }
}
