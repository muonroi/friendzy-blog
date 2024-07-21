namespace FriendzyBlog.Data.Seed
{
    public class DefaultLanguagesCreator(FriendzyBlogContext context)
    {
        public static List<AppLanguage> InitialLanguages => GetInitialLanguages();

        private readonly FriendzyBlogContext _context = context;

        private static List<AppLanguage> GetInitialLanguages()
        {
            return
            [
            new AppLanguage("en", "English", "famfamfam-flags us"),
            new AppLanguage("vi", "Tiếng Việt", "famfamfam-flags vn"),
            ];
        }

        public void Create()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (AppLanguage language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(AppLanguage language)
        {
            language.CreatedDateTS = DateTime.UtcNow.GetTimeStamp();
            if (_context.Languages.IgnoreQueryFilters().Any(l => l.Name == language.Name))
            {
                return;
            }
            _ = _context.Languages.Add(language);
            _ = _context.SaveChanges();
        }
    }
}