
using System;
using System.Threading.Tasks;
using Exerussus._1EasyEcs.Scripts.Core;
using Exerussus._1Extensions.Abstractions;
using Exerussus._1Extensions.SignalSystem;
using Exerussus._1Extensions.SmallFeatures;
using Exerussus.Servecies.Interfaces;
using UnityEngine;

namespace Exerussus.Servecies
{
    public abstract class ServiceHandler : MonoBehaviour, IInitializable
    {
        public abstract StartType Autostart { get; }
        public abstract Signal Signal { get; }
        public GameShare GameShare { get; private set; }

        private Service[] _updateServices;
        private ServiceCollector _serviceCollector;

        private bool _hasUpdateServices;
        private bool _isQuit;
        public bool IsInitialized { get; private set; }

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
            Debug.Log("1");
            GameShare = GetGameShare();
            _serviceCollector = new ServiceCollector(GameShare, Signal);
            SetSharedData(GameShare);
            SetServices(_serviceCollector);
            CreateServiceInstances();
            SetModules();
            CreateServiceModuleInstances();
            SetAllSharedData();
            InjectAll();
            PreInitServices();
            InitServices();
            PostInitServices();
            BakeCollector();
            
            Debug.Log("2");
            IsInitialized = true;
        }

        protected virtual GameShare GetGameShare()
        {
            return new GameShare();
        }
        protected virtual void SetSharedData(GameShare gameShare) { }
        protected abstract void SetServices(ServiceCollector serviceCollector);

        private void CreateServiceInstances()
        {
            foreach (var service in _serviceCollector.Service) service.CreateInstances(_serviceCollector);
        }

        private void SetModules()
        {
            foreach (var service in _serviceCollector.Service) service.SetModules(_serviceCollector);
        }
        
        private void CreateServiceModuleInstances()
        {
            foreach (var serviceModule in _serviceCollector.ServiceModules) serviceModule.CreateInstances(_serviceCollector);
        }
        
        private void SetAllSharedData()
        {
            foreach (var service in _serviceCollector.Service) service.SetSharedObject();
            foreach (var serviceModule in _serviceCollector.ServiceModules) serviceModule.SetSharedObject();
        }
        
        private void InjectAll()
        {
            foreach (var service in _serviceCollector.Service) GameShare.InjectSharedObjects(service);
            foreach (var serviceModule in _serviceCollector.ServiceModules) GameShare.InjectSharedObjects(serviceModule);
        }
        
        private void PreInitServices()
        {
            foreach (var service in _serviceCollector.Service) service.PreInitialize();
            foreach (var serviceModule in _serviceCollector.ServiceModules) serviceModule.PreInitialize();
        }

        private void InitServices()
        {
            foreach (var service in _serviceCollector.Service) service.Initialize();
            foreach (var serviceModule in _serviceCollector.ServiceModules) serviceModule.Initialize();
        }

        private void PostInitServices()
        {
            foreach (var service in _serviceCollector.Service) service.PostInitialize();
            foreach (var serviceModule in _serviceCollector.ServiceModules) serviceModule.PostInitialize();
        }

        private void BakeCollector()
        {
            _serviceCollector.Bake();
        }

        public async Task<(bool result, MicroServiceProcessState state)> RunProcessAsync<T>(MicroServiceProcessContext context = null) where T : IMicroService
        {
            if (context != null) MicroServiceProcessContext.ChangeProcessState(context, MicroServiceProcessState.Waiting); 
            
            var type = typeof(T);
            
            if (!_serviceCollector.MicroServicesDict.TryGetValue(type, out var microService)) return (false, MicroServiceProcessState.NotFoundService);

            if (context == null) context = new MicroServiceProcessContext();

            MicroServiceProcessContext.ChangeProcessState(context, MicroServiceProcessState.Processing);

            try
            { 
                var result = await microService.RunProcess(context);
                MicroServiceProcessContext.ChangeProcessState(context, result);
                return (true, result);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message + "\n" + e.StackTrace);
                return (false, MicroServiceProcessState.FailedInProcess);
            }
        }

        public virtual void Update()
        {
            if (!IsInitialized) return;
            _serviceCollector.Update();
        }

        protected virtual void OnDestroy()
        {
            if (_serviceCollector == null) return;
            foreach (var serviceModule in _serviceCollector.ServiceModules) serviceModule.OnDestroy();
            foreach (var service in _serviceCollector.Service) service.OnDestroy();
        }

        public enum StartType
        {
            None,
            Awake,
            Start,
        }
    }
}
