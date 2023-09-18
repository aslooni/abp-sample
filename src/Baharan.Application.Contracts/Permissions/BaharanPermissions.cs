namespace Baharan.Permissions;

public static class BaharanPermissions
{
    public const string GroupName = "Baharan";

    public const string DocumentGroupName = "Document";
    public const string PersonnelsGroupName = "Personnel";
    public const string ExperienceGroupName = "Experience";
    public static class Documents
    {
        public const string Default = GroupName + ".Documents";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string Menu = Default + ".Menu";
    }
    public static class Personnels
    {
        public const string Default = GroupName + ".Personnels";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string Menu = Default + ".Menu";
        public const string UserMenu = Default + ".UserMenu";
    }
    public static class Experiences
    {
        public const string Default = GroupName + ".Experiences";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string Menu = Default + ".Menu";
    }

}
