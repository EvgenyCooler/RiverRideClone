using System;
using UniRx;
using UnityEngine;

namespace Views { 
  public class PlayerView : MonoBehaviour
  { 

    public event Action OnFirePressed;
    public event Action<Vector3> OnMovePressed;

    void Start () 
    {
     
      Observable.EveryUpdate()
        .Where(_ => Input.GetMouseButtonUp(0))
        .Subscribe (x =>
        { 
          Vector3 mousePos = Input.mousePosition;
          Debug.Log("A." + mousePos);

          mousePos = Camera.main.ScreenToWorldPoint(mousePos);
          Debug.Log("B." + mousePos);

          OnMovePressed?.Invoke(mousePos);
        })
        .AddTo (this); 
      
      
      Observable.EveryUpdate()
        .Where(_ => Input.GetKeyUp(KeyCode.Space)) 
        .Subscribe (x =>
        {
          OnFirePressed?.Invoke();
        })
        .AddTo (this); 
      }
    
    // private void OnKeyDown (string keyCode) {
    //   switch (keyCode) {
    //     case "w":
    //       Debug.Log ("keyCode: W");
    //       break;
    //     default:
    //       Debug.Log ("keyCode: "+keyCode);
    //       break;
    //   }
    // }
  }
}
