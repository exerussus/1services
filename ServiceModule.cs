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

        public virtual void CreateInstances(ServiceCollector serviceCollector)
        {
            _signal = serviceCollector.Signal;
            _gameShare = serviceCollector.GameShare;
            _gameShare.AddSharedObject(this);
        }
        
        public virtual void SetSharedObject() { }
        public virtual void OnProtectedDestroy() { }
        public virtual void OnDestroy() { }

        public void SubscribeSignal<T>(Action<T> action) where T : struct
        {
            _signal.Subscribe(action);
        }

        public void UnsubscribeSignal<T>(Action<T> action) where T : struct
        {
            _signal?.Unsubscribe(action);
        }

        public virtual void PreInitialize() { }
        public virtual void Initialize() {}
        public virtual void PostInitialize() {}
    }
    
    public abstract class ServiceModule<T1> : ServiceModule where T1 : struct
    {
        private Action<T1> _signalSubscribeT1;

        public override void CreateInstances(ServiceCollector serviceCollector)
        {
            base.CreateInstances(serviceCollector); 
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

        public override void CreateInstances(ServiceCollector serviceCollector)
        {
            base.CreateInstances(serviceCollector); 
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

        public override void CreateInstances(ServiceCollector serviceCollector)
        {
            base.CreateInstances(serviceCollector); 
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

        public override void CreateInstances(ServiceCollector serviceCollector)
        {
            base.CreateInstances(serviceCollector); 
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

        public override void CreateInstances(ServiceCollector serviceCollector)
        {
            base.CreateInstances(serviceCollector); 
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

        public override void CreateInstances(ServiceCollector serviceCollector)
        {
            base.CreateInstances(serviceCollector); 
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

        public override void CreateInstances(ServiceCollector serviceCollector)
        {
            base.CreateInstances(serviceCollector); 
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
    
    public abstract class ServiceModule<T1, T2, T3, T4, T5, T6, T7, T8> : ServiceModule 
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
        where T8 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;
        private Action<T3> _signalSubscribeT3;
        private Action<T4> _signalSubscribeT4;
        private Action<T5> _signalSubscribeT5;
        private Action<T6> _signalSubscribeT6;
        private Action<T7> _signalSubscribeT7;
        private Action<T8> _signalSubscribeT8;

        public override void CreateInstances(ServiceCollector serviceCollector)
        {
            base.CreateInstances(serviceCollector); 
            _signalSubscribeT1 = OnSignal;
            _signalSubscribeT2 = OnSignal;
            _signalSubscribeT3 = OnSignal;
            _signalSubscribeT4 = OnSignal;
            _signalSubscribeT5 = OnSignal;
            _signalSubscribeT6 = OnSignal;
            _signalSubscribeT7 = OnSignal;
            _signalSubscribeT8 = OnSignal;
            
            SubscribeSignal(_signalSubscribeT1);
            SubscribeSignal(_signalSubscribeT2);
            SubscribeSignal(_signalSubscribeT3);
            SubscribeSignal(_signalSubscribeT4);
            SubscribeSignal(_signalSubscribeT5);
            SubscribeSignal(_signalSubscribeT6);
            SubscribeSignal(_signalSubscribeT7);
            SubscribeSignal(_signalSubscribeT8);
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
            UnsubscribeSignal(_signalSubscribeT8);
        }
        
        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);
        protected abstract void OnSignal(T5 data);
        protected abstract void OnSignal(T6 data);
        protected abstract void OnSignal(T7 data);
        protected abstract void OnSignal(T8 data);
    }
    
    public abstract class ServiceModule<T1, T2, T3, T4, T5, T6, T7, T8, T9> : ServiceModule 
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
        where T8 : struct
        where T9 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;
        private Action<T3> _signalSubscribeT3;
        private Action<T4> _signalSubscribeT4;
        private Action<T5> _signalSubscribeT5;
        private Action<T6> _signalSubscribeT6;
        private Action<T7> _signalSubscribeT7;
        private Action<T8> _signalSubscribeT8;
        private Action<T9> _signalSubscribeT9;

        public override void CreateInstances(ServiceCollector serviceCollector)
        {
            base.CreateInstances(serviceCollector); 
            _signalSubscribeT1 = OnSignal;
            _signalSubscribeT2 = OnSignal;
            _signalSubscribeT3 = OnSignal;
            _signalSubscribeT4 = OnSignal;
            _signalSubscribeT5 = OnSignal;
            _signalSubscribeT6 = OnSignal;
            _signalSubscribeT7 = OnSignal;
            _signalSubscribeT8 = OnSignal;
            _signalSubscribeT9 = OnSignal;
            
            SubscribeSignal(_signalSubscribeT1);
            SubscribeSignal(_signalSubscribeT2);
            SubscribeSignal(_signalSubscribeT3);
            SubscribeSignal(_signalSubscribeT4);
            SubscribeSignal(_signalSubscribeT5);
            SubscribeSignal(_signalSubscribeT6);
            SubscribeSignal(_signalSubscribeT7);
            SubscribeSignal(_signalSubscribeT8);
            SubscribeSignal(_signalSubscribeT9);
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
            UnsubscribeSignal(_signalSubscribeT8);
            UnsubscribeSignal(_signalSubscribeT9);
        }
        
        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);
        protected abstract void OnSignal(T5 data);
        protected abstract void OnSignal(T6 data);
        protected abstract void OnSignal(T7 data);
        protected abstract void OnSignal(T8 data);
        protected abstract void OnSignal(T9 data);
    }
    
    public abstract class ServiceModule<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : ServiceModule 
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
        where T8 : struct
        where T9 : struct
        where T10 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;
        private Action<T3> _signalSubscribeT3;
        private Action<T4> _signalSubscribeT4;
        private Action<T5> _signalSubscribeT5;
        private Action<T6> _signalSubscribeT6;
        private Action<T7> _signalSubscribeT7;
        private Action<T8> _signalSubscribeT8;
        private Action<T9> _signalSubscribeT9;
        private Action<T10> _signalSubscribeT10;

        public override void CreateInstances(ServiceCollector serviceCollector)
        {
            base.CreateInstances(serviceCollector); 
            _signalSubscribeT1 = OnSignal;
            _signalSubscribeT2 = OnSignal;
            _signalSubscribeT3 = OnSignal;
            _signalSubscribeT4 = OnSignal;
            _signalSubscribeT5 = OnSignal;
            _signalSubscribeT6 = OnSignal;
            _signalSubscribeT7 = OnSignal;
            _signalSubscribeT8 = OnSignal;
            _signalSubscribeT9 = OnSignal;
            _signalSubscribeT10 = OnSignal;
            
            SubscribeSignal(_signalSubscribeT1);
            SubscribeSignal(_signalSubscribeT2);
            SubscribeSignal(_signalSubscribeT3);
            SubscribeSignal(_signalSubscribeT4);
            SubscribeSignal(_signalSubscribeT5);
            SubscribeSignal(_signalSubscribeT6);
            SubscribeSignal(_signalSubscribeT7);
            SubscribeSignal(_signalSubscribeT8);
            SubscribeSignal(_signalSubscribeT9);
            SubscribeSignal(_signalSubscribeT10);
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
            UnsubscribeSignal(_signalSubscribeT8);
            UnsubscribeSignal(_signalSubscribeT9);
            UnsubscribeSignal(_signalSubscribeT10);
        }
        
        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);
        protected abstract void OnSignal(T5 data);
        protected abstract void OnSignal(T6 data);
        protected abstract void OnSignal(T7 data);
        protected abstract void OnSignal(T8 data);
        protected abstract void OnSignal(T9 data);
        protected abstract void OnSignal(T10 data);
    }
    
    public abstract class ServiceModule<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : ServiceModule 
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
        where T8 : struct
        where T9 : struct
        where T10 : struct
        where T11 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;
        private Action<T3> _signalSubscribeT3;
        private Action<T4> _signalSubscribeT4;
        private Action<T5> _signalSubscribeT5;
        private Action<T6> _signalSubscribeT6;
        private Action<T7> _signalSubscribeT7;
        private Action<T8> _signalSubscribeT8;
        private Action<T9> _signalSubscribeT9;
        private Action<T10> _signalSubscribeT10;
        private Action<T11> _signalSubscribeT11;

        public override void CreateInstances(ServiceCollector serviceCollector)
        {
            base.CreateInstances(serviceCollector); 
            _signalSubscribeT1 = OnSignal;
            _signalSubscribeT2 = OnSignal;
            _signalSubscribeT3 = OnSignal;
            _signalSubscribeT4 = OnSignal;
            _signalSubscribeT5 = OnSignal;
            _signalSubscribeT6 = OnSignal;
            _signalSubscribeT7 = OnSignal;
            _signalSubscribeT8 = OnSignal;
            _signalSubscribeT9 = OnSignal;
            _signalSubscribeT10 = OnSignal;
            _signalSubscribeT11 = OnSignal;
            
            SubscribeSignal(_signalSubscribeT1);
            SubscribeSignal(_signalSubscribeT2);
            SubscribeSignal(_signalSubscribeT3);
            SubscribeSignal(_signalSubscribeT4);
            SubscribeSignal(_signalSubscribeT5);
            SubscribeSignal(_signalSubscribeT6);
            SubscribeSignal(_signalSubscribeT7);
            SubscribeSignal(_signalSubscribeT8);
            SubscribeSignal(_signalSubscribeT9);
            SubscribeSignal(_signalSubscribeT10);
            SubscribeSignal(_signalSubscribeT11);
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
            UnsubscribeSignal(_signalSubscribeT8);
            UnsubscribeSignal(_signalSubscribeT9);
            UnsubscribeSignal(_signalSubscribeT10);
            UnsubscribeSignal(_signalSubscribeT11);
        }
        
        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);
        protected abstract void OnSignal(T5 data);
        protected abstract void OnSignal(T6 data);
        protected abstract void OnSignal(T7 data);
        protected abstract void OnSignal(T8 data);
        protected abstract void OnSignal(T9 data);
        protected abstract void OnSignal(T10 data);
        protected abstract void OnSignal(T11 data);
    }
    
    public abstract class ServiceModule<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : ServiceModule 
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        where T7 : struct
        where T8 : struct
        where T9 : struct
        where T10 : struct
        where T11 : struct
        where T12 : struct
    {
        private Action<T1> _signalSubscribeT1;
        private Action<T2> _signalSubscribeT2;
        private Action<T3> _signalSubscribeT3;
        private Action<T4> _signalSubscribeT4;
        private Action<T5> _signalSubscribeT5;
        private Action<T6> _signalSubscribeT6;
        private Action<T7> _signalSubscribeT7;
        private Action<T8> _signalSubscribeT8;
        private Action<T9> _signalSubscribeT9;
        private Action<T10> _signalSubscribeT10;
        private Action<T11> _signalSubscribeT11;
        private Action<T12> _signalSubscribeT12;

        public override void CreateInstances(ServiceCollector serviceCollector)
        {
            base.CreateInstances(serviceCollector); 
            _signalSubscribeT1 = OnSignal;
            _signalSubscribeT2 = OnSignal;
            _signalSubscribeT3 = OnSignal;
            _signalSubscribeT4 = OnSignal;
            _signalSubscribeT5 = OnSignal;
            _signalSubscribeT6 = OnSignal;
            _signalSubscribeT7 = OnSignal;
            _signalSubscribeT8 = OnSignal;
            _signalSubscribeT9 = OnSignal;
            _signalSubscribeT10 = OnSignal;
            _signalSubscribeT11 = OnSignal;
            _signalSubscribeT12 = OnSignal;
            
            SubscribeSignal(_signalSubscribeT1);
            SubscribeSignal(_signalSubscribeT2);
            SubscribeSignal(_signalSubscribeT3);
            SubscribeSignal(_signalSubscribeT4);
            SubscribeSignal(_signalSubscribeT5);
            SubscribeSignal(_signalSubscribeT6);
            SubscribeSignal(_signalSubscribeT7);
            SubscribeSignal(_signalSubscribeT8);
            SubscribeSignal(_signalSubscribeT9);
            SubscribeSignal(_signalSubscribeT10);
            SubscribeSignal(_signalSubscribeT11);
            SubscribeSignal(_signalSubscribeT12);
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
            UnsubscribeSignal(_signalSubscribeT8);
            UnsubscribeSignal(_signalSubscribeT9);
            UnsubscribeSignal(_signalSubscribeT10);
            UnsubscribeSignal(_signalSubscribeT11);
            UnsubscribeSignal(_signalSubscribeT12);
        }
        
        protected abstract void OnSignal(T1 data);
        protected abstract void OnSignal(T2 data);
        protected abstract void OnSignal(T3 data);
        protected abstract void OnSignal(T4 data);
        protected abstract void OnSignal(T5 data);
        protected abstract void OnSignal(T6 data);
        protected abstract void OnSignal(T7 data);
        protected abstract void OnSignal(T8 data);
        protected abstract void OnSignal(T9 data);
        protected abstract void OnSignal(T10 data);
        protected abstract void OnSignal(T11 data);
        protected abstract void OnSignal(T12 data);
    }
}