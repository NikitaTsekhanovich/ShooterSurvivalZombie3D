using UnityEngine;
using Random = UnityEngine.Random;

namespace Player.InventoryEntities.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private int extraAmmo;
        [SerializeField] private int numberRoundsMagazine;
        [SerializeField] private int sizeMagazine;
        [SerializeField] private float shootForce;
        [SerializeField] private float spread;
        [SerializeField] private GameObject bullet;
        [SerializeField] private float damage;
        [SerializeField] private Transform spawnBullet;
        [SerializeField] private float shotDelay;
        [SerializeField] private AudioSource shotSound;
        [SerializeField] private AudioSource reloadSound;

        public int ExtraAmmo
        {
            get => extraAmmo; 
            set => extraAmmo = value;
        }

        public int NumberRoundsMagazine
        {
            get => numberRoundsMagazine;
            private set => numberRoundsMagazine = value;
        }

        public float Damage => damage;

        public float ShotDelay => shotDelay;

        public void ShootWeapon(Camera mainCamera)
        {
            if (NumberRoundsMagazine > 0)
            {
                shotSound.Play();
                NumberRoundsMagazine -= 1;
                SpawnBullet(mainCamera);
            }
        }

        public bool IsReload()
        {
            if (ExtraAmmo > 0 && NumberRoundsMagazine != sizeMagazine)
            {
                reloadSound.Play();
                Reload();
                return true;
            }
            return false;
        }

        private void Reload()
        {
            var ammoMagazine = sizeMagazine - NumberRoundsMagazine;
            if (ExtraAmmo - ammoMagazine > 0)
            {
                ExtraAmmo -= ammoMagazine;
                NumberRoundsMagazine += ammoMagazine;
            }
            else
            {
                NumberRoundsMagazine += ExtraAmmo;
                ExtraAmmo = 0;
            }
        }

        private void SpawnBullet(Camera mainCamera)
        {
            var ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            var targetPoint = ray.GetPoint(75);

            var spawnBulletPosition = spawnBullet.position;
            var dirWithoutSpred = targetPoint - spawnBulletPosition;

            var x = Random.Range(-spread, spread);
            var y = Random.Range(-spread, spread);

            var dirWithSpread = dirWithoutSpred + new Vector3(x, y, 0);

            var currentBullet = Instantiate(
                bullet,
                spawnBulletPosition,
                Quaternion.identity
                );

            currentBullet.transform.forward = dirWithoutSpred.normalized;

            currentBullet.GetComponent<Rigidbody>()
                .AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
        }
    }
}
