using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TelldusAPI
{
    public class CachedTelldusClient: ITelldusClient
    {
        private readonly ITelldusClient client;
        private readonly AbsoluteCache<IList<Sensor>> sensorCache;
        private readonly AbsoluteCache<IList<Device>> deviceCache;

        public CachedTelldusClient(ITelldusClient client)
        {
            this.client = client;
            sensorCache = new AbsoluteCache<IList<Sensor>>("SENSORS", 60); // one minute
            deviceCache = new AbsoluteCache<IList<Device>>("DEVICES", 60*60*24); // 24h
        }

        public Task<Response> DimAsync(int deviceId, double level)
        {
            return client.DimAsync(deviceId, level);
        }

        public Task<IList<Device>> GetDevicesAsync()
        {
            return deviceCache.GetDataAsync(client.GetDevicesAsync);
        }

        public Task<IList<Sensor>> GetSensorsAsync()
        {
            return sensorCache.GetDataAsync(client.GetSensorsAsync);
        }

        public Task<Response> TurnOffAsync(int deviceId)
        {
            return client.TurnOffAsync(deviceId);
        }

        public Task<Response> TurnOnAsync(int deviceId)
        {
            return client.TurnOnAsync(deviceId);
        }
    }
    
    public class AbsoluteCache<T>
    {
        private readonly string key;
        private readonly int absoluteExpirationInSeconds;
        private readonly MemoryCache cache;
        public AbsoluteCache(string key, int absoluteExpirationInSeconds)
        {
            this.key = key;
            this.absoluteExpirationInSeconds = absoluteExpirationInSeconds;
            cache = new MemoryCache(new MemoryCacheOptions());
        }

        public async Task<T> GetDataAsync(Func<Task<T>> getData)
        {
            if (cache.TryGetValue(key, out T data))
            {
                return data;
            }

            var newSensorData = await getData();
            cache.Set(key, newSensorData, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(absoluteExpirationInSeconds)));
            return newSensorData;
        }
    }
}