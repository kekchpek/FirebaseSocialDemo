using System;
using System.Collections.Generic;
using SocialDemo.Code.Auxiliary.UnityExecutor;

namespace SocialDemo.Code.Auxiliary.Promises
{
    public class ControllablePromise : BaseControllablePromise, IControllablePromise
    {
        private readonly IUnityExecutor _unityExecutor;

        private readonly IList<Action> _successCallbacks = new List<Action>();
        
        public ControllablePromise(IUnityExecutor unityExecutor) : base(unityExecutor)
        {
            _unityExecutor = unityExecutor;
        }

        public void Success()
        {
            if (IsCompleted)
                throw new InvalidOperationException("Promise is already completed!");
            foreach (var callback in _successCallbacks)
            {
                _unityExecutor.ExecuteOnFixedUpdate(() => callback?.Invoke());
            }
            DoFinally();
        }

        public IPromise OnSuccess(Action callback)
        {
            if (IsCompleted)
            {
                callback?.Invoke();
            }
            else
            {
                _successCallbacks.Add(callback);
            }

            return this;
        }
    }
    
    public class ControllablePromise<T> : BaseControllablePromise, IControllablePromise<T>
    {
        private readonly IUnityExecutor _unityExecutor;
        
        private readonly IList<Action<T>> _successCallbacks = new List<Action<T>>();

        private T _result;
        private bool _resultSet;
        
        public ControllablePromise(IUnityExecutor unityExecutor) : base(unityExecutor)
        {
            _unityExecutor = unityExecutor;
        } 

        public void Success(T result)
        {
            if (IsCompleted)
                throw new InvalidOperationException("Promise is already completed!");
            _result = result;
            _resultSet = true;
            foreach (var callback in _successCallbacks)
            {
                _unityExecutor.ExecuteOnFixedUpdate(() => callback?.Invoke(_result));
            }
            DoFinally();
        }

        public IPromise<T> OnSuccess(Action<T> callback)
        {
            if (_resultSet)
            {
                callback?.Invoke(_result);
            }
            else
            {
                _successCallbacks.Add(callback);
            }

            return this;
        }
    }
}