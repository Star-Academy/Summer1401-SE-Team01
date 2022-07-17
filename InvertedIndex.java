import java.util.HashMap;
import java.util.HashSet;

public class InvertedIndex {
    private static HashMap<String, HashSet<Document>> invertedIndex = new HashMap<>();

    public static void add(Document document) {
        for (String word: document.getWords()) {
            invertedIndex.get(word).add(document);
        }
    }

    public static HashSet<Document> get(String word) {
        HashSet<Document> answer = invertedIndex.get(word);
        if (answer == null) return new HashSet<>();
        return answer;
    }
}