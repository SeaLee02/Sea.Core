﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sea.Core.Entity;

namespace Sea.Core.Api.Data.Migrations.MyDbCli
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sea.Core.Entity.Sys.Module2PermissionEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreateId");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateTime");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeleteTime");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("IsDelete");

                    b.Property<string>("ModifyId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ModifyId");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifyTime");

                    b.Property<string>("ModuleId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ModuleId");

                    b.Property<string>("PermissionId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PermissionId");

                    b.HasKey("Id");

                    b.ToTable("Sys_Module2Permission");
                });

            modelBuilder.Entity("Sea.Core.Entity.Sys.ModuleEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Action");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Area");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Code");

                    b.Property<string>("Controller")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Controller");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreateId");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateTime");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeleteTime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Icon");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("IsDelete");

                    b.Property<bool?>("IsEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("IsEnabled");

                    b.Property<bool?>("IsMenu")
                        .HasColumnType("bit")
                        .HasColumnName("IsMenu");

                    b.Property<string>("LinkUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LinkUrl");

                    b.Property<string>("ModifyId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ModifyId");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifyTime");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int?>("OrderSort")
                        .HasColumnType("int")
                        .HasColumnName("OrderSort");

                    b.HasKey("Id");

                    b.ToTable("Sys_Module");
                });

            modelBuilder.Entity("Sea.Core.Entity.Sys.PermissionEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Code");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreateId");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateTime");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeleteTime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Func")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Func");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Icon");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("IsDelete");

                    b.Property<bool?>("IsEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("IsEnabled");

                    b.Property<bool>("IsHide")
                        .HasColumnType("bit")
                        .HasColumnName("IsHide");

                    b.Property<bool?>("IskeepAlive")
                        .HasColumnType("bit")
                        .HasColumnName("IskeepAlive");

                    b.Property<string>("Mid")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Mid");

                    b.Property<string>("ModifyId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ModifyId");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifyTime");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("OrderSort")
                        .HasColumnType("int")
                        .HasColumnName("OrderSort");

                    b.Property<string>("Pid")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Pid");

                    b.HasKey("Id");

                    b.ToTable("Sys_Permission");
                });

            modelBuilder.Entity("Sea.Core.Entity.Sys.RoleEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreateId");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateTime");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeleteTime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("IsDelete");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("IsEnabled");

                    b.Property<string>("ModifyId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ModifyId");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifyTime");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int?>("OrderSort")
                        .HasColumnType("int")
                        .HasColumnName("OrderSort");

                    b.HasKey("Id");

                    b.ToTable("Sys_Role");
                });

            modelBuilder.Entity("Sea.Core.Entity.Sys.User2RoleEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreateId");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateTime");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeleteTime");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("IsDelete");

                    b.Property<string>("ModifyId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ModifyId");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifyTime");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RoleId");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("Sys_User2Role");
                });

            modelBuilder.Entity("Sea.Core.Entity.Sys.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Addr")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Addr");

                    b.Property<int?>("Age")
                        .HasColumnType("int")
                        .HasColumnName("Age");

                    b.Property<DateTime?>("Birth")
                        .HasColumnType("datetime2")
                        .HasColumnName("Birth");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreateId");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateTime");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeleteTime");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("IsDelete");

                    b.Property<string>("LoginName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LoginName");

                    b.Property<string>("LoginPwd")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LoginPwd");

                    b.Property<string>("ModifyId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ModifyId");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifyTime");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("RealName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RealName");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Remark");

                    b.Property<int?>("Sex")
                        .HasColumnType("int")
                        .HasColumnName("Sex");

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Sys_User");
                });

            modelBuilder.Entity("Sea.Core.Entity.Sys.View.ViewUser", b =>
                {
                    b.Property<string>("Addr")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Addr");

                    b.Property<int?>("Age")
                        .HasColumnType("int")
                        .HasColumnName("Age");

                    b.Property<DateTime?>("Birth")
                        .HasColumnType("datetime2")
                        .HasColumnName("Birth");

                    b.Property<string>("CreateId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreateId");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateTime");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeleteTime");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("IsDelete");

                    b.Property<string>("LoginName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LoginName");

                    b.Property<string>("LoginPwd")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LoginPwd");

                    b.Property<string>("ModifyId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ModifyId");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifyTime");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("RealName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RealName");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Remark");

                    b.Property<int?>("Sex")
                        .HasColumnType("int")
                        .HasColumnName("Sex");

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.ToTable("View_Sys_User");

                    b.ToView("View_Sys_User");
                });
#pragma warning restore 612, 618
        }
    }
}
