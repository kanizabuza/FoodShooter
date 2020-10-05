using UnityEngine;
using UniRx;
using System;

namespace Players
{
    public class PlayerInput : MonoBehaviour
    {
        private readonly Subject<Unit> _fullAutoStream = new Subject<Unit>();
        public IObservable<Unit> FullAutoStream => _fullAutoStream;
        private readonly Subject<Unit> _semiAutoStream = new Subject<Unit>();
        public IObservable<Unit> SemiAutoStream => _semiAutoStream;
        private readonly Subject<Unit> _reloadStream = new Subject<Unit>();
        public Subject<Unit> ReloadStream => _reloadStream;

        void Start()
        {
            InputAsObservable.GetMouseButton(0)
                .Subscribe(_fullAutoStream.OnNext).AddTo(this);
            InputAsObservable.GetMouseButtonDown(0)
                .Subscribe(_semiAutoStream.OnNext).AddTo(this);
            InputAsObservable.GetKeyDown(KeyCode.R)
                .Subscribe(_reloadStream.OnNext).AddTo(this);
        }
    }
}
