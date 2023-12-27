using UnityEngine;

public class Rifle : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    [SerializeField] int bulletDamage = 10;
    [SerializeField] LayerMask mask;
    [SerializeField] Sound sound = new();

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SoundManager.instance.Sound(sound.audioClips[0]);

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                hit.collider.GetComponent<Unit>().OnHit(bulletDamage);
            }
        }
    }
}