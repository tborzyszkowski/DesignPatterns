using System;
using System.Collections.Generic;
using System.Text;


namespace Application.Interfaces
{
    public interface IQuery
    {
    }
    public interface IQueryHandler
    {
    }

    public interface IQueryHandler<T> : IQueryHandler where T : IQuery
    {
        IList<IResult> Handle(T query);
        
    }


    public interface IQueryDispatcher
    {
        IList<IResult> Send<T>(T query) where T : IQuery;
    }

}
