package com;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

public class InvertedIndex {
    private static HashMap<String, HashSet<Doc>> invertedIndex = new HashMap<>();

    public static void add(Doc document) {
        for (String word: document.getWords()) {
            if (invertedIndex.get(word) == null) invertedIndex.put(word, new HashSet<>());
            invertedIndex.get(word).add(document);
        }
    }

    public static HashSet<Doc> get(String word) {
        HashSet<Doc> answer = invertedIndex.get(word);
        if (answer == null) return new HashSet<>();
        return answer;
    }

    public static HashSet<Doc> get(ArrayList<String> includeAll, ArrayList<String> excludeAll, ArrayList<String> includeOne, ArrayList<Doc> documents) {
        HashSet<Doc> answer = new HashSet<>();

        if(includeOne.isEmpty())
            answer = new HashSet<>(documents);
        else {
            for(String word : includeOne) {
                answer.addAll(InvertedIndex.get(word.substring(1)));
            }
        }

        for (String word : includeAll) {
            answer.retainAll(InvertedIndex.get(word));
        }

        for (String word : excludeAll) {
            answer.removeAll(InvertedIndex.get(word.substring(1)));
        }

        return answer;
    }
}