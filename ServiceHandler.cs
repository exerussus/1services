
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exerussus._1Extensions.SignalSystem;
using Exerussus._1Extensions.SmallFeatures;
using Exerussus.Servecies.Interfaces;
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
        private readonly Dictionary<Type, IMicroService> _microServices = new();

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
            GetAllMicroServices();
            
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

        private void GetAllMicroServices()
        {
            var microServices = new List<IMicroService>();
            foreach (var service in _services)
            {
                if (service is IMicroService microService) microServices.Add(microService);
                service.FillMicroServices(microServices);
            }

            foreach (var microService in microServices)
            {
                if (_microServices.ContainsKey(microService.GetType())) Debug.LogError($"MicroService with type {microService.GetType()} already exists!");
                _microServices[microService.GetType()] = microService;
            }
        }

        public async Task<(bool result, MicroServiceProcessState state)> RunProcessAsync<T>(MicroServiceProcessContext context = null) where T : IMicroService
        {
            if (context != null) MicroServiceProcessContext.ChangeProcessState(context, MicroServiceProcessState.Waiting); 
            
            var type = typeof(T);
            
            if (!_microServices.TryGetValue(type, out var microService)) return (false, MicroServiceProcessState.NotFoundService);

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
