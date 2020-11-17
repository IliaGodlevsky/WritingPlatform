using AutoMapper;

namespace WritingPlatform.Service.Mapping
{
    internal static class MapperService
    {
        static MapperService()
        {
            var expression = new MapperExpression();
            var configuration = new MapperConfiguration(expression);

            Instance = configuration.CreateMapper();
        }

        public static IMapper Instance { get; }
    }
}
