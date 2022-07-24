package com;

import java.util.ArrayList;
import java.util.HashSet;

public class SearchEngine {
    public static void run(ArrayList<Doc> documents, SplitedInput splitedInput) {
        InvertedIndex.addDocuments(documents);

        HashSet<Doc> answer = InvertedIndex.get(splitedInput);

        Output.print(answer);
    }
}
