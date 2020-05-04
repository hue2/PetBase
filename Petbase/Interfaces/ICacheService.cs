﻿namespace Petbase.Interfaces
{
    public interface ICacheService
    {
        object GetCache(object key);
        void SaveCache(object key, object value);
    }
}
