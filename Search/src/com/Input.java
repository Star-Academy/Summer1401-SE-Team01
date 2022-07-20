package com;


import java.util.ArrayList;
import java.util.Scanner;

public class Input {
    static SplitedInput splitedInput = new SplitedInput();

    public static SplitedInput prepareInput() {
        return split(get());
    }

    public static String[] get() {
        Scanner scanner = new Scanner(System.in);
        String keyWord = scanner.nextLine().toUpperCase();
        String [] words = keyWord.split(" +");

        scanner.close();
        return words;
    }

    public static SplitedInput split(String [] words) {
        for(String word: words) {
            if(word.startsWith("+"))
                splitedInput.getIncludeOne().add(word.substring(1));
            else if(word.startsWith("-"))
                splitedInput.getExcludeAll().add(word.substring(1));
            else
                splitedInput.getIncludeAll().add(word);
        }

        return splitedInput;
    }


}

