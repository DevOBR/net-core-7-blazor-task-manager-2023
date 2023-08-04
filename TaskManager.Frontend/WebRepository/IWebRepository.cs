﻿using System;
using TaskManager.Share.Models;

namespace TaskManager.Frontend.WebRepository
{
    public interface IWebRepository
    {
        Task<Response<T>> GetAsync<T>(string url);
        Task<Response<T>> PostAsync<T>(string url, T model);
        Task<Response<T>> PutAsync<T>(string url, T model);
        Task<Response<T>> DeleteAsync<T>(string url);
    }
}

