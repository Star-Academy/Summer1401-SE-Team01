package com.FileReader;

import java.util.ArrayList;
import java.util.StringTokenizer;

public class Doc {
    private String documentName;
    private ArrayList<String> words;


    public Doc (String documentName_, String contex) {
        documentName = documentName_;
        contex = deletePunctuationMarks(contex);
        words = tokenizeString(contex);
    }

    public String getName() {
        return documentName;
    }

    public ArrayList<String> getWords() {
        return words;
    }

    private ArrayList<String> tokenizeString(String string) {
        ArrayList<String> tokenz = new ArrayList<String>();
        StringTokenizer stringToTokenize = new StringTokenizer(string);

        while (stringToTokenize.hasMoreTokens()) {
            tokenz.add(stringToTokenize.nextToken());
        }

        return tokenz;
    }

    private String deletePunctuationMarks(String string) {
        string = string.replace(".", "");
        string = string.replace("?", "");
        string = string.replace("!", "");
        string = string.replace(",", "");
        string = string.replace("\"", "");
        string = string.replace("\'", "");

        return string;
    }
}
