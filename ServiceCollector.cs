using System;
using System.Collections.Generic;
using Exerussus._1Extensions.SignalSystem;
using Exerussus._1Extensions.SmallFeatures;
using Exerussus.Servecies.Interfaces;
using UnityEngine;

namespace Exerussus.Servecies
{
    public class ServiceCollector
    {
        public ServiceCollector(GameShare gameShare, Signal signal)
        {
            GameShare = gameShare;
            Signal = signal;
        }

        private List<Service> _service = new();
        private List<ServiceModule> _serviceModules = new();
        private List<ModuleWrapper> _updateModules = new();
        private List<IMicroService> _microServices = new();
        private Dictionary<Type, IMicroService> _microServicesDict = new();

        public Dictionary<Type, IMicroService> MicroServicesDict => _microServicesDict;

        public List<Service> Service => _service;
        public List<ServiceModule> ServiceModules => _serviceModules;

        public GameShare GameShare { get; }
        public Signal Signal { get; }
        
        public ServiceCollector Add(Service service)
        {
            _service.Add(service);
            return this;
        }
        
        public ServiceCollector Add(ServiceModule serviceModule)
        {
            _serviceModules.Add(serviceModule);
            return this;
        }
        
        public ServiceCollector Add(List<Service> services)
        {
            foreach (var service in services) _service.Add(service);
            return this;
        }
        
        public ServiceCollector Add(List<ServiceModule> serviceModules)
        {
            foreach (var serviceModule in serviceModules) _serviceModules.Add(serviceModule);
            return this;
        }
        
        public ServiceCollector Add(Service[] services)
        {
            if (services == null || services.Length == 0) return this;
            foreach (var service in services) _service.Add(service);
            return this;
        }
        
        public ServiceCollector Add(ServiceModule[] serviceModules)
        {
            if (serviceModules == null || serviceModules.Length == 0) return this;
            foreach (var serviceModule in serviceModules) _serviceModules.Add(serviceModule);
            return this;
        }
        
        private void GetAllMicroServices()
        {
            foreach (var service in _service) if (service is IMicroService microService) _microServices.Add(microService);
            foreach (var serviceModule in _serviceModules) if (serviceModule is IMicroService microService) _microServices.Add(microService);
            
            foreach (var microService in _microServices)
            {
                if (_microServicesDict.ContainsKey(microService.GetType())) Debug.LogError($"MicroService with type {microService.GetType()} already exists!");
                _microServicesDict[microService.GetType()] = microService;
            }
        }

        private void GetAllModuleUpdate()
        {
            foreach (var service in _service) if (service is IModuleUpdate moduleUpdate) _updateModules.Add(new ModuleWrapper(moduleUpdate));
            foreach (var serviceModule in _serviceModules) if (serviceModule is IModuleUpdate moduleUpdate) _updateModules.Add(new ModuleWrapper(moduleUpdate));
        }
        
        public void Bake()
        {
            GetAllMicroServices();
            GetAllModuleUpdate();
        }

        public void Update()
        {
            foreach (var moduleWrapper in _updateModules)
            {
                if (!(Time.time > moduleWrapper.NextTimeUpdate)) continue;
                moduleWrapper.NextTimeUpdate = Time.time + moduleWrapper.ModuleUpdate.UpdateDelay;
                moduleWrapper.ModuleUpdate.Update(Time.time - moduleWrapper.LastUpdateTime);
                moduleWrapper.LastUpdateTime = Time.time;
            }
        }
    }
}