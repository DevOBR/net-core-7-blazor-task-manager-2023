using System;
using TaskManager.Share.Models;

namespace TaskManager.Frontend.WebRepository
{
    public interface IWebRepository
    {
        Task<Response<T>> GetAsync<T>(string url);
    }
}

