namespace BuilderPattern
{
    public interface IMapper { }
    public interface ILogger { }
    public interface IUnitOfWork { }

    public class Mapper : IMapper { }
    public class Logger : ILogger { }
    public class UnitOfWork : IUnitOfWork { }
}
