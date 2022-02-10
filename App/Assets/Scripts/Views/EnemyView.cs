using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Views
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private GameObject model;
        [SerializeField] private GameObject prefabDestroyed;
        [SerializeField] private GameObject particlesDestroyed;
        
        private void Start()
        {
            this.OnTriggerEnterAsObservable()
                .Subscribe(x =>
                    {
                        Debug.Log("Collider name" + x.name);
                        StartCoroutine(DestroyEnemy());
                    })
                .AddTo(this);
        }

        private IEnumerator DestroyEnemy()
        {
            particlesDestroyed.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            prefabDestroyed.SetActive(true);
            model.SetActive(false);
        }
    }
}
