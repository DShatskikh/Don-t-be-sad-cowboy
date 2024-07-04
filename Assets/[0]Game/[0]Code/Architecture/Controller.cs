﻿using UnityEngine;

namespace Game
{
    public abstract class Controller
    {
        public virtual void OnSubmitDown() { }
        public virtual void OnSubmit() { }
        public virtual void OnSubmitUp() { }
        public virtual void OnCancelDown() { }
        public virtual void OnCancel() { }
        public virtual void OnCancelUp() { }
        public virtual void OnAxisRaw(Vector2 direction) { }
        public virtual void OnEnter() { }
        public virtual void OnUpdate() { }
        public virtual void OnExit() { }
    }
}