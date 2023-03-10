// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList;

#nullable disable

namespace ToDoList.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20221222113826_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoList.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "First Project"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Second Project"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Third Project"
                        });
                });

            modelBuilder.Entity("ToDoList.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DueDate = new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = false,
                            ProjectId = 1,
                            Title = "First Task"
                        },
                        new
                        {
                            Id = 2,
                            DueDate = new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = true,
                            ProjectId = 1,
                            Title = "Second Task"
                        },
                        new
                        {
                            Id = 3,
                            DueDate = new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = true,
                            ProjectId = 2,
                            Title = "Third Task"
                        },
                        new
                        {
                            Id = 4,
                            DueDate = new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = false,
                            ProjectId = 2,
                            Title = "Forth Task"
                        },
                        new
                        {
                            Id = 5,
                            DueDate = new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = false,
                            ProjectId = 3,
                            Title = "Fifth Task"
                        },
                        new
                        {
                            Id = 6,
                            DueDate = new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = true,
                            ProjectId = 3,
                            Title = "Sixth Task"
                        });
                });

            modelBuilder.Entity("ToDoList.Task", b =>
                {
                    b.HasOne("ToDoList.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ToDoList.Project", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
