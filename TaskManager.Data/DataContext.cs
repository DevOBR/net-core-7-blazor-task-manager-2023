﻿using System;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Entities;

namespace TaskManager.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<MyTask> MyTasks { get; set; }
	}
}