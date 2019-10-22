using DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastruct.Data.Mappings
{
    /// <summary>
    /// 学生map类
    /// </summary>
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(11)
                .IsRequired();


            //处理值对象配置，否则会被视为实体
            builder.OwnsOne(p => p.Address);

            //可以对值对象进行数据库重命名，还有其他的一些操作，请参考官网
            //builder.OwnsOne(
            //    o => o.Address,
            //    sa =>
            //    {
            //        sa.Property(p => p.County).HasColumnName("County");
            //        sa.Property(p => p.Province).HasColumnName("Province");
            //        sa.Property(p => p.City).HasColumnName("City");
            //        sa.Property(p => p.Street).HasColumnName("Street");
            //    }
            //);


            //如果想忽略当前值对象，可直接 Ignore
            //builder.Ignore(c => c.Address);
        }
    }
}
