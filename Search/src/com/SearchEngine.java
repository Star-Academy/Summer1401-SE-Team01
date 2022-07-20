package com;

import java.util.ArrayList;
import java.util.HashSet;

public class SearchEngine {
    public static void run() {
        ArrayList<Doc> documents = FileReader.readFiles();
        InvertedIndex invertedIndex = new InvertedIndex(documents);
        SplitedInput splitedInput = Input.prepareInput();

        HashSet<Doc> answer = invertedIndex.get(splitedInput);

        Output.print(answer);
    }
}
