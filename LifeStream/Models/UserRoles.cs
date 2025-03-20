namespace LifeStream
{
    public static class UserRoleInfo
    {
        public const string Admin = "Admin";
        public const string Doctor = "Doctor";
        public const string Patient = "Patient";
        public const string Receptionist = "Receptionist";

        public static readonly string[] AllRoles = { Admin, Doctor, Patient, Receptionist };
    }

}
