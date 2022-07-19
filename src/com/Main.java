package com;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	    FileReader fileReader = new FileReader();

        ArrayList<Doc> documents = fileReader.readFiles();

        for (Doc document: documents) InvertedIndex.add(document);

        Scanner scanner = new Scanner(System.in);
        String keyWord = scanner.nextLine().toUpperCase();
        String [] words = keyWord.split(" +");

        ArrayList<String> includeAll = new ArrayList<>();
        ArrayList<String> excludeAll = new ArrayList<>();
        ArrayList<String> includeOne = new ArrayList<>();

        for(String word: words) {
            if(word.startsWith("+"))
                includeOne.add(word);
            else if(word.startsWith("-"))
                excludeAll.add(word);
            else
                includeAll.add(word);
        }

        HashSet<Doc> answer = InvertedIndex.get(includeAll, excludeAll, includeOne, documents);

        for (Doc document: answer) {
            System.out.println(document.getName());
        }
        scanner.close();
    }
}


