using System.Linq;
namespace Search;

public class IncludeAllHandler : ISearchHandler
{
    public ISearchHandler? Next { get; set; }

    public IEnumerable<string> Handle(InvertedIndex invertedIndex, IEnumerable<string> query)
    {
        var includeAllQueries = query.Where(x => !x.StartsWith("+") && !x.StartsWith("-"));
        if (!includeAllQueries.Any())
        {
            if (Next == null)
                return invertedIndex.AllNames;
            return Next.Handle(invertedIndex, query);
        }

        IEnumerable<string> answer = invertedIndex.AllNames;
        foreach (var includeAllQuery in includeAllQueries)
        {
            answer = answer.Intersect(invertedIndex.Database[includeAllQuery.ToUpper()]);
        }

        if (Next != null)
            answer = answer.Intersect(Next.Handle(invertedIndex, query));

        return answer;
    }
}