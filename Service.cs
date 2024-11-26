using System;
using System.Collections.Generic;
using Exerussus._1EasyEcs.Scripts.Core;
using Exerussus._1Extensions.SignalSystem;
using Exerussus._1Extensions.SmallFeatures;
using Exerussus.Servecies.Interfaces;

namespace Exerussus.Servecies
{
    public abstract class Service
    {
        private GameShare _gameShare;
        private Signal _signal;
        private ServiceModule[] _modules;
        private IModuleUpdate[] _updateModules;
        private IModuleFixedUpdate[] _fixedUpdateModules;

        public GameShare GameShare => _gameShare;
        public Signal Signal => _signal;
        public bool HasFixedUpdateModules { get; private set; }
        public bool HasUpdateModules { get; private set; }

        public virtual void CreateInstances(GameShare gameShare, Signal signal)
        {
            _gameShare = gameShare;
            _signal = signal;
            _gameShare.AddSharedObject(this);
            _modules = GetModules();

            if (_modules.Length == 0)
            {
                foreach (var serviceModule in _modules) serviceModule.CreateInstances(gameShare, signal, this);
            
                var updateList = new List<IModuleUpdate>();
                foreach (var serviceModule in _modules)
                {
                    if (serviceModule is IModuleUpdate updateModule)
                    {
                        HasUpdateModules = true;
                        updateList.Add(updateModule);
                    }
                }

                _updateModules = updateList.ToArray();

                var fixedUpdateList = new List<IModuleFixedUpdate>();
                foreach (var serviceModule in _modules)
                {
                    if (serviceModule is IModuleFixedUpdate updateModule)
                    {
                        HasFixedUpdateModules = true;
                        fixedUpdateList.Add(updateModule);
                    }
                }

                _fixedUpdateModules = fixedUpdateList.ToArray();
            }

            SetSharedObject();
        }
        
        public virtual void PreInitialize()
        {
            foreach (var serviceModule in _modules) serviceModule.PreInitialize();
        }

        public void SubscribeSignal<T>(Action<T> action) where T : struct
        {
            _signal.Subscribe(action);
        }

        public void UnsubscribeSignal<T>(Action<T> action) where T : struct
        {
            _signal?.Unsubscribe(action);
        }

        public void SetSharedObject()
        {
            OnSetSharedObject();
            foreach (var serviceModule in _modules) serviceModule.SetSharedObject();
        }

        public void Inject()
        {
            _gameShare.InjectSharedObjects(this);
            foreach (var serviceModule in _modules) _gameShare.InjectSharedObjects(serviceModule);
        }
        
        public virtual void OnSetSharedObject() { }

        protected abstract ServiceModule[] GetModules();

        public void Update()
        {
            foreach (var module in _updateModules) module.Update();
            OnUpdate();
        }

        public void FixedUpdate()
        {
            foreach (var module in _fixedUpdateModules) module.FixedUpdate();
            OnFixedUpdate();
        }

        public void Initialize()
        {
            OnInitialize();
            foreach (var serviceModule in _modules) serviceModule.Initialize();
        }

        public void PostInitServices()
        {
            OnPostInitServices();
        }
        
        public virtual void OnInitialize() { }
        public virtual void OnPostInitServices() { }
        public virtual void OnDestroy() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
    }
    
    public abstract class Service<T1> : Service where T1 : struct
    {
        private Action<T1> _signalSubscribeT1;

        public override void CreateInstances(GameShare gameShare, Signal signal)
        {
            base.CreateInstances(gameShare, signal); 
            _signalSubscribeT1 = OnSignal;
            
            SubscribeSignal(_signalSubscribeT1);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            UnsubscribeSignal(_signalSubscribeT1);
        }
        
        protected abstract void OnSignal(T1 data);
    }
    
    public abstract class Service<T1, T2> : Service 
        where T1 : struct
        where T2 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;

