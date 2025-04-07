using LifeStream.Areas.Identity.Data;
using LifeStream.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LifeStream.Data;

public class LifeStreamdDBContext : IdentityDbContext<LifeStreamUser>
{
    public LifeStreamdDBContext(DbContextOptions<LifeStreamdDBContext> options)
        : base(options)
    {
    }
    
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Receptionist> Receptionists { get; set; }
    public DbSet<Staff> Staffs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        List<IdentityRole> roles = new List<IdentityRole>();

        foreach (var roleName in UserRoleInfo.AllRoles)
        {
            roles.Add(new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = roleName,
                NormalizedName = roleName.ToUpper()
            });
        }

        modelBuilder.Entity<IdentityRole>().HasData(roles);

        var adminUserId = Guid.NewGuid().ToString();
        var adminUser = new LifeStreamUser
        {
            Id = adminUserId,
            UserName = "admin@lifestream.com",
            NormalizedUserName = "ADMIN@LIFESTREAM.COM",
            Email = "admin@lifestream.com",
            NormalizedEmail = "ADMIN@LIFESTREAM.COM",
            EmailConfirmed = true,
            FirstName = "LifeStream",
            LastName = "Admin"
        };

        var passwordHasher = new PasswordHasher<LifeStreamUser>();
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123");

        modelBuilder.Entity<LifeStreamUser>().HasData(adminUser);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            UserId = adminUserId,
            RoleId = roles.First(r => r.Name == "Admin").Id
        });


        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        modelBuilder.Entity<Appointment>()
        .HasOne(a => a.Patient)
        .WithMany(p => p.Appointments)
        .HasForeignKey(a => a.PatientId)
        .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.SetNull

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MedicalRecord>()
         .HasOne(a => a.Patient)
         .WithMany(p => p.MedicalRecords)
         .HasForeignKey(a => a.PatientId)
         .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.SetNull

        modelBuilder.Entity<MedicalRecord>()
            .HasOne(a => a.Doctor)
            .WithMany(e => e.MedicalRecords)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Feedback>()
         .HasOne(a => a.Appointment)
         .WithMany(p => p.FeedBacks)
         .HasForeignKey(a => a.AppointmentId)
         .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.SetNull

        modelBuilder.Entity<Feedback>()
            .HasOne(a => a.Doctor)
            .WithMany(e => e.FeedBacks)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Doctor>()
        //.HasOne(d => d.User)
        //.WithMany()
        //.HasForeignKey(d => d.UserId)
        //.OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Doctor>()
        .HasOne(d => d.User)
        .WithMany()
        .HasForeignKey(d => d.UserId)
        .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Doctor>()
        //    .HasOne(a => a.User)
        //    .WithOne(e => e.Doctors)
        //    .HasForeignKey<Doctor>(x => x.UserId)
        //    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Patient>()
           .HasOne(p => p.User)
           .WithOne(u => u.Patients)
           .HasForeignKey<Patient>(x => x.UserId)
           .IsRequired(false);

        modelBuilder.Entity<Receptionist>()
           .HasOne(a => a.User)
           .WithOne(e => e.Receptionist)
           .HasForeignKey<Receptionist>(x => x.UserId)
           .IsRequired(false);
    }
}
