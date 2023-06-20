using UnityEngine;

namespace WeaponBoxes
{
    public class SpawnerWeaponBox : WeaponBoxesEntities
    {
        public void SpawnBox(int numberWave)
        {
            var boxes = GetBoxes();
            boxes[numberWave - 1].SetActive(true);
        }
    }
}
