namespace Search;

public class ExludeAllHandler : ISearchHandler
{
    public ISearchHandler? Next { get; set; }
    public IEnumerable<string> Handle(InvertedIndex invertedIndex, IEnumerable<string> query)
    {
        var excludeAllQueries = query.Where(x => x.StartsWith("-"));
        IEnumerable<string> answer;
        if (Next == null) answer = invertedIndex.AllNames;
        else answer = Next.Handle(invertedIndex, query);
        foreach (var excludeAllQuery in excludeAllQueries)
        {
            try
            {
                answer = answer.Except(invertedIndex.Database[excludeAllQuery.Substring(1).ToUpper()]);
            }
            catch (KeyNotFoundException e)
            {
                ;
            }
        }

        return answer;
    }
}