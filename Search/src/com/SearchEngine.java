package com;

import java.util.ArrayList;
import java.util.HashSet;

public class SearchEngine {
    public static void run() {
        ArrayList<Doc> documents = FileReader.readFiles();
        InvertedIndex.addDocuments(documents);
        SplitedInput splitedInput = Input.prepareInput();

        HashSet<Doc> answer = InvertedIndex.get(splitedInput);

        Output.print(answer);
    }
}
