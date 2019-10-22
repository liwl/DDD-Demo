using DDD.Domain.Models;
using DDD.Infrastruct.Data.Mappings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DDD.Infrastruct.Data.Context
{
    /// <summary>
    /// 定义核心子领域——学习上下文
    /// </summary>
    public class StudyContext : DbContext
    {

        private readonly IHostingEnvironment _env;

        public StudyContext(IHostingEnvironment env)
        {
            _env = env;

         
         
        }


        public DbSet<Student> Students { get; set; }

        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// 重写自定义Map配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");


            modelBuilder.ApplyConfiguration(new StudentMap());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 重写连接数据库
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 从 appsetting.json 中获取配置信息
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // 定义要使用的数据库
            optionsBuilder.UseMySQL(config.GetConnectionString("MySqlConnectionString"));
        }
    }
}
