using UnityEngine;

namespace SocialDemo.Code.Mvp.View
{
    public abstract class View : MonoBehaviour, IView
    {
        protected virtual void OnClose()
        {
            
        }
        
        public void Close()
        {
            OnClose();
            Destroy(gameObject);
        }
    }
}