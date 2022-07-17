package com;

import java.util.*;

public class Main {

    public static void main(String[] args) {
	    FileReader fileReader = new FileReader();

        ArrayList<Doc> documents = fileReader.readFiles();

        for (Doc document: documents) InvertedIndex.add(document);

        Scanner scanner = new Scanner(System.in);
        String keyWord = scanner.next().toUpperCase();
        HashSet<Doc> answer = InvertedIndex.get(keyWord);
        for (Doc document: answer) {
            System.out.println(document.getName());
        }
        scanner.close();
    }
}


