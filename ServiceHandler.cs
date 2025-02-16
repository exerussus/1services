
using System.Linq;
using Exerussus._1Extensions.SignalSystem;
using Exerussus._1Extensions.SmallFeatures;
using UnityEngine;

namespace Exerussus.Servecies
{
    public abstract class ServiceHandler : MonoBehaviour
    {
        public abstract StartType Autostart { get; }
        public abstract Signal Signal { get; }
        public GameShare GameShare { get; private set; }
        private Service[] _services;
        private Service[] _fixedUpdateServices;
        private Service[] _updateServices;

        private bool _hasFixedUpdateServices;
        private bool _hasUpdateServices;
        public bool IsInitialize { get; private set; }

        private void Awake()
        {
            if (Autostart == StartType.Awake) Initialize();
        }

        private void Start()
        {
            if (Autostart == StartType.Start) Initialize();
        }

        public void Initialize()
        {
            GameShare = GetGameShare();
            _services = GetServices();
            SetSharedData(GameShare);
            CreateInstances();
            SetAllSharedData();
            InjectAll();
            PreInitServices();
            InitServices();
            PostInitServices();

            GetAllUpdates();
            
            IsInitialize = true;
        }

        protected virtual GameShare GetGameShare()
        {
            return new GameShare();
        }
        protected virtual void SetSharedData(GameShare gameShare) { }
        protected abstract Service[] GetServices();

        private void CreateInstances()
        {
            foreach (var service in _services) service.CreateInstances(GameShare, Signal);
        }
        
        private void SetAllSharedData()
        {
            foreach (var service in _services) service.SetSharedObject();
        }
        
        private void InjectAll()
        {
            foreach (var service in _services) service.Inject();
        }
        
        private void PreInitServices()
        {
            foreach (var service in _services) service.PreInitialize();
        }

        private void InitServices()
        {
            foreach (var service in _services) service.Initialize();
        }

        private void PostInitServices()
        {
            foreach (var service in _services) service.PostInitServices();
        }

        private void GetAllUpdates()
        {
            _fixedUpdateServices = _services.Where(x => x.HasFixedUpdateModules).ToArray();
            if (_fixedUpdateServices.Length > 0) _hasFixedUpdateServices = true;
            
            _updateServices = _services.Where(x => x.HasUpdateModules).ToArray();
            if (_updateServices.Length > 0) _hasUpdateServices = true;
        }
        
        public virtual void Update()
        {
            if (!_hasUpdateServices) return;

            for (int i = 0; i < _updateServices.Length; i++)
            {
                var service = _updateServices[i];
                service.Update();
            }
        }
        
        public virtual void FixedUpdate()
        {
            if (!_hasFixedUpdateServices) return;

            for (int i = 0; i < _fixedUpdateServices.Length; i++)
            {
                var service = _fixedUpdateServices[i];
                service.FixedUpdate();
            }
        }

        protected virtual void OnDestroy()
        {
            foreach (var service in _services) service.OnDestroy();
        }

        public enum StartType
        {
            None,
            Awake,
            Start,
        }
    }
}
