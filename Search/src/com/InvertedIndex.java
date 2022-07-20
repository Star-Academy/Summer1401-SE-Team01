package com;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

public class InvertedIndex {
    private static HashMap<String, HashSet<Doc>> invertedIndex = new HashMap<>();
    private static ArrayList<Doc> documents = new ArrayList<>();


    public static void addDocuments(ArrayList<Doc> documents) {
        InvertedIndex.documents.addAll(documents);

        for(Doc document : documents) {
            for (String word : document.getWords()) {
                if (invertedIndex.get(word) == null) invertedIndex.put(word, new HashSet<>());
                invertedIndex.get(word).add(document);
            }
        }
    }

    public static HashSet<Doc> get(String word) {
        HashSet<Doc> answer = invertedIndex.get(word);
        if (answer == null) return new HashSet<>();
        return answer;
    }

    public static HashSet<Doc> findIncludeOne(ArrayList<String> includeOne, HashSet<Doc> selectedFiles) {
        if(includeOne.isEmpty())
            selectedFiles = new HashSet<Doc>(documents);
        else {
            for(String word : includeOne) {
                selectedFiles.addAll(get(word));
            }
        }

        return selectedFiles;
    }

    public static HashSet<Doc> findIncludeAll(ArrayList<String> includeAll, HashSet<Doc> selectedFiles) {
        for (String word : includeAll) {
            selectedFiles.retainAll(InvertedIndex.get(word));
        }

        return selectedFiles;
    }

    public static HashSet<Doc> findExcludeAll(ArrayList<String> excludeAll, HashSet<Doc> selectedFiles) {
        for (String word : excludeAll) {
            selectedFiles.removeAll(InvertedIndex.get(word));
        }

        return selectedFiles;
    }


    public static HashSet<Doc> get(SplitedInput splitedInput) {
        HashSet<Doc> selectedFile = new HashSet<>();

        findIncludeOne(splitedInput.getIncludeOne(), selectedFile);
        findIncludeAll(splitedInput.getIncludeAll(), selectedFile);
        findExcludeAll(splitedInput.getExcludeAll(), selectedFile);

        return selectedFile;
    }
}