        public override void CreateInstances(GameShare gameShare, Signal signal)
        {
            base.CreateInstances(gameShare, signal); 
            _signalSubscribeT1 = OnSignal;
            _signalSubscribeT2 = OnSignal;
            
            SubscribeSignal(_signalSubscribeT1);
            SubscribeSignal(_signalSubscribeT2);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            UnsubscribeSignal(_signalSubscribeT1);
            UnsubscribeSignal(_signalSubscribeT2);
        }
        
        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
    }
    
    public abstract class Service<T1, T2, T3> : Service 
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;
        private Action<T3> _signalSubscribeT3;

        public override void CreateInstances(GameShare gameShare, Signal signal)
        {
            base.CreateInstances(gameShare, signal); 
            _signalSubscribeT1 = OnSignal;
            _signalSubscribeT2 = OnSignal;
            _signalSubscribeT3 = OnSignal;
            
            SubscribeSignal(_signalSubscribeT1);
            SubscribeSignal(_signalSubscribeT2);
            SubscribeSignal(_signalSubscribeT3);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            UnsubscribeSignal(_signalSubscribeT1);
            UnsubscribeSignal(_signalSubscribeT2);
            UnsubscribeSignal(_signalSubscribeT3);
        }
        
        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
    }
    
    public abstract class Service<T1, T2, T3, T4> : Service 
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;
        private Action<T3> _signalSubscribeT3;
        private Action<T4> _signalSubscribeT4;

        public override void CreateInstances(GameShare gameShare, Signal signal)
        {
            base.CreateInstances(gameShare, signal); 
            _signalSubscribeT1 = OnSignal;
            _signalSubscribeT2 = OnSignal;
            _signalSubscribeT3 = OnSignal;
            _signalSubscribeT4 = OnSignal;
            
            SubscribeSignal(_signalSubscribeT1);
            SubscribeSignal(_signalSubscribeT2);
            SubscribeSignal(_signalSubscribeT3);
            SubscribeSignal(_signalSubscribeT4);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            UnsubscribeSignal(_signalSubscribeT1);
            UnsubscribeSignal(_signalSubscribeT2);
            UnsubscribeSignal(_signalSubscribeT3);
            UnsubscribeSignal(_signalSubscribeT4);
        }
        
        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);
    }
    
    public abstract class Service<T1, T2, T3, T4, T5> : Service 
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;
        private Action<T3> _signalSubscribeT3;
        private Action<T4> _signalSubscribeT4;
        private Action<T5> _signalSubscribeT5;

        public override void CreateInstances(GameShare gameShare, Signal signal)
        {
            base.CreateInstances(gameShare, signal); 
            _signalSubscribeT1 = OnSignal;
            _signalSubscribeT2 = OnSignal;
            _signalSubscribeT3 = OnSignal;
            _signalSubscribeT4 = OnSignal;
            _signalSubscribeT5 = OnSignal;
            
            SubscribeSignal(_signalSubscribeT1);
            SubscribeSignal(_signalSubscribeT2);
            SubscribeSignal(_signalSubscribeT3);
            SubscribeSignal(_signalSubscribeT4);
            SubscribeSignal(_signalSubscribeT5);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            UnsubscribeSignal(_signalSubscribeT1);
            UnsubscribeSignal(_signalSubscribeT2);
            UnsubscribeSignal(_signalSubscribeT3);
            UnsubscribeSignal(_signalSubscribeT4);
            UnsubscribeSignal(_signalSubscribeT5);
        }
        
        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);
        protected abstract void OnSignal(T5 data);
    }
    
    public abstract class Service<T1, T2, T3, T4, T5, T6> : Service 
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;
        private Action<T3> _signalSubscribeT3;
        private Action<T4> _signalSubscribeT4;
        private Action<T5> _signalSubscribeT5;
        private Action<T6> _signalSubscribeT6;

        public override void CreateInstances(GameShare gameShare, Signal signal)
        {
            base.CreateInstances(gameShare, signal); 
            _signalSubscribeT1 = OnSignal;
            _signalSubscribeT2 = OnSignal;
            _signalSubscribeT3 = OnSignal;
            _signalSubscribeT4 = OnSignal;
            _signalSubscribeT5 = OnSignal;
            _signalSubscribeT6 = OnSignal;
            
            SubscribeSignal(_signalSubscribeT1);
            SubscribeSignal(_signalSubscribeT2);
            SubscribeSignal(_signalSubscribeT3);
            SubscribeSignal(_signalSubscribeT4);
            SubscribeSignal(_signalSubscribeT5);
            SubscribeSignal(_signalSubscribeT6);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            UnsubscribeSignal(_signalSubscribeT1);
            UnsubscribeSignal(_signalSubscribeT2);
            UnsubscribeSignal(_signalSubscribeT3);
            UnsubscribeSignal(_signalSubscribeT4);
            UnsubscribeSignal(_signalSubscribeT5);
            UnsubscribeSignal(_signalSubscribeT6);
        }
        
        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);
        protected abstract void OnSignal(T5 data);
        protected abstract void OnSignal(T6 data);
    }
}