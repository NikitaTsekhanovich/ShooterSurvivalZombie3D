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
        private Camera _camera;
        private float _shotInterval;
        public ItemType ItemType { get; private set; }

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

        private void Start()
        {
            _camera = Camera.main;
            ItemType = gameObject.GetComponent<Item>().item.ItemType;
        }

        public void ShootAutomaticWeapon()
        {
            if (ItemType == ItemType.AutomaticWeapon)
            {
                _shotInterval += Time.deltaTime;

                if (_shotInterval >= shotDelay)
                {
                    if (NumberRoundsMagazine > 0)
                    {
                        shotSound.Play();
                        NumberRoundsMagazine -= 1;
                        SpawnBullet();
                    }
                    _shotInterval = 0;
                }
            }
        }
        
        public void ShootNotAutomaticWeapon()
        {
            if (ItemType == ItemType.NotAutomaticWeapon)
            {
                if (NumberRoundsMagazine > 0)
                {
                    shotSound.Play();
                    NumberRoundsMagazine -= 1;
                    SpawnBullet();
                }
            }
        }

        public bool Reload()
        {
            if (ExtraAmmo > 0 && NumberRoundsMagazine != sizeMagazine)
            {
                reloadSound.Play();
                
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
                return true;
            }

            return false;
        }

        private void SpawnBullet()
        {
            var ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

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
