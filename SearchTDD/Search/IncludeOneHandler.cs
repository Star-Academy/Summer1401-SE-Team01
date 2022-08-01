using System.Collections.Generic;
using System.Linq;
namespace Search;

public class IncludeOneHandler : ISearchHandler
{
    public ISearchHandler? Next { get; set; }

    public IEnumerable<string> Handle(InvertedIndex invertedIndex, IEnumerable<string> query)
    {
        var includeOneQueries = query.Where(x => x.StartsWith("+"));
        if (!includeOneQueries.Any())
        {
            if (Next == null)
                return invertedIndex.AllNames;
            return Next.Handle(invertedIndex, query);
        }

        IEnumerable<string> answer = new List<string>();
        foreach (var includeOneQuery in includeOneQueries)
        {
            try
            {
                answer = answer.Union(invertedIndex.Database[includeOneQuery.Substring(1).ToUpper()]);
            }
            catch
            {
                ;
            }
        }

        if (Next != null) answer = answer.Intersect(Next.Handle(invertedIndex, query));

        return answer;
    }
}