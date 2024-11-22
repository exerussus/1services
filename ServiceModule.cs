using System;
using Exerussus._1Extensions.SignalSystem;
using Exerussus._1Extensions.SmallFeatures;

namespace Exerussus.Servecies
{
    public abstract class ServiceModule
    {
        private Signal _signal;
        private GameShare _gameShare;

        public Signal Signal => _signal;
        public GameShare GameShare => _gameShare;

        public virtual void PreInitialize(GameShare gameShare, Signal signal, Service service)
        {
            _signal = signal;
            _gameShare = gameShare;
            _gameShare.AddSharedObject(this);
            _gameShare.AddSharedObject(service.GetType(), GetType(), this);
            OnPreInitialize();
        }
        
        public virtual void SetSharedObject(GameShare gameShare) { }

        public virtual void OnDestroy() { }

        public void SubscribeSignal<T>(Action<T> action) where T : struct
        {
            _signal.Subscribe(action);
        }

        public void UnsubscribeSignal<T>(Action<T> action) where T : struct
        {
            _signal?.Unsubscribe(action);
        }

        public virtual void OnPreInitialize() { }
        public virtual void Initialize() {}
    }
    
    public abstract class ServiceModule<T1> : ServiceModule where T1 : struct
    {
        private Action<T1> _signalSubscribeT1;

        public override void PreInitialize(GameShare gameShare, Signal signal, Service service)
        {
            base.PreInitialize(gameShare, signal, service); 
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
    
    public abstract class ServiceModule<T1, T2> : ServiceModule 
        where T1 : struct
        where T2 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;

        public override void PreInitialize(GameShare gameShare, Signal signal, Service service)
        {
            base.PreInitialize(gameShare, signal, service); 
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
    
    public abstract class ServiceModule<T1, T2, T3> : ServiceModule 
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;
        private Action<T3> _signalSubscribeT3;

        public override void PreInitialize(GameShare gameShare, Signal signal, Service service)
        {
            base.PreInitialize(gameShare, signal, service); 
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
    
    public abstract class ServiceModule<T1, T2, T3, T4> : ServiceModule 
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;
        private Action<T3> _signalSubscribeT3;
        private Action<T4> _signalSubscribeT4;

        public override void PreInitialize(GameShare gameShare, Signal signal, Service service)
        {
            base.PreInitialize(gameShare, signal, service); 
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
    
    public abstract class ServiceModule<T1, T2, T3, T4, T5> : ServiceModule 
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

        public override void PreInitialize(GameShare gameShare, Signal signal, Service service)
        {
            base.PreInitialize(gameShare, signal, service); 
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
    
    public abstract class ServiceModule<T1, T2, T3, T4, T5, T6> : ServiceModule 
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

        public override void PreInitialize(GameShare gameShare, Signal signal, Service service)
        {
            base.PreInitialize(gameShare, signal, service); 
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
    
    public abstract class ServiceModule<T1, T2, T3, T4, T5, T6, T7> : ServiceModule 
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;
        private Action<T3> _signalSubscribeT3;
        private Action<T4> _signalSubscribeT4;
        private Action<T5> _signalSubscribeT5;
        private Action<T6> _signalSubscribeT6;
        private Action<T7> _signalSubscribeT7;

        public override void PreInitialize(GameShare gameShare, Signal signal, Service service)
        {
            base.PreInitialize(gameShare, signal, service); 
            _signalSubscribeT1 = OnSignal;
            _signalSubscribeT2 = OnSignal;
            _signalSubscribeT3 = OnSignal;
            _signalSubscribeT4 = OnSignal;
            _signalSubscribeT5 = OnSignal;
            _signalSubscribeT6 = OnSignal;
            _signalSubscribeT7 = OnSignal;
            
            SubscribeSignal(_signalSubscribeT1);
            SubscribeSignal(_signalSubscribeT2);
            SubscribeSignal(_signalSubscribeT3);
            SubscribeSignal(_signalSubscribeT4);
            SubscribeSignal(_signalSubscribeT5);
            SubscribeSignal(_signalSubscribeT6);
            SubscribeSignal(_signalSubscribeT7);
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
            UnsubscribeSignal(_signalSubscribeT7);
        }
        
        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);
        protected abstract void OnSignal(T5 data);
        protected abstract void OnSignal(T6 data);
        protected abstract void OnSignal(T7 data);
    }
}