﻿using System;
using System.Collections.Generic;
using System.Text;
using AplicationCore.Entities;

namespace AplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> ListAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
