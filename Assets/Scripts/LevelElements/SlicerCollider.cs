using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceVegetables
{
    public class SlicerCollider : MonoBehaviour
    {
        [SerializeField] InputManager inputManager;
        [SerializeField] LevelManager levelManager;
        [SerializeField] GameObject _dropletBurst;

        public bool IsSlicing = false;

        float _lastBurstZPosition = -100f;

        void Awake()
        {
            if (inputManager == null)
            {
                Debug.LogError("Input Manager is not set");
            }
            if (levelManager == null)
            {
                Debug.LogError("Level Manager is not set");
            }
            if (_dropletBurst == null)
            {
                Debug.LogError("DropletBurst is not set");
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (!IsSlicing) return;

            if (other.CompareTag("vegetablePart"))
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if ((rb != null) && (rb.isKinematic == true))
                {
                    rb.isKinematic = false;
                    rb.AddForce(Vector3.right * 0.6f * (Random.Range(0, 2) * 2 - 1), ForceMode.Impulse);
                    levelManager.AddScore();
                    if (transform.position.z - _lastBurstZPosition > 0.3f)
                    {
                        GameObject burst = Instantiate(_dropletBurst, new Vector3(0, 0.68f, transform.position.z), Quaternion.identity);
                        if (rb.gameObject.name.Contains("Carrot"))
                        {
                            var main = burst.GetComponent<ParticleSystem>().main;
                            main.startColor = new Color(236f/255, 140f/255, 69f/255);
                        }
                        Destroy(burst, 7f);
                        _lastBurstZPosition = transform.position.z;
                    }
                }
                return;
            }
            if (other.CompareTag("wood"))
            {
                inputManager.HitWood();
                return;
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("vegetablePart"))
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if ((rb != null) && (rb.isKinematic == true))
                {
                    levelManager.AddMissed();
                }
            }
        }
    }
}
