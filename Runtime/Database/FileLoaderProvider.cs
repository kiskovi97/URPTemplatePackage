
namespace URPTemplate.Database
{
    class FileLoaderProvider
    {
        public static IFileLoader FileLoader { get; private set; } = new LocalFileLoader();

        public static void SetFileLoader(IFileLoader fileLoader)
        {
            FileLoader = fileLoader;
        }
    }
}
