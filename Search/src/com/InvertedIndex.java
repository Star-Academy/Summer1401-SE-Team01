package com;

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
}